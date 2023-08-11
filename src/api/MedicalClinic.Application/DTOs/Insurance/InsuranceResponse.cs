using MedicalClinic.Application.DTOs.Patient;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Insurance
{
    public class InsuranceResponse
    {
        public InsuranceResponse()
        {
            Patients = new HashSet<PatientResponse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        //TODO: To Alter Propoerties to double
        public decimal PercentageTypeOne { get; set; }
        public decimal PercentageTypeTwo { get; set; }
        public decimal PercentageTypeThree { get; set; }

        public bool IsEnabled { get; set; }

        public virtual ICollection<PatientResponse> Patients { get; set; }
    }
}
