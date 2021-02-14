﻿using DataAccessXamarin;
using proj.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace proj.Repositories
{
    class StudentRepository
    {
        SQLiteConnection connection;

        public StudentRepository()
        {
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            connection.CreateTable<Student>();


        }
        public int AddStudent(Student student)
        {

          //connection.Execute("INSERT INTO Student VALUES");
            int rows = connection.Insert(student);
            return rows;

        }
        public List<Student> GetStudntByFilier(int  filierid)
        {

            //connection.Execute("INSERT INTO Student VALUES");
            var ss = connection.Query<Student>($"SELECT * FROM Student  WHERE IdFiliere='{filierid}'");
            return ss;

        }
        public IEnumerable<Student> GetStudent()
        {
            return (from u in connection.Table<Student>()
                    select u).ToList();
        }
        public Student GetStudntByid(int idLStudent)
        {
            return connection.Table<Student>().FirstOrDefault(std => std.IdStudent == idLStudent);
          

        }

        
    }
}


