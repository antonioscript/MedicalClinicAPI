using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Domain.Enums
{
    public enum StatusCode : byte
    {
        Scheduled = 0,
        Confirmed = 1,
        Cancelled = 2,
        Completed = 3
    }

    /// <summary>
    /// Indicates the Status of the Query, being:
    /// 0:Scheduled
    /// 1:Confirmed
    /// 2: Cancelled
    /// </summary>
}

