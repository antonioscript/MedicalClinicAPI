using MedicalClinic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Interfaces.Rules
{
    public interface IPrescriptionRules
    {
        Task<Dictionary<string, string>> GetPropertiesMedicalPrescriptionPdf(int appointmentId);

        Task<string> GetFooterMedicalPrescriptionPdf(int appointmentId);
    }
}
