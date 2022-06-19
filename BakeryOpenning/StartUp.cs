namespace BakeryOpenning
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Initialize the repository
            Bakery bakery = new Bakery("Barny", 2);
            //Initialize entity
            Employee employee = new Employee("Stephen", 40, "Bulgaria");
            //Print Employee
            Console.WriteLine(employee); //Employee: Stephen, 40 (Bulgaria)

            //Add Employee
            bakery.Add(employee);
            //Remove Employee
            Console.WriteLine(bakery.Remove("Employee name")); //false

            Employee secondEmployee = new Employee("Mark", 34, "UK");

            //Add Employee
            bakery.Add(secondEmployee);

            Employee thirdEmployee = new Employee("Test", 34, "UK");
            bakery.Add(thirdEmployee);

            Employee oldestEmployee = bakery.GetOldestEmployee(); // Employee with name Stephen
            Employee employeeStephen = bakery.GetEmployee("Stephen"); // Employee with name Stephen
            Console.WriteLine(oldestEmployee); //Employee: Stephen, 40 (Bulgaria)
            Console.WriteLine(employeeStephen); //Employee: Stephen, 40 (Bulgaria)

            Console.WriteLine(bakery.Count); //2

            Console.WriteLine(bakery.Report());
            //Employees working at Bakery Barny:
            //Employee: Stephen, 40 (Bulgaria)
            //Employee: Mark, 34 (UK)

        }
    }
}
