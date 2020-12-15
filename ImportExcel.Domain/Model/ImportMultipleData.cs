using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ImportExcel.Domain.Model
{
    public class ImportMultipleData<T> where T : IImportMultipleData
    {
        public static void AddIfIsNotEmpty(List<T> list, T obj)
        {
            var props = obj.GetType().GetProperties();

            var stringsHasValue = props
                .Where(prop => ((Column)prop.GetCustomAttribute(typeof(Column))) != null
                        && (IgnoreValue)prop.GetCustomAttribute(typeof(IgnoreValue)) == null
                        && prop.PropertyType.Equals(typeof(string)))
                .Select(pi => (string)pi.GetValue(obj))
                .Any(value => !string.IsNullOrEmpty(value));

            var doublesHasValue = props
                .Where(prop => prop.PropertyType == typeof(Nullable<double>)
                        && (Column)prop.GetCustomAttribute(typeof(Column)) != null
                        && (IgnoreValue)prop.GetCustomAttribute(typeof(IgnoreValue)) == null)
                .Select(pi => (Nullable<double>)pi.GetValue(obj))
                .Any(value => value != null && value != 0);

            var integerHasValue = props
                .Where(prop => prop.PropertyType == typeof(Nullable<int>)
                        && (Column)prop.GetCustomAttribute(typeof(Column)) != null
                        && (IgnoreValue)prop.GetCustomAttribute(typeof(IgnoreValue)) == null)
                .Select(pi => (Nullable<int>)pi.GetValue(obj))
                .Any(value => value != null && value != 0);

            if (stringsHasValue || doublesHasValue || integerHasValue) list.Add(obj);
        }
    }
    public class ImportMultipleData { }
}