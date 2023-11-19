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
    class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure (EntityTypeBuilder<Medication> builder)
        {
            builder.HasComment("The table is structured to facilitate the management and tracking of prescribed medications, including details about potential substitutes and specific usage instructions.");

            builder.Property(e => e.Id)
                .HasColumnName("MedicationId")
                .HasComment("A unique identifier for each medication, allowing for easy reference and linkage to prescriptions.");

            builder.Property(e => e.PrescriptionId)
                .HasColumnName("PrescriptionId")
                .HasComment("An identifier that associates this medication with a specific prescription. It establishes a relationship between medications and the prescriptions in which they are prescribed.");

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("The name of the medication being prescribed.");

            builder.Property(e => e.SubstituteOne)
                .HasColumnName("SubstituteOne")
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment(" field used to record the name of the first substitute medication, if applicable");

            builder.Property(e => e.SubstituteTwo)
                .HasColumnName("SubstituteTwo")
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("A field used to record the name of the second substitute medication, if applicable.");

            builder.Property(e => e.Instruction)
                .HasColumnName("Instruction")
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Instructions related to the medication. This field provides guidance on how the medication should be taken, including dosage, frequency, and any additional directions");

            builder.HasOne(d => d.Prescription)
                .WithMany(p => p.Medications)
                .HasForeignKey(d => d.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Medication_Prescriptions");
        }
    }
}
