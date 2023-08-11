using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Exam
{
    public class ExamRequestFilter
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Value { get; set; }

        public bool IsEnabled { get; set; }

    }
}
