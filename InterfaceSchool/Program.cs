using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] x = { 1, 5, 4, 8 };
            //List<int> l = new List<int>(x);
            //l.Sort()

            //try
            //{
            //    Student stud1 = new Student("Абаев Георгий", 12, 3.4);
            //    Student stud2 = new Student("Багаев Аслан", -1, 4);
            //    Student stud3 = new Student("Багаев Аслан", 1, 18);
            //    Student stud4 = new Student("Багаев Аслан", 11, 3);
            //    stud4.Pass();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            Student studA = new Student();
            Student studB = new Student();
            Student studBagaev = new Student("Багаев Аслан", 4, 4);
            Student studAbaev = new Student("Абаев Георгий", 7, 3.4);
            Student studAtaev = new Student("Атаев Сослан", 5, 3);
            Console.WriteLine(studA);
            Console.WriteLine(studB);
            Console.WriteLine(studAbaev);
            Console.WriteLine(studBagaev);
            Console.WriteLine(studAtaev);
            studBagaev.Pass();
            Console.WriteLine(studBagaev);
           
            School school = new School("ФизМат");
            school.Add(studB);
            school.Add(studBagaev);
            school.Add(studAbaev);
            school.Add(studA);
            school.Add(studAtaev);
            Console.WriteLine(school);
            Console.WriteLine(school.Count(x => x > 1));
            Console.WriteLine(school.Count(x => x == Stages.ELelementary));
            Console.WriteLine(school.Count((x, y) => (x >= 3.0 && x <= 5 && y == 1)));
            Console.WriteLine(school.Count(x => x.Contains("Багаев")));

            //school.Sort();
            //Console.WriteLine(school);
            school.Sort(x => x == 1);
            Console.WriteLine(school);

        }
    }
}
