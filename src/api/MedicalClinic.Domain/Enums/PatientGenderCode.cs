using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Domain.Enums
{
    public enum PatientGenderCode : byte
    {
        Male = 0,
        Female = 1,
        NonBinary = 2
    }

    /// <summary>
    /// The gender of the patient
    /// 0: Male, 
    /// 1: Female,
    /// 2: NonBinary
    /// </summary>
}

