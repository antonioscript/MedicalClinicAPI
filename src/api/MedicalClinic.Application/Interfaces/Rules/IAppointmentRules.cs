using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Interfaces.Rules
{
    public interface IAppointmentRules
    {
        Task MarkAppointmentAsDone(int appointmentId, CancellationToken cancellationToken);
    }
}
