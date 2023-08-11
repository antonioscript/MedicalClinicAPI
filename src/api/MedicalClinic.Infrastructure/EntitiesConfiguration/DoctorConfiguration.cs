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
    class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure (EntityTypeBuilder<Doctor> builder)
        {
            builder.HasComment("Stores information about medical doctors, their specialties, and contact details.");

            builder.HasIndex(e => new { e.Crm, e.DeletedAt }, "UK_Doctor_Crm_DeletedAt")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("DoctorId")
                .HasComment("Unique identifier for each doctor in the system");

            builder.Property(e => e.AddressLineOne)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("The address of the doctor");

            builder.Property(e => e.AddressLineTwo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("The address of the doctor");

            builder.Property(e => e.Crm)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("The CRM (Conselho Regional de Medicina) number of the doctor");

            builder.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasComment("The date when the record  was logically deleted from the system");

            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("The email address of the doctor.");

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("The first name of the doctor.");

            builder.Property(e => e.IsEnabled)
                .HasColumnName("IsEnabled ")
                .HasComment("Indicates if the record  is currently active in the system");

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment(" The last name or surname of the doctor");

            builder.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("The phone number of the doctor.");

            builder.Property(e => e.SpecialtyId).HasComment("Unique identifier for each medical specialty");

            builder.HasOne(d => d.Specialty)
                .WithMany(p => p.Doctors)
                .HasForeignKey(d => d.SpecialtyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctors_Specialties");
        }
    }
}
