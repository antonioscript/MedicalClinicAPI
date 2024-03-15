using AutoMapper;
using MediatR;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Rules;
using MedicalClinic.Application.Interfaces.Shared;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Resource.Resources;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Prescriptions.SpecificCommands
{
    public partial class CreatePdfPrescriptionCommand : IRequest<Result<string>>
    {
        public int AppointmentId { get; set; }
    }


    public class CreatePdfPrescriptionCommandHandler : IRequestHandler<CreatePdfPrescriptionCommand, Result<string>>
    {
        private readonly IDocumentProcessor _documentProcessor;
        private readonly IPrescriptionRules _prescriptionRules;
        private readonly IAppointmentRepository _appointmentRepository;

        public CreatePdfPrescriptionCommandHandler( IPrescriptionRules prescriptionRules, IDocumentProcessor documentProcessor, IAppointmentRepository appointmentRepository)
        {
            _prescriptionRules = prescriptionRules;
            _documentProcessor = documentProcessor;
            _appointmentRepository = appointmentRepository;

        }

        public async Task<Result<string>> Handle(CreatePdfPrescriptionCommand command, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.Entities
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(d => d.Id == command.AppointmentId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (appointment == null)
            {
                return Result<string>.Fail(string.Format(SharedResource.MESSAGE_PRESCRIPTION_NOT_FOUND, command.AppointmentId));
            }
            else
            {
                string templateFilePath = @"C:\Projects\MedicalClinicAPI\docs\2.DocumentProcessor\00.TemplateMedicalPrescriptions\MedicalPrescritionTemplate.docx";
                string saveAspath = @"C:\Projects\MedicalClinicAPI\docs\2.DocumentProcessor\01.MedicalPrescriptionsPDF\";

                string documentName = _prescriptionRules.GetDocumentNameForPrescription(appointment);
                Dictionary<string, string> documentProperties = await _prescriptionRules.GetPropertiesMedicalPrescriptionPdf(appointment);
                string textFooter = _prescriptionRules.GetFooterMedicalPrescriptionPdf(appointment);

                string result = await _documentProcessor.CreateDocumentPdf(templateFilePath, documentName, saveAspath, documentProperties, textFooter);

                return Result<string>.Success(result);
            }
        }
    }
}
