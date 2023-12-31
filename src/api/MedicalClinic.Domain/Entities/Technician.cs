﻿using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class Technician
    {
        public Technician()
        {
            Procedures = new HashSet<Procedure>();
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
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Procedure> Procedures { get; set; }
    }
}
