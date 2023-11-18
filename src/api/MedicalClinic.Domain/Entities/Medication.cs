using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class Medication
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string? SubstituteOne { get; set; }
        public string? SubstituteTwo { get; set; }
        public string Instruction { get; set; } = null!;
    }
}
