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
    class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
    {
        public void Configure (EntityTypeBuilder<Availability> builder)
        {
            builder.ToTable("Availabilities");

            builder.HasComment("Stores information about the availability schedule for doctors.");

            builder.HasIndex(e => e.DoctorId, "IX_Availability_DoctorId");

            builder.Property(e => e.Id)
                .HasColumnName("AvailabilityId")
                .HasComment("Unique identifier for each availability entry.");

            builder.Property(e => e.DayOfWeek).HasComment("The day of the week when the doctor is available:\r\n0: Monday\r\n1: Tuesday\r\n2: Wednesday\r\n3: Thursday\r\n4: Friday\r\n5: Saturday\r\n6: Sunday");

            builder.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasComment("The date when the record  was logically deleted from the system");

            builder.Property(e => e.DoctorId).HasComment("Foreign key referencing the doctor associated with this availability");

            builder.Property(e => e.EndTime)
                .HasColumnType("time")
                .HasComment("The end time of the doctors availability for the specified day");

            builder.Property(e => e.IsEnabled)
                .HasColumnName("IsEnabled")
                .HasComment("Indicates if the record  is currently active in the system");

            builder.Property(e => e.StartTime)
                .HasColumnType("time")
                .HasComment("The start time of the doctors availability for the specified day.");

            builder.HasOne(d => d.Doctor)
                .WithMany(p => p.Availabilities)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Availability_Doctors");
        }
    }
}
