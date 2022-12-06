using Department.DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Serialization;

namespace Department.BLL
{
    public class StudentsBL : IStudentsBL
    {
        private readonly IStudentDAO studentsDAO;
        public StudentsBL(IStudentDAO studentDAO)
        {
            studentsDAO = studentDAO;
        }

        public IEnumerable<Student> InitList()
        {
            Add(new Student()
            {
                Name = "Mike",
                Surname = "Peterson",
                Test = "Biology",
                Date = new DateTime(2021, 05, 08),
                Score = 5
            });
            return GetList();
        }

        public IEnumerable<Student> GetList()
        {
            return studentsDAO.GetList();
        }

        public void Add(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            studentsDAO.Add(student);
        }

        public void Add(string name, string surname, string test, DateTime testDate, int score)
        {
            Student student = new Student
            {
                Name = name,
                Surname = surname,
                Test = test,
                Date = testDate,
                Score = score,
            };
            this.Add(student);
        }

        public IEnumerable<Student> FilterStudentsByFilterBuilder(FilterBuilder<Student, string> filter)
        {
            var listToFilter = studentsDAO.GetList();
            Expression<Func<Student, bool>> exp = FilterBuilder<Student, string>.GetStringExpression();
            return FilterBuilder<Student, string>.Apply((List<Student>)listToFilter, exp);
        }

        public IEnumerable<Student> FilterStudentsByFilterBuilder(FilterBuilder<Student, int> filter)
        {
            var listToFilter = studentsDAO.GetList();
            Expression<Func<Student, bool>> exp = FilterBuilder<Student, int>.GetNumericExpression();
            return FilterBuilder<Student, int>.Apply((List<Student>)listToFilter, exp);
        }

        public IEnumerable<Student> FilterStudentsByFilterBuilder(FilterBuilder<Student, DateTime> filter)
        {
            var listToFilter = studentsDAO.GetList();
            Expression<Func<Student, bool>> exp = FilterBuilder<Student, DateTime>.GetNumericExpression();
            return FilterBuilder<Student, DateTime>.Apply((List<Student>)listToFilter, exp);
        }

        public void GetListFromFile(string filePath)
        {
            studentsDAO.GetListFromFile(filePath);
        }

        public void SaveList(string filePath)
        {
            studentsDAO.SaveList(filePath);
        }
    }
}
