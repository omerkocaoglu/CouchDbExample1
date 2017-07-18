using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CouchDbApplication.Generic
{
    public class GenericProperty<T1, T2>
    {
        public PropertyInfo[] GetProperties()
        {
           return typeof(T1).GetProperties().Where(x => x.GetCustomAttributes(typeof(T2), true).Length > 0).ToArray();
        }
    }
}
