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
    class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure (EntityTypeBuilder<Prescription> builder)
        {
            builder.HasComment
                    ("This table is structured to capture details about medical prescriptions, associating them with specific patients and doctors, " +
                    "recording the date of issuance and expiration, and providing space for any additional notes or instructions associated with the prescription.");

            builder.HasIndex(e => new { e.AppointmentId }, "UK_Prescription_AppointmentId")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("PrescriptionId")
                .HasComment("A unique identifier for each prescription.");

            builder.Property(e => e.AppointmentId)
                .HasColumnName("AppointmentId")
                .HasComment("An identifier that associates this prescription with a specific appointment or medical visit.");

            builder.Property(e => e.Observation)
                .HasColumnName("Observation")
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("A field used to store observations or notes related to the prescription.");

            builder.HasOne(d => d.Appointment)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Appointments");
        }
    }
}
