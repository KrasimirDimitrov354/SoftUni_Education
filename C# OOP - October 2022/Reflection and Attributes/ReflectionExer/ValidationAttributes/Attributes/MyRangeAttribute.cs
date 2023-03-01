using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties((BindingFlags)60);

            foreach (var property in properties)
            {
                if (property.CustomAttributes.Any(att => att.AttributeType == typeof(MyRangeAttribute)))
                {
                    int propertyValue = Convert.ToInt32(property.GetValue(obj));

                    if (propertyValue < minValue || propertyValue > maxValue)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
