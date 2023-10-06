using MedicalClinic.Application.DTOs.Procedure;

namespace MedicalClinic.Application.DTOs.Exam
{
    public class ExamResponse
    {
        public ExamResponse()
        {
            Procedures = new HashSet<ProcedureResponse>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Value { get; set; }

        public bool IsEnabled { get; set; }

        public virtual ICollection<ProcedureResponse> Procedures { get; set; }
    }
}
