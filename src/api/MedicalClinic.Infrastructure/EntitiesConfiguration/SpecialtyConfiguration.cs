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
    //TODO: O nome da classe está incorreto, ajeitar
    class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure (EntityTypeBuilder<Specialty> builder)
        {
            builder.HasComment("Stores information about medical specialties");

            builder.HasIndex(e => new { e.Name, e.DeletedAt }, "UK_Speciality_Name_DeletedAt")
                .IsUnique();

            builder.Property(e => e.SpecialtyId).HasComment("Unique identifier for each medical specialty");

            builder.Property(e => e.ConsultationValue)
                .HasColumnType("decimal(18, 6)")
                .HasComment("Value of Consultation ");

            builder.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasComment("The date when the record  was logically deleted from the system");

            builder.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("escription of the medical specialty");

            builder.Property(e => e.IsEnabled)
                .HasColumnName("IsEnabled ")
                .HasComment("Indicates if the record  is currently active in the system");

            builder.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasComment("The name of the medical specialty");
        }
    }
}
