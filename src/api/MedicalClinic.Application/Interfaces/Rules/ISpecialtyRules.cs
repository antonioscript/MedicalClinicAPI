using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Interfaces.Rules
{
    public interface ISpecialtyRules
    {
        Task CheckAppointmentDurationIsValid(int appointmentDuration);
    }
}
