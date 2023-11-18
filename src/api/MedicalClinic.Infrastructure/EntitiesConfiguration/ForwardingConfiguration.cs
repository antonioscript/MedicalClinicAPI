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
    class ForwardingConfiguration : IEntityTypeConfiguration<Forwarding>
    {
        public void Configure (EntityTypeBuilder<Forwarding> builder)
        {
            builder.HasComment("The table is structured to capture details about medical referrals, linking them to specific prescriptions, associating them with medical specialties, and providing space for additional observations or notes.");

            builder.Property(e => e.Id)
                .HasColumnName("ForwardingId")
                .HasComment("A unique identifier for each medical record forwarding activity.");

            builder.Property(e => e.PrescriptionId)
                .HasColumnName("PrescriptionId")
                .HasComment("An identifier that associates this Fowarding with a specific prescription. It establishes a relationship between Fowardings and the prescriptions in which they are prescribed.");

            builder.Property(e => e.SpecialtyId)
               .HasColumnName("SpecialtyId")
               .HasComment("FK of SPecialty");

            builder.Property(e => e.Observation)
                .HasColumnName("Observation")
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasComment("A field used to store observations or notes related to the fowarding.");

            builder.HasOne(d => d.Prescription)
                .WithMany(p => p.Forwardings)
                .HasForeignKey(d => d.PrescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Forwarding_Prescriptions");

            builder.HasOne(d => d.Specialty)
                .WithMany(p => p.Forwardings)
                .HasForeignKey(d => d.SpecialtyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Forwarding_Specialties");
        }
    }
}
