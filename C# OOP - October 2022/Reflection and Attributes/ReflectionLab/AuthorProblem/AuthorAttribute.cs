using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorProblem
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute()
        {

        }

        public AuthorAttribute(string name)
            : base()
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
