using MedicalClinic.Domain.Entities;
using MedicalClinic.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Infrastructure.EntitiesConfiguration
{
    class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure (EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasComment("he RefreshTokens table is designed to store information related to refresh tokens used in token-based authentication systems");

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasComment("Unique identifier for each RefreshToken in the system");

            builder.Property(e => e.UserId)
                .IsUnicode(false)
                .HasComment("A string representing the unique identifier of the user associated with the refresh token.");

            builder.Property(e => e.Token)
                .IsUnicode(false)
                .HasComment("A string storing the refresh token itself.");

            builder.Property(e => e.JwtId)
                .IsUnicode(false)
                .HasComment("A string representing the unique identifier of the associated JWT (JSON Web Token).");

            builder.Property(e => e.IsUsed)
                .HasColumnName("IsUsed")
                .HasComment("A boolean flag indicating whether the refresh token has been used.");

            builder.Property(e => e.IsRevoked)
                .HasColumnName("IsRevoked")
                .HasComment("A boolean flag indicating whether the refresh token has been revoked.");

            builder.Property(e => e.AddedDate)
                .HasColumnType("datetime2")
                .HasComment("A datetime value representing the date and time when the refresh token was added to the database");

            builder.Property(e => e.ExpiryDate)
                .HasColumnType("datetime2")
                .HasComment("A datetime value representing the expiration date and time of the refresh token.");
        }
    }
}
