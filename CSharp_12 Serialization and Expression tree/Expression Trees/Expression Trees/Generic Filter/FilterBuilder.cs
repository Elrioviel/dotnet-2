using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Generic_Filter
{
    public class FilterBuilder<T, V>
    {
        private static string _propertyName;
        private static string _methodName;
        private static V _searchTerm;
        private static V? _secondSearchTerm;

        public FilterBuilder(string propertyName, V searchTerm, V? secondSearchTerm, string methodName)
        {
            _methodName = methodName;
            _searchTerm = searchTerm;
            _secondSearchTerm = secondSearchTerm;
            _propertyName = propertyName;
        }

        public FilterBuilder(string propertyName, V searchTerm, string methodName)
        {
            _methodName = methodName;
            _searchTerm = searchTerm;
            _propertyName = propertyName;
        }

        public static Expression<Func<T, bool>> GetStringExpression()
        {
            Expression<Func<T, bool>> result = n => n != null;
            switch (_methodName)
            {
                case "Contains":
                    result = GetStringExpressionHelper(_propertyName, _searchTerm.ToString(), "Contains");
                    break;
                case "Equals":
                    result = GetStringExpressionHelper(_propertyName, _searchTerm.ToString(), "Equals");
                    break;
                case "GreaterThan":
                    result = GetStringExpressionHelper(_propertyName, _searchTerm.ToString(), "GreaterThan");
                    break;
                case "LessThan":
                    result = GetStringExpressionHelper(_propertyName, _searchTerm.ToString(), "LessThan");
                    break;
                case "Between":
                    Expression<Func<T, bool>> greater = GetStringExpressionHelper(_propertyName, _searchTerm.ToString(), "GreaterThan");
                    Expression<Func<T, bool>> less = GetStringExpressionHelper(_propertyName, _secondSearchTerm.ToString(), "LessThan");
                    result = And(greater, less);
                    break;
            }
            return result;
        }

        private static Expression<Func<T, bool>> GetStringExpressionHelper(string propertyName, string searchTerm, string methodName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "item");
            Expression property = Expression.Property(parameter, propertyName);
            MethodInfo miOperator = typeof(string).GetMethod(methodName, new Type[] { typeof(string) });
            Expression target = Expression.Constant(searchTerm, typeof(string));
            Expression method = Expression.Call(property, miOperator, target);
            return Expression.Lambda<Func<T, bool>>(method, parameter);
        }

        public static Expression<Func<T, bool>> GetNumericExpression()
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "item");
            Expression property = Expression.Property(parameter, _propertyName);
            Expression method = Expression.NotEqual(parameter, Expression.Constant(null));
            bool nullableProperty = IsNullableType(property.Type) || (property.Type.IsEnum && IsNullableEnum(property.Type));
            Type nonNullableType;
            object parsedFilter = ParseNumeric(property.Type, _searchTerm.ToString(), nullableProperty, out nonNullableType);
            object secondParsedFilter = ParseNumeric(property.Type, _secondSearchTerm.ToString(), nullableProperty, out nonNullableType);
            switch (_methodName)
            {
                case "Contains":
                    MethodInfo stringMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
                    MethodCallExpression convertToStringMethod = Expression.Call(Expression.Convert(property, typeof(object)), typeof(object).GetMethod("ToString"));
                    ConstantExpression stringMethodTarget = Expression.Constant(_searchTerm.ToString());
                    MethodCallExpression comparisonMethod = Expression.Call(convertToStringMethod, stringMethod, stringMethodTarget);
                    method = Expression.AndAlso(method, comparisonMethod);
                    break;
                case "Equals":
                    BinaryExpression equalMethod = Expression.Equal(nullableProperty ? Expression.Convert(property, nonNullableType) : property, Expression.Constant(parsedFilter));
                    method = Expression.AndAlso(method, equalMethod);
                    break;
                case "GreaterThan":
                    BinaryExpression greaterThanMethod = Expression.GreaterThan(nullableProperty ? Expression.Convert(property, nonNullableType) : property, Expression.Constant(parsedFilter));
                    method = Expression.AndAlso(method, greaterThanMethod);
                    break;
                case "LessThan":
                    BinaryExpression lessThanMethod = Expression.LessThan(nullableProperty ? Expression.Convert(property, nonNullableType) : property, Expression.Constant(parsedFilter));
                    method = Expression.AndAlso(method, lessThanMethod);
                    break;
                case "Between":
                    BinaryExpression greaterThanFirstSearchTerm = Expression.GreaterThan(nullableProperty ? Expression.Convert(property, nonNullableType) : property, Expression.Constant(parsedFilter));
                    BinaryExpression lessThanSecondSearchTerm = Expression.LessThan(nullableProperty ? Expression.Convert(property, nonNullableType) : property, Expression.Constant(secondParsedFilter));
                    method = Expression.AndAlso(method, greaterThanFirstSearchTerm);
                    method = Expression.AndAlso(greaterThanFirstSearchTerm, lessThanSecondSearchTerm);
                    break;
            }
            return Expression.Lambda<Func<T, bool>>(method, parameter);
        }

        private static object ParseNumeric(Type propertyType, string filter, bool isNullableProperty, out Type nonNullableType)
        {
            nonNullableType = null;
            object parsedFilter;
            if (isNullableProperty)
            {
                if (propertyType == typeof(int?) || propertyType.IsEnum || IsNullableEnum(propertyType))
                {
                    nonNullableType = typeof(int);
                    parsedFilter = int.Parse(filter);
                }
                else if (propertyType == typeof(short?))
                {
                    nonNullableType = typeof(short);
                    parsedFilter = short.Parse(filter);
                }
                else if (propertyType == typeof(long?))
                {
                    nonNullableType = typeof(long);
                    parsedFilter = long.Parse(filter);
                }
                else if (propertyType == typeof(decimal?))
                {
                    nonNullableType = typeof(decimal);
                    parsedFilter = decimal.Parse(filter);
                }
                else
                {
                    nonNullableType = typeof(int);
                    parsedFilter = int.Parse(filter);
                }
            }
            else
            {
                if (propertyType.IsEnum)
                {
                    try
                    {
                        parsedFilter = Enum.ToObject(propertyType, int.Parse(filter));
                    }
                    catch
                    {
                        parsedFilter = Enum.ToObject(propertyType, 0);
                    }
                }
                else
                {
                    try
                    {
                        parsedFilter = Convert.ChangeType(filter, propertyType);
                    }
                    catch
                    {
                        parsedFilter = (propertyType == typeof(long) || nonNullableType == typeof(long)) ? long.MaxValue : int.MaxValue;
                    }
                }
            }
            return parsedFilter;
        }

        static bool IsNullableType(Type T) => T.IsGenericType && T.GetGenericTypeDefinition() == typeof(Nullable<>);

        static bool IsNullableEnum(Type t)
        {
            Type u = Nullable.GetUnderlyingType(t);
            return (u != null) && u.IsEnum;
        }

        public static List<T> Apply(List<T> listToFilter, Expression<Func<T, bool>> ExpressionToApply)
        {
            Func<T, bool> del = ExpressionToApply.Compile();
            return listToFilter.Where(del).ToList();
        }
        public static Expression<Func<T, bool>> And(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            BinaryExpression body = Expression.AndAlso(Expression.Invoke(left, parameter), Expression.Invoke(right, parameter));
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
