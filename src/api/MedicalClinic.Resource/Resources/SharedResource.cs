﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Resource.Resources
{
    public static class SharedResource
    {
        public const string MESSAGE_APPOINTMENT_NOT_FOUND = "Appointment Id '{0}' not found";
        public const string MESSAGE_AVAILABILITY_NOT_FOUND = "Availability Id '{0}' not found";

        public const string MESSAGE_DOCTOR_EXISTS = "There is already a Doctor with CRM code '{0}'";
        public const string MESSAGE_DOCTOR_NOT_FOUND = "Doctor Id '{0}' not found";

        public const string MESSAGE_EXAM_EXISTS = "There is already a Exam with Name '{0}'";
        public const string MESSAGE_EXAM_NOT_FOUND = "Exame Id '{0}' not found";

        public const string MESSAGE_INSURANCE_EXISTS = "There is already a Insurance with Name '{0}'";
        public const string MESSAGE_INSURANCE_NOT_FOUND = "Insurance Id '{0}' not found";

        public const string MESSAGE_PATIENT_EXISTS = "There is already a Patient with First Name '{0}' and Last Name '{1}'";
        public const string MESSAGE_PATIENT_NOT_FOUND = "Patient Id '{0}' not found";

    }
}

