using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.Helper
{
    public static class ValueObjectExtension
    {
        public static object ValueOf(this object obj, string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                propertyName = propertyName.Trim();
            }

            if (obj == null) return null;
            object result = null;
            Type type = obj.GetType();
            if (propertyName.IndexOf(".") >= 0)
            {
                int idx = propertyName.IndexOf(".");
                string pProp = propertyName.Substring(0, idx);
                string oProp = propertyName.Substring(idx + 1, propertyName.Length - idx - 1);
                object child = type.GetProperty(pProp).GetValue(obj, null);
                result = child.ValueOf(oProp);
            }
            else
            {
                PropertyInfo[] infos = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var item in infos)
                {
                    if (item.Name.Equals(propertyName, StringComparison.Ordinal))
                    {
                        return item.GetValue(obj, null);
                    }
                }
            }
            return result;

        }

        public static object ValueOf(this object obj, string propertyName, string delimiter, string template,
            bool isMultiple = false)
        {
            if (obj == null) return null;
            object result = null;
            Type type = obj.GetType();
            if (isMultiple)
            {
                string[] properties = propertyName.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                StringBuilder res = new StringBuilder();
                PropertyInfo[] infos =
                    type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                List<object> list = new List<object>();
                for (int i = 0; i < properties.Length; i++)
                {
                    object temp = obj.ValueOf(properties[i]);
                    list.Add(temp == null ? string.Empty : temp.ToString());
                }
                string text = string.Format(template, list.ToArray());
                if (text != null)
                {
                    return text.Replace(", ,", ",");
                }
                return text;
            }
            else
            {
                if (propertyName.IndexOf(".") >= 0)
                {
                    int idx = propertyName.IndexOf(".");
                    string pProp = propertyName.Substring(0, idx);
                    string oProp = propertyName.Substring(idx + 1, propertyName.Length - idx - 1);
                    if (type.GetProperty(pProp) == null)
                    {
                        throw new Exception("Unknow property" + propertyName);
                    }

                    object child = type.GetProperty(pProp).GetValue(obj, null);
                    result = child.ValueOf(oProp);
                }
                else
                {
                    PropertyInfo[] infos = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    foreach (var item in infos)
                    {
                        if (item.Name.Equals(propertyName, StringComparison.Ordinal))
                        {
                            return item.GetValue(obj, null);
                        }
                    }
                }
                return result;
            }
        }

        public static bool SetValueOf(this object obj, string propertyName, object value)
        {
            if (obj == null || value == null || string.IsNullOrEmpty(propertyName))
                return false;
            propertyName = propertyName.Trim();
            PropertyInfo prop = obj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
            if (prop != null && prop.CanWrite && value.GetType() == prop.PropertyType)
            {
                prop.SetValue(obj, value, null);
                return true;
            }
            return false;
        }
    }
}
