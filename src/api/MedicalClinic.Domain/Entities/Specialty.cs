using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    //TODO: O nome da classe 'Specialty' está incorreto, ajeitar
    public partial class Specialty
    {
        public Specialty()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal ConsultationValue { get; set; }

        public bool IsEnabled { get; set; }
        public DateTime? DeletedAt { get; set; }


        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
