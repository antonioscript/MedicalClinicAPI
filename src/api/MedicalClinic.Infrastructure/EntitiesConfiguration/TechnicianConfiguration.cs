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
    class TechnicianConfiguration : IEntityTypeConfiguration<Technician>
    {
        public void Configure (EntityTypeBuilder<Technician> builder)
        {
            builder.HasComment("Stores information about technicians or technical staff");

            builder.Property(e => e.Id)
                .HasColumnName("TechnicianId")
                .HasComment("Unique identifier for each Technician");

            builder.Property(e => e.AddressLineOne)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("The address line one  of the patient.");

            builder.Property(e => e.AddressLineTwo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("The address line two of the patient.");

            builder.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasComment("The date when the record  was logically deleted from the system");

            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("The email address of the technician");

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("The first name of the technician");

            builder.Property(e => e.InsuranceType).HasComment("Type of Insurance");

            builder.Property(e => e.IsEnabled)
                .HasColumnName("IsEnabled ")
                .HasComment("Indicates if the record  is currently active in the system");

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("The last name or surname of the technician");

            builder.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("The phone number of the technician");

            builder.HasIndex(e => new { e.FirstName, e.LastName }, "UK_Technicians_FirstName_LastName")
                .IsUnique();
        }
    }
}
