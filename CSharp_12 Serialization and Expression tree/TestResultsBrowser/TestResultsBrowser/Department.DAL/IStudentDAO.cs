using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.DAL
{
    public interface IStudentDAO
    {
        void Add(Student student);
        IEnumerable<Student> GetList();
        void GetListFromFile(string filePath);
        void SaveList(string filePath);
    }
}
