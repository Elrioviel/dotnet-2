using System;
using Students;
using Generic_Filter;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Expression_Trees_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new() { Name = "Mike", Surname = "Myke", Test = "Biology", Date = new DateTime(2020, 11, 05), Score = 4 };
            Student student2 = new() { Name = "Catherine", Surname = "Colley", Test = "Geography", Date = new DateTime(2021, 06, 01), Score = 5 };
            Student student3 = new() { Name = "Mike", Surname = "Myke", Test = "Science", Date = new DateTime(2020, 11, 06), Score = 2 };
            Student student4 = new() { Name = "Catherine", Surname = "Colley", Test = "Mathematics", Date = new DateTime(2021, 06, 02), Score = 5 };
            List<Student> studentsList = new() { student1, student2, student3, student4 };

            Console.WriteLine(string.Join(',', FilterListByStringFilter(studentsList, "Name", "Mike", "Equals")));
            Console.WriteLine(string.Join(',', FilterListByStringFilter(studentsList, "Surname", "Col", "Contains")));
            //Console.WriteLine(string.Join(',', FilterListByStringFilter(studentsList, "Test", "Biology", "GreaterThan")));
            Console.WriteLine(string.Join(',', FilterListByDateFilter(studentsList, "Date", new DateTime(2021, 06, 02), "LessThan")));
            Console.WriteLine(string.Join(',', FilterListByIntFilter(studentsList, "Score", 3, 5, "Between")));
        }

        private static List<Student> FilterListByIntFilter(List<Student> listToFilter, string propertyName, int value, string methodName)
        {
            FilterBuilder<Student, int> filter = new FilterBuilder<Student, int>(propertyName, value, methodName);
            Expression<Func<Student, bool>> nameExpr = FilterBuilder<Student, int>.GetNumericExpression();
            return FilterBuilder<Student, int>.Apply(listToFilter, nameExpr);
        }

        private static List<Student> FilterListByIntFilter(List<Student> listToFilter, string propertyName, int value, int secondValue, string methodName)
        {
            FilterBuilder<Student, int> filter = new FilterBuilder<Student, int>(propertyName, value, secondValue, methodName);
            Expression<Func<Student, bool>> nameExpr = FilterBuilder<Student, int>.GetNumericExpression();
            return FilterBuilder<Student, int>.Apply(listToFilter, nameExpr);
        }

        private static List<Student> FilterListByStringFilter(List<Student> listToFilter, string propertyName, string value, string methodName)
        {
            FilterBuilder<Student, string> filter = new FilterBuilder<Student, string>(propertyName, value, methodName);
            Expression<Func<Student, bool>> nameExpr = FilterBuilder<Student, string>.GetStringExpression();
            return FilterBuilder<Student, string>.Apply(listToFilter, nameExpr);
        }

        private static List<Student> FilterListByStringFilter(List<Student> listToFilter, string propertyName, string value, string secondValue, string methodName)
        {
            FilterBuilder<Student, string> filter = new FilterBuilder<Student, string>(propertyName, value, secondValue, methodName);
            Expression<Func<Student, bool>> nameExpr = FilterBuilder<Student, string>.GetStringExpression();
            return FilterBuilder<Student, string>.Apply(listToFilter, nameExpr);
        }

        private static List<Student> FilterListByDateFilter(List<Student> listToFilter, string propertyName, DateTime value, string methodName)
        {
            FilterBuilder<Student, DateTime> filter = new FilterBuilder<Student, DateTime>(propertyName, value, methodName);
            Expression<Func<Student, bool>> nameExpr = FilterBuilder<Student, DateTime>.GetNumericExpression();
            return FilterBuilder<Student, string>.Apply(listToFilter, nameExpr);
        }

        private static List<Student> FilterListByDateFilter(List<Student> listToFilter, string propertyName, DateTime value, DateTime secondValue, string methodName)
        {
            FilterBuilder<Student, DateTime> filter = new FilterBuilder<Student, DateTime>(propertyName, value, secondValue, methodName);
            Expression<Func<Student, bool>> nameExpr = FilterBuilder<Student, DateTime>.GetNumericExpression();
            return FilterBuilder<Student, string>.Apply(listToFilter, nameExpr);
        }
    }
}
