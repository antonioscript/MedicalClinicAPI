using MedicalClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalClinic.Infrastructure.EntitiesConfiguration
{
    class DocumentParameterConfiguration : IEntityTypeConfiguration<DocumentParameter>
    {
        public void Configure (EntityTypeBuilder<DocumentParameter> builder)
        {
            builder.HasComment("The table is structured to capture details about medical referrals, linking them to specific prescriptions, associating them with medical specialties, and providing space for additional observations or notes.");

            builder.Property(e => e.Id)
                .HasColumnName("DocumentParameterId")
                .HasComment("Identificador único da tabela DocumentConfiguration");

            builder.Property(e => e.LocalizationDocumentInput)
                .HasColumnName("LocalizationDocumentInput")
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Location of the input template for document creation");

            builder.Property(e => e.LocalizationDocumentOutput)
                .HasColumnName("LocalizationDocumentInput")
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Location of the newly generated document");

            builder.Property(e => e.LocalizationLibreOffice)
                .HasColumnName("LocalizationDocumentInput")
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Location of the Libre Office configuration file");

            builder.Property(e => e.DocumentType)
                .HasColumnName("DocumentType")
                .HasComment("Type of document:\r\n0: Prescription\r\n1: Procedures");

            builder.HasIndex(e => new { e.LocalizationDocumentInput, e.LocalizationDocumentOutput, e.LocalizationLibreOffice, e.DocumentType }, "UK_DocumentParameter")
                .IsUnique();
        }
    }
}
