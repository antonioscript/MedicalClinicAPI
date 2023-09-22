using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Domain.Enums
{
    public enum AvailabilityDayOfWeekCode : byte
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }

    /// <summary>
    /// The day of the week when the doctor is available:
    /// 0: Monday
    /// 1: Tuesday
    /// 2: Wednesday
    /// 3: Thursday
    /// 4: Friday
    /// 5: Saturday
    /// 6: Sunday
    /// </summary>
}

