using Microsoft.EntityFrameworkCore;
using Student.Repository.EF.Configuration;
using Student.Repository.Models;
namespace Student.Repository.EF
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options):base(options) { }
        public DbSet<StudentModel> Student { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration (new StudentModelConfiguration());
        }
    }
}