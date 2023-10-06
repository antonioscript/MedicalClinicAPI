using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class Insurance
    {
        public Insurance()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public double PercentageTypeOne { get; set; }
        public double PercentageTypeTwo { get; set; }
        public double PercentageTypeThree { get; set; }

        public bool IsEnabled { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
