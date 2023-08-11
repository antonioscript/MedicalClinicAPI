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
    class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure (EntityTypeBuilder<Appointment> builder)
        {
            builder.HasComment("Stores information about medical appointments or consultations");

            builder.HasIndex(e => e.DoctorId, "IX_Appointments_DoctorId");

            builder.HasIndex(e => e.PatientId, "IX_Appointments_Patientid");

            builder.Property(e => e.Id)
                .HasColumnName("AppointmentId")
                .HasComment("Unique identifier for each medical appointment");

            builder.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasComment("The date when the record  was logically deleted from the system");

            builder.Property(e => e.DoctorId)
                .HasColumnName("DoctorId")
                .HasComment("Foreign key referencing the unique identifier of the doctor associated with the appointment");

            builder.Property(e => e.IsEnabled)
                .HasColumnName("IsEnabled ")
                .HasComment("Indicates if the record  is currently active in the system");

            builder.Property(e => e.Observation)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Additional observation or notes related to the appointment");

            builder.Property(e => e.PatientId)
                .HasColumnName("PatientId")
                .HasComment("Foreign key referencing the unique identifier of the patient associated with the appointment");

            builder.Property(e => e.Status).HasComment("Indicates the Status of the Query, being:\r\n0:Scheduled\r\n1:Confirmed\r\n2: Cancelled");

            builder.HasOne(d => d.Doctor)
                .WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Doctors");

            builder.HasOne(d => d.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Patients");
        }
    }
}
