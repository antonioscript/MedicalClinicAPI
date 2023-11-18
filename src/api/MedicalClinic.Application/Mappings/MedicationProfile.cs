﻿using AutoMapper;
using MedicalClinic.Application.DTOs.Medication;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class MedicationProfile : Profile
    {
        public MedicationProfile()
        {
            CreateMap<Medication, MedicationResponse>();
            CreateMap<PaginatedResult<Medication>, PaginatedResult<MedicationResponse>>();
        }
    }
}
