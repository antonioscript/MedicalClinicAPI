using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class Exam
    {
        public Exam()
        {
            Procedures = new HashSet<Procedure>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Value { get; set; }

        public bool IsEnabled { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Procedure> Procedures { get; set; }
    }
}
