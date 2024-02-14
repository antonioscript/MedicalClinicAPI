using AutoMapper;
using MediatR;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Rules;
using MedicalClinic.Application.Interfaces.Shared;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Features.Appointments.Commands
{
    public partial class CreatePdfAppointmentCommand : IRequest<Result<string>>
    {
        public int AppointmentId { get; set; }
    }


    public class CreatePdfAppointmentCommandHandler : IRequestHandler<CreatePdfAppointmentCommand, Result<string>>
    {
        private readonly IAppointmentRepository _repository;
        private readonly IDocumentProcessor _documentProcessor;
        private readonly IAppointmentRules _appointmentRules;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreatePdfAppointmentCommandHandler(IAppointmentRepository repository, IAppointmentRules appointmentRules, IDocumentProcessor documentProcessor, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _appointmentRules = appointmentRules;
            _documentProcessor = documentProcessor;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<string>> Handle(CreatePdfAppointmentCommand request, CancellationToken cancellationToken)
        {
            var templateFilePath = @"C:\Projects\MedicalClinicAPI\docs\2.DocumentProcessor\00.TemplateMedicalPrescriptions\MedicalPrescritionTemplate.docx";
            var fileName = "FirstDoc.docx";
            var saveAspath = @"C:\Projects\MedicalClinicAPI\docs\2.DocumentProcessor\01.MedicalPrescriptionsPDF\";

            // Palavras para substituição
            string doctorName = "Dr. John Doe";
            string patientName = "Jane Doe";
            string consultValue = "$100.00";


            var documentProperties = new Dictionary<string, string>();
            documentProperties.Add("MD_DOCTOR_NAME", doctorName);
            documentProperties.Add("MD_PATIENT_NAME", patientName);
            documentProperties.Add("MD_VALOR", consultValue);


            var result = await _documentProcessor.CreateDocumentMedicalPrescription(templateFilePath, fileName, saveAspath, documentProperties);

            return Result<string>.Success(result);
        }
    }
}
