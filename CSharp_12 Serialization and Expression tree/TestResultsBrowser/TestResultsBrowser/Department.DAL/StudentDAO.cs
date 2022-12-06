using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace Department.DAL
{
    public class StudentDAO : IStudentDAO
    {
        private List<Student> students = new();

        public StudentDAO()
        {

        }

        public void Add(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            students.Add(student);
        }

        public IEnumerable<Student> GetList()
        {
            return students;
        }

        public void GetListFromFile(string filePath)
        {
            students = (List<Student>)XMLDeserialize(typeof(List<Student>), students, filePath);
        }

        public void SaveList(string filePath)
        {
            XMLSerialize(typeof(List<Student>), students, filePath);
        }

        public static void XMLSerialize(Type dataType, object data, string filePath)
        {
            XmlSerializer xmlSerializer = new(dataType);
            if (File.Exists(filePath)) File.Delete(filePath);
            TextWriter writer = new StreamWriter(filePath);
            xmlSerializer.Serialize(writer, data);
            writer.Close();
        }

        public static object XMLDeserialize(Type dataType, object data, string filePath)
        {
            object obj = null;
            XmlSerializer xmlSerializer = new(dataType);
            if (File.Exists(filePath))
            {
                TextReader txtReader = new StreamReader(filePath);
                obj = xmlSerializer.Deserialize(txtReader);
            }
            return obj;
        }
    }
}
