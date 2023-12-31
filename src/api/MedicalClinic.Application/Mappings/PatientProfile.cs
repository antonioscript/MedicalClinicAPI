﻿using AutoMapper;
using MedicalClinic.Application.DTOs.Patient;
using MedicalClinic.Application.Features.Patients.Commands;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Mappings
{
    internal class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<CreatePatientCommand, Patient>();

            CreateMap<Patient, PatientResponse>();
            CreateMap<PaginatedResult<Patient>, PaginatedResult<PatientResponse>>();
        }
    }
}
