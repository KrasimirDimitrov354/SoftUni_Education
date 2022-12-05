using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties((BindingFlags)60);

            foreach (var property in properties)
            {
                var myAttribute = (MyValidationAttribute)property.GetCustomAttribute(typeof(MyValidationAttribute));

                if (!myAttribute.IsValid(obj))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
