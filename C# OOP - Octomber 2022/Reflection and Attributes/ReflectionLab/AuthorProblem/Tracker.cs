using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public Tracker()
        {

        }

        public void PrintMethodsByAuthor()
        {
            Type classType = typeof(StartUp);
            MethodInfo[] methods = classType.GetMethods((BindingFlags)60);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    AuthorAttribute authorAttribute = (AuthorAttribute)method.GetCustomAttribute(typeof(AuthorAttribute));
                    Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                }
            }
        }
    }
}
