using MedicalClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Infrastructure.EntitiesConfiguration
{
    class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure (EntityTypeBuilder<Exam> builder)
        {
            builder.HasIndex(e => new { e.Name, e.DeletedAt }, "UK_Exam_Name_DeletedAt")
                    .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("ExamId")
                .HasComment("Unique identifier for each medical exam");

            builder.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasComment("The date when the record  was logically deleted from the system");

            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Description of the exam");

            builder.Property(e => e.IsEnabled)
                .HasColumnName("IsEnabled ")
                .HasComment("Indicates if the record  is currently active in the system");

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("The name of the exam");

            builder.Property(e => e.Value)
                .HasColumnType("decimal(18, 6)")
                .HasComment("The Value of Exam");
        }
    }
}
