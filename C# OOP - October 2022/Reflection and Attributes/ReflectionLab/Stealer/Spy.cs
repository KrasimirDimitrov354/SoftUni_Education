using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Stealer
{
    public class Spy
    {
        public Spy()
        {

        }

        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            StringBuilder output = new StringBuilder();

            Type soughtClass = Type.GetType(className);
            output.AppendLine($"Class under investigation: {soughtClass.FullName}");

            object classInstance = Activator.CreateInstance(soughtClass);
            FieldInfo[] fields = soughtClass.GetFields((BindingFlags)60);

            foreach (string fieldName in fieldNames)
            {
                FieldInfo soughtField = fields.FirstOrDefault(f => f.Name == fieldName);
                output.AppendLine($"{soughtField.Name} = {soughtField.GetValue(classInstance)}");
            }

            return output.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder output = new StringBuilder();
            Type soughtClass = Type.GetType(className);

            FieldInfo[] fields = soughtClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            foreach (var field in fields)
            {
                output.AppendLine($"{field.Name} must be private!");
            }

            MethodInfo[] methods = soughtClass.GetMethods((BindingFlags)60);
            foreach (var method in methods)
            {
                if (method.Name.StartsWith("get") && !method.IsPublic)
                {
                    output.AppendLine($"{method.Name} have to be public!");
                }
                else if (method.Name.StartsWith("set") && method.IsPublic)
                {
                    output.AppendLine($"{method.Name} have to be private!");
                }
            }

            return output.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder output = new StringBuilder();
            Type soughtClass = Type.GetType(className);

            output.AppendLine($"All Private Methods of Class: {soughtClass.FullName}");
            output.AppendLine($"Base Class: {soughtClass.BaseType.Name}");

            MethodInfo[] privateMethods = soughtClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var method in privateMethods)
            {
                output.AppendLine($"{method.Name}");
            }

            return output.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder output = new StringBuilder();
            Type soughtClass = Type.GetType(className);
            MethodInfo[] privateMethods = soughtClass.GetMethods((BindingFlags)60);

            foreach (var getter in privateMethods.Where(g => g.Name.StartsWith("get")))
            {
                output.AppendLine($"{getter.Name} will return {getter.ReturnType.FullName}");
            }

            foreach (var setter in privateMethods.Where(g => g.Name.StartsWith("set")))
            {
                output.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
