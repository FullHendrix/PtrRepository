using System;
namespace Student.Repository.Models.DTO
{
    public class StudentDTO
    {
        public string IdStudent { get;  set; }
        public string Names { get;  set; }
        public string LastNames { get;  set; }
        public string DocumentType { get;  set; }
        public string DocumentNumber { get;  set; }
        public string DateBirth { get;  set; }
    }
}
