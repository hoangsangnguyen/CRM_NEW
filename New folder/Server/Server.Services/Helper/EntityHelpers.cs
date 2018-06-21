using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vino.Server.Services.Helper
{
    public static class EntityHelpers
    {
        public static List<T> To<T>(this DataTable table)
        {
            List<T> ret = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                T t = To<T>(row);
                ret.Add(t);
            }
            return ret;
        }

        public static T To<T>(this DataRow row)
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            if (row != null)
            {
                foreach (PropertyInfo p in obj.GetType().GetProperties())
                {
                    if (p.CanWrite)
                    {
                        if (row.Table.Columns.Contains(p.Name) && row[p.Name] != DBNull.Value)
                        {
                            if (p.PropertyType == typeof(decimal) || p.PropertyType == typeof(decimal?))
                            {
                                p.SetValue(obj, decimal.Parse(row[p.Name].ToString()), null);
                            }
                            else if (p.PropertyType == typeof(double) || p.PropertyType == typeof(double?))
                            {
                                p.SetValue(obj, double.Parse(row[p.Name].ToString()), null);
                            }
                            else if (p.PropertyType == typeof(bool) || p.PropertyType == typeof(bool?))
                            {
                                p.SetValue(obj, bool.Parse(row[p.Name].ToString()), null);
                            }
                            else if (p.PropertyType == typeof(int) || p.PropertyType == typeof(int?))
                            {
                                p.SetValue(obj, Int32.Parse(row[p.Name].ToString()), null);
                            }
                            else if (p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?))
                            {
                                p.SetValue(obj, DateTime.Parse(row[p.Name].ToString()), null);
                            }
                            else if (p.PropertyType == typeof(string))
                            {
                                p.SetValue(obj, row[p.Name].ToString(), null);
                            }
                            else
                            {
                                p.SetValue(obj, row[p.Name], null);
                            }
                        }
                        else
                        {
                            p.SetValue(obj, null, null);
                        }
                    }
                }
            }

            return obj;
        }
    }
}
