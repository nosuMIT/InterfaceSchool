﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceSchool
{
    public enum Stages
    {
        ELelementary,
        Secondary,
        Higher
    }
    internal class Student
    {
        static string[] levelStages = { "младшая", "средняя", "старшая" };
        static int[] levelStagesToGrage = { 4, 8, 11 };
        static string generateName = "A";
        public string FIO { set; get; }
        int grade;
        double perfomance;
        Stages stage;
        public Stages Stage { get; }

        public double Performance 
        {
            set 
            {
                if (value >= 0 && value <= 5)
                    perfomance = value;
                else
                    throw new Exception("perfomance must be from 0 to 5");
            }
            get { return perfomance; }
            
        }
              
        void setStage(int value)
        {
            for (int i = 0; i < levelStagesToGrage.Length; i++)
                if ((int)value <= levelStagesToGrage[i])
                {
                    stage = (Stages)i;
                    return;
                }
            throw new Exception("Bad stages");
        }
        
        public int Grade 
        {
            set
            {
                if (value >= 1 && value <= 11)
                {
                    grade = value;
                    setStage(value);
                }
                else 
                {
                    throw new Exception("grade must be from 1 to 11");
                }
            }
            get { return grade; }
        }

        public Student()
        {
            FIO = generateName;
            generateName = Convert.ToString(Convert.ToChar(Convert.ToInt32(generateName[0])+ 1));
            grade = 1;
            Performance = 5;
            stage = Stages.ELelementary;
        }

        public Student(string name, int grade, double performance)
        {
            FIO = name;
            Grade = grade;
            Performance = performance;
        }
        public override string ToString()
        {
            
            return $"{FIO}, {levelStages[(int)stage]} школа, {grade} класс, {Performance} балла";
        }
        public void Pass()
        {
            if (grade < 11)
            {
                grade++;
                setStage(grade);
            }
            else
                throw new Exception("Bad grade for pass");
        }
    }
    class School
    {
        public string NameSchool { set; get; }
        List<Student> listStudents = new List<Student>();

        public School(string name)
        {
            NameSchool = name;
        }
        public void Add(Student student)
        { listStudents.Add(student); }

        public override string ToString()
        {
            string ans = "";
            for (int i = 0; i < listStudents.Count; i++)
                ans += (i + 1).ToString() + ". " + listStudents[i].ToString() + "\n";
            return ans;
        }

        public int Count(Func<int, bool> f)
        {
            int count = 0;
            foreach (var stud in listStudents)
            {
                if (f(stud.Grade)) count++;
            }
            return count;
        }

        public int Count(Func<Stages, bool> f)
        {
            int count = 0;
            foreach (var stud in listStudents)
            {
                if (f(stud.Stage)) count++;
            }
            return count;
        }

        public int Count(Func<double, int, bool> f)
        {
            int count = 0;
            foreach (var stud in listStudents)
            {
                if (f(stud.Performance, stud.Grade)) count++;
            }
            return count;
        }

        public int Count(Func<string, bool> f)
        {
            int count = 0;
            foreach (var stud in listStudents)
            {
                if (f(stud.FIO)) count++;
            }
            return count;
        }

        public void Sort()
        {
            listStudents.Sort((x, y) => (x.FIO.CompareTo(y.FIO)));
        }
        public void Sort(Func<int, bool> f)
        {
            listStudents.Sort(delegate (Student x, Student y)
            {

                if (f(x.Grade) && f(y.Grade))
                    return x.FIO.CompareTo(y.FIO);
                else
                    return -1;
                    //return x.Grade.CompareTo(y.Grade);

            });
        }


    }
}
