using System;

namespace ValidationAttributes
{
    //Validation Attributes
    //Create your custom validation attribute MyValidationAttribute. Its purpose is to validate properties. It must contain an abstract bool method IsValid(object obj).
    //Create two validation attributes that inherit MyValidationAttribute - MyRangeAttribute and MyRequiredAttribute.
    //
    //MyRangeAttribute:
    //  •	Its constructor must accept two parameters - int minValue and int maxValue, which represent a range of integer numbers.
    //  •	It must contain two fields: int minValue and int maxValue.
    //  •	The logic for the IsValid(object obj) method must validate whether the passed object obj parameter is within the set range.
    //MyRequiredAttribute:
    //  •	The logic for the IsValid(object obj) method must validate whether a property has the attribute or not.
    //
    //Create a class Person. It must have a constructor which accepts two parameters - string fullName and int age.
    //It must have two properties:
    //  •	string FullName - the property is required. Apply the MyRequiredAttribute.
    //  •	int Age - the age can be between 12 and 90. Apply the MyRangeAttribute and set the right values for minimum and maximum age.
    //
    //Create a static class Validator. It must contain a public static bool method IsValid(object obj), which must validate the properties of a given object.

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person("Pesho", 22);
            bool isValidEntity = Validator.IsValid(person);
            Console.WriteLine(isValidEntity);
        }
    }
}
