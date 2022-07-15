using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp7
{
    //Company Users
    //Create a program that keeps information about companies and their employees.
    //
    //You will be receiving a company name and an employee's id until you receive the "End" command. Add each employee to the given company.
    //Keep in mind that a company cannot have two employees with the same id.
    //
    //When you finish reading the data, print the company's name and each employee's id in the following format:
    //  {companyName}
    //  -- {id1}
    //  -- {id2}
    //  -- {idN}
    //
    //Input / Constraints
    //  •	Until you receive the "End" command, you will be receiving input in the format: "{companyName} -> {employeeId}".
    //  •	The input always will be valid.
    //
    //Examples
    //Input
    //  SoftUni -> AA12345
    //  SoftUni -> BB12345
    //  Microsoft -> CC12345
    //  HP -> BB12345
    //  End
    //Output
    //  SoftUni
    //  -- AA12345
    //  -- BB12345
    //  Microsoft
    //  -- CC12345
    //  HP
    //  -- BB12345
    //
    //Input
    //  SoftUni -> AA12345
    //  SoftUni -> CC12344
    //  Lenovo -> XX23456
    //  SoftUni -> AA12345
    //  Movement -> DD11111
    //  End
    //Output
    //  SoftUni
    //  -- AA12345
    //  -- CC12344
    //  Lenovo
    //  -- XX23456
    //  Movement
    //  -- DD11111

    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> employeesOfCompany = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" -> ").ToArray();

                if (input[0] == "End")
                {
                    foreach (var company in employeesOfCompany)
                    {
                        Console.WriteLine(company.Key);

                        foreach (string employee in company.Value)
                        {
                            Console.WriteLine($"-- {employee}");
                        }
                    }

                    break;
                }
                else
                {
                    string company = input[0];
                    string employee = input[1];

                    if (employeesOfCompany.ContainsKey(company) == false)
                    {
                        employeesOfCompany.Add(company, new List<string>());
                    }
                    
                    if (employeesOfCompany[company].Contains(employee) == false)
                    {
                        employeesOfCompany[company].Add(employee);
                    }
                }
            }
        }
    }
}
