using AutoMapper;
using MedicalClinic.Application.DTOs.Identity;
using MedicalClinic.Domain.Entities.Identity;

namespace MedicalClinic.Application.Mappings
{
    internal class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<RefreshToken, RefreshTokenResponse>();
        }
    }
}
