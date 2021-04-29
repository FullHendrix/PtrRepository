using Student.Repository.Contratos;
using Student.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Student.Repository.EF.SQLS
{
    public class StudentSQLSRepository : IStudentRepository
    {
        StudentDBContext _StudentContext;
        public StudentSQLSRepository(StudentDBContext StudentContext)
        {
            _StudentContext = StudentContext;
        }
        public StudentModel Save(StudentModel studentModel)
        {
            if (_StudentContext.Student.Any(x => x.IdStudent.Equals(studentModel.IdStudent)))
                throw new Exception("This student has been already created");
            _StudentContext.Student.Add(studentModel);
            _StudentContext.SaveChanges();
            return studentModel;
        }
        public List<StudentModel> List()
        {
            return _StudentContext.Student.ToList();
        }

        public StudentModel Select(Guid IdStudent)
        {
            return _StudentContext.Student.SingleOrDefault(x => x.IdStudent.Equals(IdStudent));
        }
    }
}