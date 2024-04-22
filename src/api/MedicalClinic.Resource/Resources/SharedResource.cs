using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Resource.Resources
{
    public static class SharedResource
    {
        public const string MESSAGE_APPOINTMENT_NOT_FOUND = "Appointment Id '{0}' not found";
        public const string MESSAGE_APPOINTMENT_UPDATE_STATUS_NOT_VALID = "It is not possible to update the status of the appointment, as it is either canceled or Completed";
        public const string MESSAGE_AVAILABILITY_NOT_FOUND = "Availability Id '{0}' not found";
        public const string MESSAGE_DOCTOR_IS_NOT_AVAILABLE = "Doctor Id '{0}' has no availability for the specified date and time";
        public const string MESSAGE_DOCTOR_HAS_NO_AVAILABILITY = "Doctor Id '{0}' has no availability registered";
        public const string MESSAGE_DOCTOR_ALREADY_APPOINTMENT_SPECIFIED_TIME = "Doctor Id '{0}' already has an appointment scheduled for the specified time";


        public const string MESSAGE_DOCTOR_EXISTS = "There is already a Doctor with CRM code '{0}'";
        public const string MESSAGE_DOCTOR_NOT_FOUND = "Doctor Id '{0}' not found";

        public const string MESSAGE_EXAM_EXISTS = "There is already a Exam with Name '{0}'";
        public const string MESSAGE_EXAM_NOT_FOUND = "Exame Id '{0}' not found";

        public const string MESSAGE_INSURANCE_EXISTS = "There is already a Insurance with Name '{0}'";
        public const string MESSAGE_INSURANCE_NOT_FOUND = "Insurance Id '{0}' not found";

        public const string MESSAGE_PATIENT_EXISTS = "There is already a Patient with First Name '{0}' and Last Name '{1}'";
        public const string MESSAGE_PATIENT_NOT_FOUND = "Patient Id '{0}' not found";

        public const string MESSAGE_PROCEDURE_NOT_FOUND = "Procedure Id '{0}' not found";
        public const string MESSAGE_PROCEDURE_EXISTS = "There is already a procedure with Procedure Date'{0}'";

        public const string MESSAGE_SPECIALTY_EXISTS = "There is already a Specialty with Name '{0}'";
        public const string MESSAGE_SPECIALTY_NOT_FOUND = "Specialty Id '{0}' not found";
        public const string MESSAGE_SPECIALTY_APPOINTMENT_DURATION_NOT_VALID = "It is not possible for a appointment to have a value of 0";

        public const string MESSAGE_TECHNICIAN_EXISTS = "There is already a Technician with First Name '{0}' and Last Name '{1}'";
        public const string MESSAGE_TECHNICIAN_NOT_FOUND = "Technician Id '{0}' not found";

        public const string MESSAGE_PRESCRIPTION_EXISTS = "There is already a Prescription with Id Appointment '{0}'";
        public const string MESSAGE_PRESCRIPTION_NOT_FOUND = "Prescription Id '{0}' not found";

        public const string MESSAGE_CANCELED_APPOINTMENT_EXISTS = "There is already a Canceled Appointment with Appointment Id '{0}'";
        public const string MESSAGE_CANCELED_APPOINTMENT_NOT_VALID = "You cannot cancel a appointment that has already been made";

        public const string MESSAGE_IDENTITY_USER_EXIST = "There is already a user with the email '{}'";
        public const string MESSAGE_IDENTITY_USER_NOT_FOUND = "No user was found with the email '{0}'";
        public const string MESSAGE_IDENTITY_PASSWORD_INVALID = "The password is incorrect";



    }
}

