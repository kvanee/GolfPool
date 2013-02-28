using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GolfPool.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> values, T value)
        {
            yield return value;
            foreach (T item in values)
            {
                yield return item;
            }
        }

        public static string ToCsv(this IEnumerable<string> strings)
        {
            return strings.Aggregate("", (x, y) => x + ", " + y).TrimStart(new[] { ',', ' ' });
        }

        public static string PropName<T, R>(this T obj, Expression<Func<T, R>> expr)
        {
            var node = expr.Body as MemberExpression;
            if (object.ReferenceEquals(null, node))
                throw new InvalidOperationException("expr must be member access Expression");
            return node.Member.Name;
        }

        public static string DisplayName<T, R>(this T obj, Expression<Func<T, R>> expr)
        {
            var node = expr.Body as MemberExpression;
            if (object.ReferenceEquals(null, node))
                throw new InvalidOperationException("expr must be member access Expression");
            var attr = node.Member.GetAttribute<DisplayNameAttribute>();
            if (attr == null)
            {
                return node.Member.Name;
            }

            return attr.DisplayName;
        }

        public static T GetAttribute<T>(this MemberInfo member) where T : Attribute
        {
            var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();
            return (T)attribute;
        }

        public static Dictionary<int, byte> AddZero(this Dictionary<int, byte> dictionary)
        {
            dictionary.Add(0, 0);
            return dictionary;
        }

        public static Dictionary<int, int> AddZero(this Dictionary<int, int> dictionary)
        {
            dictionary.Add(0, 0);
            return dictionary;
        }

        public static Dictionary<int, Dictionary<int, byte>> AddZero(this Dictionary<int, Dictionary<int, byte>> dictionary, IEnumerable<int> range)
        {
            var value = range.Prepend(0).Distinct().ToDictionary(i => i, i => (byte)0);
            dictionary.Add(0, value);
            return dictionary;
        }
    }
}