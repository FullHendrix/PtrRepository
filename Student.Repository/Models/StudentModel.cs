using Student.Repository.Contratos;
using Student.Repository.Models.DTO;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Student.Repository.Models
{
    public class StudentModel
    {
        IStudentRepository _studentRepository;
        public Guid IdStudent { get; private set; }
        public string Names { get; private set; }
        public string LastNames { get; private set; }
        public string DocumentType { get; private set; }
        public string DocumentNumber { get; private set; }
        public DateTime DateBirth { get; private set; }
        public StudentModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public StudentModel()
        {
        }
        public void Set(StudentDTO studentDTO)
        {
            if (!IdStudent.Equals(Guid.Empty))
                throw new Exception("This object has been initialized");
            this.Names = studentDTO.Names;
            this.LastNames = studentDTO.LastNames;
            this.DocumentType = studentDTO.DocumentType;
            this.DocumentNumber = studentDTO.DocumentNumber;
            this.DateBirth = DateTime.Parse(studentDTO.DateBirth);
        }
        public StudentDTO Save()
        {
            this.IdStudent = Guid.NewGuid();
            var student = _studentRepository.Save(this);
            var studentDTO = new StudentDTO()
            {
                IdStudent = student.IdStudent.ToString(),
                Names = student.Names,
                LastNames = student.LastNames,
                DocumentType = student.DocumentType,
                DocumentNumber = student.DocumentNumber,
                DateBirth = student.DateBirth.ToShortDateString(),
            };
            return studentDTO;
        }
        public List<StudentDTO> List()
        {
            var r = from d in _studentRepository.List()
                    select new StudentDTO
                    {
                        IdStudent = d.IdStudent.ToString(),
                        Names = d.Names,
                        LastNames = d.LastNames,
                        DocumentType = d.DocumentType,
                        DocumentNumber = d.DocumentNumber,
                        DateBirth = d.DateBirth.ToShortDateString()
                    };
            return r.ToList();
        }
        public StudentDTO Select(Guid IdStudent )
        {
            var student = _studentRepository.Select(IdStudent);
            var studentDTO = new StudentDTO()
            {
                IdStudent = student.IdStudent.ToString(),
                Names = student.Names,
                LastNames = student.LastNames,
                DocumentType = student.DocumentType,
                DocumentNumber = student.DocumentNumber,
                DateBirth = student.DateBirth.ToShortDateString(),
            };
            return studentDTO;
        }
    }
}