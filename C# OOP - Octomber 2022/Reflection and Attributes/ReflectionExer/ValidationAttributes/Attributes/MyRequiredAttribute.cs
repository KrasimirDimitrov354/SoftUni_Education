using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public MyRequiredAttribute()
        {

        }

        public override bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties((BindingFlags)60);

            foreach (var property in properties)
            {
                if (property.CustomAttributes.Any(att => att.AttributeType == typeof(MyRequiredAttribute)))
                {
                    if (property.GetValue(obj) == null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
