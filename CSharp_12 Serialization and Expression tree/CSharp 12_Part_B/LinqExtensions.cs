using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTasksReinvent
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> Repeat<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            //foreach(var item in source)
            //{
            //    if (IsNotValid(item)) throw new ArgumentException("source");
            //}
            List<TSource> result = new();
            for (int i = 0; i < count; i++)
            {
                result.AddRange(source);
            }
            return result;
        }

        //public static bool IsNotValid(object value)
        //{
        //    Array array = value as Array;
        //    return array.Length > 1;
        //}

        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            if (first == null) throw new ArgumentException(null, nameof(first));
            if (second == null) throw new ArgumentException(null, nameof(second));
            foreach (TSource firstElement in first)
            {
                yield return firstElement;
            }
            foreach (TSource secondElement in second)
            {
                yield return secondElement;
            }
        }

        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            List<TSource> result = new();
            List<TSource> sourceList = source.ToList();
            for (int i = 0; i < count; i++)
            {
                result.Add(sourceList[i]);
            }
            return result;
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(TSource);
        }

        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            List<TSource> sourceList = new();
            sourceList.AddRange(source);
            return sourceList;
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            int index = 0;
            foreach (TSource item in source)
            {
                if (predicate(item, index))
                {
                    yield return item;
                }
                index++;
            }
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value,
            IEqualityComparer<TSource> comparer)
        {
            comparer ??= EqualityComparer<TSource>.Default;
            return source.Any(item => comparer.Equals(value, item));
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            int index = 0;
            foreach (TSource item in source)
            {
                yield return selector(item, index);
                index++;
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            foreach (TSource item in source)
            {
                foreach (TResult result in selector(item))
                {
                    yield return result;
                }
            }
        }

        public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (func == null) throw new ArgumentNullException(nameof(func));
            var sourceList = source.ToList();
            using (List<TSource>.Enumerator iterator = sourceList.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    throw new InvalidOperationException("source sequence empty");
                }
                TSource current = iterator.Current;
                while (iterator.MoveNext())
                {
                    current = func(current, iterator.Current);
                }
                return current;
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
        {
            return source.Distinct(EqualityComparer<TSource>.Default);
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            HashSet<TSource> uniqueItems = new(comparer);
            foreach (TSource item in source)
            {
                if (uniqueItems.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            return Intersect(first, second, EqualityComparer<TSource>.Default);
        }

        private static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            HashSet<TSource> uniqueItems = new(second, comparer);
            foreach (TSource item in first)
            {
                if (uniqueItems.Remove(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
            return resultSelector == null
                ? throw new ArgumentNullException("resultSelector")
                : source.GroupBy(keySelector, elementSelector, EqualityComparer<TKey>.Default).Select(group => resultSelector(group.Key, group));
        }

        private static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            ILookup<TKey, TElement> lookup = source.ToLookup(keySelector, elementSelector, comparer);
            foreach (var result in lookup)
            {
                yield return result;
            }
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            if (outer == null) throw new ArgumentNullException(nameof(outer));
            if (inner == null) throw new ArgumentNullException(nameof(inner));
            if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
            if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
            return resultSelector == null
                ? throw new ArgumentNullException("resultKeySelector")
                : outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);
        }

        private static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            ILookup<TKey, TInner> lookUp = inner.ToLookup(innerKeySelector, comparer);
            foreach (TOuter outerItem in outer)
            {
                TKey key = outerKeySelector(outerItem);
                foreach (TInner innerItem in lookUp[key])
                {
                    yield return resultSelector(outerItem, innerItem);
                }
            }
        }
    }
}