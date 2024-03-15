using MedicalClinic.Application.Constants;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Application.Interfaces.Rules;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Rules
{
    public class PrescriptionRules : IPrescriptionRules
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMedicationRepository _medicationRepository;
        public PrescriptionRules
            (IPrescriptionRepository prescriptionRepository, 
           
            IAppointmentRepository appointmentRepository,
            IMedicationRepository medicationRepository

            )
        {
            _prescriptionRepository = prescriptionRepository;
            _appointmentRepository = appointmentRepository;
            _medicationRepository = medicationRepository;
        }

       
        public async Task<Dictionary<string, string>> GetPropertiesMedicalPrescriptionPdf(int appointmentId)
        {
            var appointment = await _appointmentRepository.Entities
                .Where(a => a.Id == appointmentId)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var prescription = await _prescriptionRepository.Entities
                .Where(p => p.AppointmentId == appointmentId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var medications = await _medicationRepository.Entities
                .Where(m => m.PrescriptionId == prescription.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var documentProperties = new Dictionary<string, string>();

            if (appointment != null && prescription != null)
            {
                //PrescriptionInformation
                string patientName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}";
                string patientDocument = appointment.Patient.Document != null ? appointment.Patient.Document : string.Empty;
                string patientAddress = (appointment.Patient.AddressLineOne != null && appointment.Patient.AddressLineTwo != null) ? $"{appointment.Patient.AddressLineOne} - {appointment.Patient.AddressLineTwo}" : string.Empty;
                string prescriptionDate = DateTime.Now.ToString("dd/MM/yyyy");

                string prescriptionObservation = prescription.Observation;

                string medicationName = $"{medications.Name} /";
                string medicationSubstituteOne = $"{medications.SubstituteOne} /";
                string medicationSubstituteTwo = $"{medications.SubstituteTwo}";
                string medicationInstruction = $"{medications.Instruction}";

                string doctorName = $"{appointment.Doctor.FirstName} {appointment.Doctor.LastName}";
                string doctorCrm = appointment.Doctor.Crm;

                documentProperties.Add("MD_PATIENT_NAME", patientName);
                documentProperties.Add("MD_PATIENT_DOCUMENT", patientDocument);
                documentProperties.Add("MD_PATIENT_ADDRESS", patientAddress);
                documentProperties.Add("MD_APPOINTMENT_DATE", prescriptionDate);

                documentProperties.Add("MD_PRESCRIPTION_OBSERVATION", prescriptionObservation);

                documentProperties.Add("MD_MEDICATION_NAME", medicationName);
                documentProperties.Add("MD_MEDICATION_ONE_NAME", medicationSubstituteOne);
                documentProperties.Add("MD_MEDICATION_TWO_NAME", medicationSubstituteTwo);
                documentProperties.Add("MD_MEDICATION_ONE_INSTRUCTION", medicationInstruction);
                
                documentProperties.Add("MD_DOCTOR_NAME", doctorName);
            }

            return documentProperties;
        }

        public async Task<string> GetFooterMedicalPrescriptionPdf(int appointmentId)
        {
            var appointment = await _appointmentRepository.Entities
                .Where(a => a.Id == appointmentId)
                .Include(a => a.Doctor)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            string doctorName = $"{appointment.Doctor.FirstName} {appointment.Doctor.LastName}";
            string doctorCrm = appointment.Doctor.Crm;

            return $"{PrescriptionConstants.AcronymDoctor} {doctorName} - {PrescriptionConstants.CrmDoctor} {doctorCrm}";
        }
    }
}
