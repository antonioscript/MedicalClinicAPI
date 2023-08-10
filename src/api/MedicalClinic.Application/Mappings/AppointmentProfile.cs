﻿using AutoMapper;
using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Mappings
{
    internal class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentResponse>();
        }
    }
}