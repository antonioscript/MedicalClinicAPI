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
    class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
    {
        public void Configure (EntityTypeBuilder<Procedure> builder)
        {
            builder.HasComment("Stores information about medical procedures and exams performed on patients");

            builder.HasIndex(e => e.ExamId, "IX_Procedures_ExamId");

            builder.HasIndex(e => e.PatientId, "IX_Procedures_PatientId");

            builder.HasIndex(e => e.TechnicianId, "IX_Procedures_TechnicianId");

            builder.Property(e => e.Id)
                .HasColumnName("ProcedureId")
                .HasComment("Unique identifier for each medical procedure");

            builder.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasComment("The date when the record  was logically deleted from the system");

            builder.Property(e => e.ExamId).HasComment("Foreign key referencing the unique identifier of the exam associated with the procedure");

            builder.Property(e => e.IsEnabled)
                .HasColumnName("IsEnabled ")
                .HasComment("Indicates if the record  is currently active in the system");

            builder.Property(e => e.Observation)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Additional observation or notes related to the procedure");

            builder.Property(e => e.ProcedureDate)
                .HasColumnType("datetime")
                .HasComment("The date of Procedure");

            builder.Property(e => e.Status).HasComment("Indicates the Status of the Procedure, being:\r\n0:Scheduled\r\n1:Confirmed\r\n2: Cancelled\r\n3: Completed");

            builder.Property(e => e.PatientId).HasComment("Foreign key referencing the unique identifier of the patient associated with the procedure");

            builder.Property(e => e.TechnicianId).HasComment("Foreign key referencing the unique identifier of the technician performing the procedure");

            builder.HasIndex(e => new { e.ProcedureDate }, "UK_Procedures_ProcedureDate")
                .IsUnique();

            builder.HasOne(d => d.Exam)
                .WithMany(p => p.Procedures)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Procedures_Exams");

            builder.HasOne(d => d.Patient)
                .WithMany(p => p.Procedures)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Procedures_Patients");

            builder.HasOne(d => d.Technician)
                .WithMany(p => p.Procedures)
                .HasForeignKey(d => d.TechnicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Procedures_Technicians");
        }
    }
}
