using MedicalClinic.Application.DTOs.Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Technician
{
    public class TechnicianResponse
    {
        public TechnicianResponse()
        {
            Procedures = new HashSet<ProcedureResponse>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }
        public byte? InsuranceType { get; set; }

        public bool IsEnabled { get; set; }

        public virtual ICollection<ProcedureResponse> Procedures { get; set; }
    }
}
