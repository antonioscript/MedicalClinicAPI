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
    class CanceledAppointmentConfiguration : IEntityTypeConfiguration<CanceledAppointment>
    {
        public void Configure (EntityTypeBuilder<CanceledAppointment> builder)
        {
            builder.HasComment("Table tracks canceled medical appointments, capturing details such as appointment and cancellation dates");

            builder.HasIndex(e => new { e.AppointmentId }, "UK_CanceledAppointment_AppointmentId")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("CanceledAppointmentId")
                .HasComment("Unique identifier for each canceled appointment");

            builder.Property(e => e.AppointmentId)
                .HasColumnName("AppointmentId")
                .HasComment("Unique identifier for  appointment");

            builder.Property(e => e.ReasonCancellation)
                .HasColumnName("ReasonCancellation")
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Reason for the cancellation of the appointment");

            builder.Property(e => e.CancellationDate)
                .HasColumnName("CancellationDate")
                .HasColumnType("datetime")
                .HasComment("Date when the appointment was canceled");

            builder.HasOne(d => d.Appointment)
                .WithMany(p => p.CanceledAppointments)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CanceledAppointments_Specialties");
        }
    }
}
