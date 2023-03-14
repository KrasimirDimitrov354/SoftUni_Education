using System.Text;

using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni;

public class StartUp
{
    static void Main()
    {
        SoftUniContext softUniContext = new SoftUniContext();
        Console.WriteLine(RemoveTown(softUniContext));
    }

    //03. Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        //Extract all employees and return their:
        //  - first, last and middle name;
        //  - job title;
        //  - salary rounded to 2 symbols after the decimal separator.
        //
        //Separate the fields with a space. Order the results by employee id.

        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var employee in employees)
        {
            output.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName}" +
                $" {employee.JobTitle} {Math.Round(employee.Salary, 2):f2}");
        }

        return output.ToString().TrimEnd();
    }

    //04. Employees with Salary Over 50 000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        //Extract all employees with salary over 50 000. Return their first names and salaries in format "{firstName} - {salary}".
        //Salary must be rounded to 2 symbols after the decimal separator. Sort the results alphabetically by first name.

        var employees = context.Employees
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var employee in employees)
        {
            output.AppendLine($"{employee.FirstName} - {Math.Round(employee.Salary, 2):f2}");
        }

        return output.ToString().TrimEnd();
    }

    //05. Employees from Research and Development
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        //Extract all employees from the Research and Development department.
        //Order them by salary in ascending order, then by first name in descending order.
        //Return only their first name, last name, department name and salary rounded to 2 symbols after the decimal separator.

        var researchEmployees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var employee in researchEmployees)
        {
            output.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName}" +
                $" - ${Math.Round(employee.Salary, 2):f2}");
        }

        return output.ToString().TrimEnd();
    }

    //06. Adding a new Address and updating Employee
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        //Create a new address with the text "Vitoshka 15" and TownId = 4. Set the address to the employee with the last name "Nakov".
        //Order all the employees by their Address' Id in descending order, take 10 rows and from them take the AddressText.
        //Return the results each on a new line.

        Address newAddress = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        Employee employee = context.Employees.First(e => e.LastName == "Nakov");
        employee.Address = newAddress;

        context.SaveChanges();

        string[] employeeAddresses = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Select(e => e.Address!.AddressText)
            .Take(10)
            .ToArray();

        return String.Join(Environment.NewLine, employeeAddresses);
    }

    //07. Employees and Projects
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        //Find the first 10 employees and print each employee's first name, last name, manager's first name and last name.
        //If an employee has projects started in the period 2001 - 2003 (inclusive), print them with information about their name, start and end date.
        //Return all of an employee's projects in the format "--<ProjectName> - <StartDate> - <EndDate>", each on a new row.
        //Use date format: "M/d/yyyy h:mm:ss tt". If a project has no end date, print "not finished" instead.

        var employees = context.Employees
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager!.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                 ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                        EndDate = ep.Project.EndDate.HasValue
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                            : "not finished"
                    })
                    .ToArray()
            })
            .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var e in employees)
        {
            output.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

            foreach (var p in e.Projects)
            {
                output.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
            }
        }

        return output.ToString().TrimEnd();
    }

    //08. Addresses by Town
    public static string GetAddressesByTown(SoftUniContext context)
    {
        //Order all addresses by:
        //- number of employees who live there (descending);
        //- town name (ascending);
        //- address text (ascending).
        //Take only the first 10 addresses in the format "<AddressText>, <TownName> - <EmployeeCount> employees".

        var addresses = context.Addresses
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.Town!.Name)
            .ThenBy(a => a.AddressText)
            .Select(a => new
            {
                a.AddressText,
                TownName = a.Town!.Name,
                EmployeeCount = a.Employees.Count
            })
            .Take(10)
            .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var a in addresses)
        {
            output.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
        }

        return output.ToString().TrimEnd();
    }

    //09. Employee 147
    public static string GetEmployee147(SoftUniContext context)
    {
        //Get the employee with id 147. Return only their first name, last name, job title and project names.
        //Order the projects by name (ascending).

        var employeeInfo = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                Name = String.Concat(e.FirstName, " ", e.LastName),
                e.JobTitle,
                Projects = e.EmployeesProjects
                    .Select(p => new
                    {
                        Name = p.Project.Name
                    })
                    .OrderBy(p => p.Name)
                    .ToArray()
            })
            .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var e in employeeInfo)
        {
            output.AppendLine($"{e.Name} - {e.JobTitle}");

            foreach (var p in e.Projects)
            {
                output.AppendLine(p.Name);
            }
        }

        return output.ToString().TrimEnd();
    }

    //10. Departments with More Than 5 Employees
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        //Find all departments with more than 5 employees. Order them by employee count (ascending), then by department name (alphabetically).
        //
        //For each department, print the department name and the manager's first and last name on the first row.
        //Then print the first name, the last name and the job title of every employee on a new row.
        //Order the employees by first name (ascending), then by last name (ascending).
        //
        //Format of the output: For each department print it in the format "<DepartmentName> - <ManagerFirstName>  <ManagerLastName>".
        //For each employee print it in the format "<EmployeeFirstName> <EmployeeLastName> - <JobTitle>".

        var departments = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                d.Name,
                ManagerName = String.Concat(d.Manager.FirstName, " ", d.Manager.LastName),
                Employees = d.Employees
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToArray()
            })
            .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var d in departments)
        {
            output.AppendLine($"{d.Name} - {d.ManagerName}");

            foreach (var e in d.Employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }

        return output.ToString().TrimEnd();
    }

    //11. Find Latest 10 Projects
    public static string GetLatestProjects(SoftUniContext context)
    {
        //Write a program that returns information about the last 10 started projects.
        //Sort them by name lexicographically and return their name, description and start date, each on a new row.

        var projects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .Select(p => new
            {
                p.Name,
                p.Description,
                StarDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
            })
            .OrderBy(p => p.Name)
            .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var p in projects)
        {
            output.AppendLine(p.Name)
                .AppendLine(p.Description)
                .AppendLine(p.StarDate);
        }

        return output.ToString().TrimEnd();
    }

    //12. Increase Salaries
    public static string IncreaseSalaries(SoftUniContext context)
    {
        //Write a program that increases the salaries by 12% of all employees in the following departments:
        //- Engineering
        //- Tool Design
        //- Marketing
        //- Information Services
        //
        //Return the first name, last name and salary for those employees whose salary was increased.
        //Order them by first name (ascending), then by last name (ascending).

        string[] departmentForRaises = new string[]
        {
            "Engineering",
            "Tool Design",
            "Marketing",
            "Information Services"
        };

        var employeesForRaise = context.Employees
            .Where(e => departmentForRaises.Contains(e.Department.Name));

        foreach (var e in employeesForRaise)
        {
            e.Salary += e.Salary * 0.12m;
        }

        context.SaveChanges();

        var employeesInfo = employeesForRaise
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var e in employeesInfo)
        {
            output.AppendLine($"{e.FirstName} {e.LastName} (${Math.Round(e.Salary, 2):f2})");
        }

        return output.ToString().TrimEnd();
    }

    //13. Find Employees by First Name Starting with "Sa"
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        //Write a program that finds all employees whose first name starts with "Sa".
        //Return their first name, last name, their job title and their salary rounded to 2 symbols after the decimal separator.
        //Order them by the first name, then by last name (ascending).

        var employees = context.Employees
            .Where(e => e.FirstName
                .ToLower()
                .StartsWith("sa"))
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        StringBuilder output = new StringBuilder();

        foreach (var e in employees)
        {
            output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${Math.Round(e.Salary, 2):f2})");
        }

        return output.ToString().TrimEnd();
    }

    //14. Delete Project by Id
    public static string DeleteProjectById(SoftUniContext context)
    {
        //Delete the project with id 2. Then take 10 projects and return their names, each on a new line.

        var toDeleteFromEmployeesProjects = context.EmployeesProjects
            .Where(ep => ep.ProjectId == 2);
        context.EmployeesProjects.RemoveRange(toDeleteFromEmployeesProjects);

        Project? toDeleteFromProjects = context.Projects.Find(2);
        context.Projects.Remove(toDeleteFromProjects!);

        context.SaveChanges();

        string[] firstTenProjects = context.Projects
            .Take(10)
            .Select(p => p.Name)
            .ToArray();

        return String.Join(Environment.NewLine, firstTenProjects);
    }

    //15. Remove Town
    public static string RemoveTown(SoftUniContext context)
    {
        //Write a program that deletes a town with the name "Seattle" and then deletes all addresses that are in it.
        //Return the number of addresses that were deleted in the format "{count} addresses in Seattle were deleted".

        Town? seattle = context.Towns
            .Where(t => t.Name == "Seattle")
            .FirstOrDefault();

        var addressesInSeattle = context.Addresses
            .Where(a => a.TownId == seattle!.TownId);
        int addressesAffected = addressesInSeattle.Count();

        var employeesInSeattle = context.Employees
            .Where(e => addressesInSeattle.Contains(e.Address));

        foreach (Employee employee in employeesInSeattle)
        {
            employee.AddressId = null;
            employee.Address = null;
        }

        context.Addresses.RemoveRange(addressesInSeattle);
        context.Towns.Remove(seattle!);

        context.SaveChanges();

        return $"{addressesAffected} addresses in Seattle were deleted";
    }
}
