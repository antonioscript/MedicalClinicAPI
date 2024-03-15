using AutoMapper;
using MediatR;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Rules;
using MedicalClinic.Application.Interfaces.Shared;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

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

        public CreatePdfPrescriptionCommandHandler( IPrescriptionRules prescriptionRules, IDocumentProcessor documentProcessor)
        {
            _prescriptionRules = prescriptionRules;
            _documentProcessor = documentProcessor;

        }

        public async Task<Result<string>> Handle(CreatePdfPrescriptionCommand request, CancellationToken cancellationToken)
        {
            string templateFilePath = @"C:\Projects\MedicalClinicAPI\docs\2.DocumentProcessor\00.TemplateMedicalPrescriptions\MedicalPrescritionTemplate.docx";
            string fileName = "FirstDoc.docx";
            string saveAspath = @"C:\Projects\MedicalClinicAPI\docs\2.DocumentProcessor\01.MedicalPrescriptionsPDF\";

            var documentProperties = await _prescriptionRules.GetPropertiesMedicalPrescriptionPdf(request.AppointmentId);
            string textFooter = await _prescriptionRules.GetFooterMedicalPrescriptionPdf(request.AppointmentId);

            string result = await _documentProcessor.CreateDocumentPdf(templateFilePath, fileName, saveAspath, documentProperties, textFooter);

            return Result<string>.Success(result);
        }
    }
}
