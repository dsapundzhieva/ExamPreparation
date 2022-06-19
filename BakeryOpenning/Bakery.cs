using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Employees = new List<Employee>(capacity);
        }

        public List<Employee> Employees { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }


        public void Add(Employee employee)
        {
            if (this.Employees.Count < this.Capacity)
            {
                this.Employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            if (!this.Employees.Any(x => x.Name == name))
            {
                return false;
            }
            Employee employee = this.Employees.First(x => x.Name == name);
            this.Employees.Remove(employee);
            return true;
        }

        public Employee GetOldestEmployee()
        {
            return this.Employees.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            var employee = this.Employees.FirstOrDefault(x => x.Name == name);
            return employee;
        }

        public int Count => this.Employees.Count;

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var item in this.Employees)
            {
                result.AppendLine(item.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
