using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.BLL
{
    interface IStudentsBL
    {
        IEnumerable<Student> InitList();
        IEnumerable<Student> GetList();
        void Add(Student student);
        IEnumerable<Student> FilterStudentsByFilterBuilder(FilterBuilder<Student, string> filter);
        IEnumerable<Student> FilterStudentsByFilterBuilder(FilterBuilder<Student, int> filter);
    }
}
