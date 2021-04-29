using Student.Repository.Models;
using System;
using System.Collections.Generic;

namespace Student.Repository.Contratos
{
    public interface IStudentRepository
    {
        StudentModel Save(StudentModel studentModel);
        List<StudentModel> List();
        StudentModel Select(Guid IdStudent);
    }
}