using System;

namespace Stealer
{
    //Stealer
    //Add the Hacker class with the provided methods and fields.
    //
    //Create a new class named Spy, with the following methods:
    //  •	StealFieldInfo(string className, string[] fieldNames).
    //  •	AnalyzeAccessModifiers(string className).
    //  •	RevealPrivateMethods(string className).
    //  •	CollectGettersAndSetters(string className).
    //
    //The StealFieldInfo method must print every field and its initialization value in the following format:
    //  "Class under investigation: {nameOfTheClass}"
    //  "{fieldName1} = {fieldValue1}"
    //  "{fieldName2} = {fieldValue2}"
    //  ...
    //  "{fieldNameN} = {fieldValueN}"
    //Example output:
    //  Class under investigation: Stealer.Hacker
    //  username = securityGod82
    //  password = mySuperSecretPassw0rd
    //
    //The AnalyzeAccessModifiers method must check the access modifiers of all fields and methods. It should print the following:
    //  •	If a field is not private, print "{fieldName} must be private!".
    //  •	If a getter is not public, print "{methodName} have to be public!".
    //  •	If a setter is not public, print "{methodName} have to be private!".
    //Example output:
    //  username must be private!
    //  get_Id have to be public!
    //  set_Password have to be private!
    //
    //The RevealPrivateMethods method must print all private methods in the following format:
    //  "All Private Methods of Class: {className}"
    //  "Base Class: {baseClassName}"
    //  "{methodName1}"
    //  "{methodName2}"
    //  ...
    //  "{methodNameN}"
    //Example output:
    //  All Private Methods of Class: Stealer.Hacker
    //  Base Class: Object
    //  get_Id
    //  set_Id
    //  set_BankAccountBalance
    //  MemberwiseClone
    //  Finalize
    //
    //The CollectGettersAndSetters must recognize which methods are getters and setters, then print them in the following format:
    //  •	If a method is a getter, print "{name} will return {returnType}".
    //  •	If a method is a setter, print "{name} will set field of {parameterType}".
    //Example output:
    //  get_Password will return System.String
    //  get_Id will return System.Int32
    //  get_BankAccountBalance will return System.Double
    //  set_Password will set field of System.String
    //  set_Id will set field of System.Int32
    //  set_BankAccountBalance will set field of System.Double

    class StartUp
    {
        static void Main()
        {
            Spy spy = new Spy();

            //string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            //string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            //string result = spy.RevealPrivateMethods("Stealer.Hacker");
            string result = spy.CollectGettersAndSetters("Stealer.Hacker");

            Console.WriteLine(result);
        }
    }
}
