using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Repository.Models;
namespace Student.Repository.EF.Configuration
{
    class StudentModelConfiguration : IEntityTypeConfiguration<StudentModel>
    {
        public void Configure(EntityTypeBuilder<StudentModel> builder)
        {
            builder.ToTable("Students").HasKey(x => x.IdStudent);
            builder.Property(x => x.Names);
            builder.Property(x => x.LastNames);
            builder.Property(x => x.DocumentType);
            builder.Property(x => x.DocumentNumber);
            builder.Property(x => x.DateBirth);
        }
    }
}
