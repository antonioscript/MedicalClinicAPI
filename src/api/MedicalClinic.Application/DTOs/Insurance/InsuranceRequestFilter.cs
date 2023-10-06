using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Insurance
{
    public class InsuranceRequestFilter
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; }

        public double? PercentageTypeOne { get; set; }
        public double? PercentageTypeTwo { get; set; }
        public double? PercentageTypeThree { get; set; }

        public bool? IsEnabled { get; set; }
    }
}
