﻿using System;
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

        //TODO: To Alter Propoerties to double
        public decimal PercentageTypeOne { get; set; }
        public decimal PercentageTypeTwo { get; set; }
        public decimal PercentageTypeThree { get; set; }

        public bool IsEnabled { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
