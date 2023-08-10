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
    class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure (EntityTypeBuilder<Patient> builder)
        {
            builder.HasComment("Stores information about patients and their medical records.");

            builder.HasIndex(e => new { e.Document, e.DeletedAt }, "UK_Patient_Document_DeletedAt")
                .IsUnique();

            builder.Property(e => e.PatientId).HasComment("Patients table unique identifier");

            builder.Property(e => e.AddressLineOne)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("The address line one of the patient.");

            builder.Property(e => e.AddressLineTwo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("The address line two of the patient.");

            builder.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("DateOfBirth ")
                .HasComment("The date of birth of the patient");

            builder.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasComment("The date when the record  was logically deleted from the system");

            builder.Property(e => e.Document)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Document of Patient");

            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("The email address of the patient.");

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("The  name of the patient");

            builder.Property(e => e.Gender).HasComment("The gender of the patient\r\n0: Male, \r\n1: Female,\r\n2: NonBinary");

            builder.Property(e => e.InsuranceId).HasComment("Foreign key referencing the unique identifier of the insurance plan associated with the procedure");

            builder.Property(e => e.InsuranceType).HasComment("Type of Insurance");

            builder.Property(e => e.IsEnabled)
                .HasColumnName("IsEnabled ")
                .HasComment("Indicates if the record  is currently active in the system");

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("The last name  of the patient");

            builder.Property(e => e.PhoneOne)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("The phone one  number of the patient.");

            builder.Property(e => e.PhoneTwo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("The phone two  number of the patient.");

            builder.HasOne(d => d.Insurance)
                .WithMany(p => p.Patients)
                .HasForeignKey(d => d.InsuranceId)
                .HasConstraintName("FK_Patients_Insurance");
        }
    }
}
