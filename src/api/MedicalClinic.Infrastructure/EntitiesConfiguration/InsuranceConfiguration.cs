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
    //TODO: Colocar a Tabela Insurance no Plural no Banco de Dados 
    class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
    {
        public void Configure (EntityTypeBuilder<Insurance> builder)
        {
            builder.ToTable("Insurance");

            builder.HasComment("Stores information about health insurance plans or medical health plans");

            builder.HasIndex(e => new { e.Name, e.DeletedAt }, "UK_Insurance_Name_DeletedAt")
                .IsUnique();

            builder.Property(e => e.InsuranceId).HasComment("nique identifier for each health insurance plan");

            builder.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasComment("The date when the record  was logically deleted from the system");

            builder.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Description of the health insurance plan");

            builder.Property(e => e.IsEnabled)
                .HasColumnName("IsEnabled ")
                .HasComment("Indicates if the record  is currently active in the system");

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("The name of the health insurance plan");

            builder.Property(e => e.PercentageTypeOne)
                .HasColumnType("decimal(18, 6)")
                .HasComment("A percentage value related to the health insurance plan");

            builder.Property(e => e.PercentageTypeThree)
                .HasColumnType("decimal(18, 6)")
                .HasComment("Another percentage value related to the health insurance plan");

            builder.Property(e => e.PercentageTypeTwo)
                .HasColumnType("decimal(18, 6)")
                .HasComment("Another percentage value related to the health insurance plan");
        }
    }
}
