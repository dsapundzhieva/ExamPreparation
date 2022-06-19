using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.Students = new List<Student>(capacity);
        }

        public List<Student> Students { get; set; }

        public int Capacity { get; set; }

        public int Count => this.Students.Count;


        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                this.Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (this.Students.Any(x => x.FirstName == firstName && x.LastName == lastName))
            {
                Student student = this.Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
                this.Students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }
        public string GetSubjectInfo(string subject)
        {
            if (Students.Any(s => s.Subject == subject))
            {
                StringBuilder result = new StringBuilder();

                result.AppendLine($"Subject: {subject}");
                result.AppendLine("Students:");

                foreach (var student in Students.Where(student => student.Subject == subject))
                {
                    result.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return result.ToString().TrimEnd();
            }
            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = Students.FirstOrDefault(
               x => x.FirstName == firstName
               && x.LastName == lastName);
            return student;
        }
    }
}
