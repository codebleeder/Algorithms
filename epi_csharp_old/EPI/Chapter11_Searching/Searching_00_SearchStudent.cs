using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter11_Searching
{
    public static class Searching_00_SearchStudent
    {
        public static int SearchStudent(List<Student> students, Student target)
        {
            return students.BinarySearch(target);
        }
        public static void Test()
        {
            var c = new Student("c", 3.1);
            var d = new Student("d", 3.5);
            var e = new Student("e", 3.5);
            var students = new List<Student>
            {
                new Student("a", 2.9),
                new Student("b", 3.0),
                c,
                new Student("d", 3.5),
                new Student("e", 3.5),
                new Student("f", 4.0),
            };
            var res = SearchStudent(students, e);
            if (res > -1)
            {
                Console.WriteLine(students[res].ToString());
            }
        }
    }
    public class Student:IComparable<Student>
    {
        public string Name { get; set; }
        public double GPA { get; set; }
        public Student(string name, double gpa)
        {
            Name = name;
            GPA = gpa;
        }
        public int CompareTo(Student other)
        {
            if (GPA != other.GPA)
            {
                return GPA.CompareTo(other.GPA);
            }
            return Name.CompareTo(other.Name);
        }
        public override string ToString()
        {
            return $"Name: {Name}    GPA: {GPA}";
        }
    }
}
