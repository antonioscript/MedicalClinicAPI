CREATE DATABASE MedicalClinicDB
GO



GO
IF EXISTS(SELECT * FROM sys.sysobjects WHERE NAME = 'Appointments' AND xtype = 'U')
BEGIN
	DROP TABLE dbo.Appointments;
END
GO
;



CREATE TABLE dbo.Appointments 
    (
     AppointmentId INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     PatientId INTEGER NOT NULL , 
     DoctorId INTEGER NOT NULL , 
     Status TINYINT NOT NULL , 
     Observation VARCHAR (200) , 
     "IsEnabled " BIT NOT NULL , 
     DeletedAt DATETIME 
    )
GO 



EXEC sp_addextendedproperty 'MS_Description' , 'Stores information about medical appointments or consultations' , 'USER' , 'dbo' , 'TABLE' , 'Appointments' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Unique identifier for each medical appointment' , 'USER' , 'dbo' , 'TABLE' , 'Appointments' , 'COLUMN' , 'AppointmentId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Foreign key referencing the unique identifier of the patient associated with the appointment' , 'USER' , 'dbo' , 'TABLE' , 'Appointments' , 'COLUMN' , 'PatientId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Foreign key referencing the unique identifier of the doctor associated with the appointment' , 'USER' , 'dbo' , 'TABLE' , 'Appointments' , 'COLUMN' , 'DoctorId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Indicates the Status of the Query, being:
0:Scheduled
1:Confirmed
2: Cancelled' , 'USER' , 'dbo' , 'TABLE' , 'Appointments' , 'COLUMN' , 'Status' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Additional observation or notes related to the appointment' , 'USER' , 'dbo' , 'TABLE' , 'Appointments' , 'COLUMN' , 'Observation' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Indicates if the record  is currently active in the system' , 'USER' , 'dbo' , 'TABLE' , 'Appointments' , 'COLUMN' , 'IsEnabled ' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The date when the record  was logically deleted from the system' , 'USER' , 'dbo' , 'TABLE' , 'Appointments' , 'COLUMN' , 'DeletedAt' 
GO

    


CREATE NONCLUSTERED INDEX 
    IX_Appointments_Patientid ON dbo.Appointments 
    ( 
     PatientId 
    ) 
GO 


CREATE NONCLUSTERED INDEX 
    IX_Appointments_DoctorId ON dbo.Appointments 
    ( 
     DoctorId 
    ) 
GO

ALTER TABLE dbo.Appointments ADD CONSTRAINT PK_Appointments PRIMARY KEY CLUSTERED (AppointmentId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

GO
IF EXISTS(SELECT * FROM sys.sysobjects WHERE NAME = 'Availability' AND xtype = 'U')
BEGIN
	DROP TABLE dbo.Availability;
END
GO
;



CREATE TABLE dbo.Availability 
    (
     AvailabilityId INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     DoctorId INTEGER NOT NULL , 
     DayOfWeek TINYINT NOT NULL , 
     StartTime DATETIME NOT NULL , 
     EndTime DATETIME NOT NULL , 
     "IsEnabled " BIT NOT NULL , 
     DeletedAt DATETIME 
    )
GO 



EXEC sp_addextendedproperty 'MS_Description' , 'Stores information about the availability schedule for doctors.' , 'USER' , 'dbo' , 'TABLE' , 'Availability' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Unique identifier for each availability entry.' , 'USER' , 'dbo' , 'TABLE' , 'Availability' , 'COLUMN' , 'AvailabilityId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Foreign key referencing the doctor associated with this availability' , 'USER' , 'dbo' , 'TABLE' , 'Availability' , 'COLUMN' , 'DoctorId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The day of the week when the doctor is available:
0: Monday
1: Tuesday
2: Wednesday
3: Thursday
4: Friday
5: Saturday
6: Sunday' , 'USER' , 'dbo' , 'TABLE' , 'Availability' , 'COLUMN' , 'DayOfWeek' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The start time of the doctors availability for the specified day.' , 'USER' , 'dbo' , 'TABLE' , 'Availability' , 'COLUMN' , 'StartTime' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The end time of the doctors availability for the specified day' , 'USER' , 'dbo' , 'TABLE' , 'Availability' , 'COLUMN' , 'EndTime' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Indicates if the record  is currently active in the system' , 'USER' , 'dbo' , 'TABLE' , 'Availability' , 'COLUMN' , 'IsEnabled ' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The date when the record  was logically deleted from the system' , 'USER' , 'dbo' , 'TABLE' , 'Availability' , 'COLUMN' , 'DeletedAt' 
GO

    


CREATE NONCLUSTERED INDEX 
    IX_Availability_DoctorId ON dbo.Availability 
    ( 
     DoctorId 
    ) 
GO

ALTER TABLE dbo.Availability ADD CONSTRAINT PK_Availability PRIMARY KEY CLUSTERED (AvailabilityId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

GO
IF EXISTS(SELECT * FROM sys.sysobjects WHERE NAME = 'Doctors' AND xtype = 'U')
BEGIN
	DROP TABLE dbo.Doctors;
END
GO
;



CREATE TABLE dbo.Doctors 
    (
     DoctorId INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     SpecialtyId INTEGER NOT NULL , 
     Crm VARCHAR (20) NOT NULL , 
     FirstName VARCHAR (50) NOT NULL , 
     LastName VARCHAR (50) NOT NULL , 
     Phone VARCHAR (20) NOT NULL , 
     Email VARCHAR (50) , 
     AddressLineOne VARCHAR , 
     AddressLineTwo VARCHAR , 
     "IsEnabled " BIT NOT NULL , 
     DeletedAt DATETIME 
    )
GO 



EXEC sp_addextendedproperty 'MS_Description' , 'Stores information about medical doctors, their specialties, and contact details.' , 'USER' , 'dbo' , 'TABLE' , 'Doctors' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Unique identifier for each doctor in the system' , 'USER' , 'dbo' , 'TABLE' , 'Doctors' , 'COLUMN' , 'DoctorId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Unique identifier for each medical specialty' , 'USER' , 'dbo' , 'TABLE' , 'Doctors' , 'COLUMN' , 'SpecialtyId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The CRM (Conselho Regional de Medicina) number of the doctor' , 'USER' , 'dbo' , 'TABLE' , 'Doctors' , 'COLUMN' , 'Crm' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The first name of the doctor.' , 'USER' , 'dbo' , 'TABLE' , 'Doctors' , 'COLUMN' , 'FirstName' 
GO



EXEC sp_addextendedproperty 'MS_Description' , ' The last name or surname of the doctor' , 'USER' , 'dbo' , 'TABLE' , 'Doctors' , 'COLUMN' , 'LastName' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The phone number of the doctor.' , 'USER' , 'dbo' , 'TABLE' , 'Doctors' , 'COLUMN' , 'Phone' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The email address of the doctor.' , 'USER' , 'dbo' , 'TABLE' , 'Doctors' , 'COLUMN' , 'Email' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The address of the doctor' , 'USER' , 'dbo' , 'TABLE' , 'Doctors' , 'COLUMN' , 'AddressLineOne' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The address of the doctor' , 'USER' , 'dbo' , 'TABLE' , 'Doctors' , 'COLUMN' , 'AddressLineTwo' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Indicates if the record  is currently active in the system' , 'USER' , 'dbo' , 'TABLE' , 'Doctors' , 'COLUMN' , 'IsEnabled ' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The date when the record  was logically deleted from the system' , 'USER' , 'dbo' , 'TABLE' , 'Doctors' , 'COLUMN' , 'DeletedAt' 
GO

ALTER TABLE dbo.Doctors ADD CONSTRAINT PK_Doctors PRIMARY KEY CLUSTERED (DoctorId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO
ALTER TABLE dbo.Doctors ADD CONSTRAINT UK_Doctor_Crm_DeletedAt UNIQUE NONCLUSTERED (Crm, DeletedAt)
GO

GO
IF EXISTS(SELECT * FROM sys.sysobjects WHERE NAME = 'Exams' AND xtype = 'U')
BEGIN
	DROP TABLE dbo.Exams;
END
GO
;



CREATE TABLE dbo.Exams 
    (
     ExamId INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     Name VARCHAR (50) NOT NULL , 
     Description VARCHAR (200) , 
     Value DECIMAL (18,6) NOT NULL , 
     "IsEnabled " BIT NOT NULL , 
     DeletedAt DATETIME 
    )
GO 



EXEC sp_addextendedproperty 'MS_Description' , 'Unique identifier for each medical exam' , 'USER' , 'dbo' , 'TABLE' , 'Exams' , 'COLUMN' , 'ExamId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The name of the exam' , 'USER' , 'dbo' , 'TABLE' , 'Exams' , 'COLUMN' , 'Name' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Description of the exam' , 'USER' , 'dbo' , 'TABLE' , 'Exams' , 'COLUMN' , 'Description' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The Value of Exam' , 'USER' , 'dbo' , 'TABLE' , 'Exams' , 'COLUMN' , 'Value' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Indicates if the record  is currently active in the system' , 'USER' , 'dbo' , 'TABLE' , 'Exams' , 'COLUMN' , 'IsEnabled ' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The date when the record  was logically deleted from the system' , 'USER' , 'dbo' , 'TABLE' , 'Exams' , 'COLUMN' , 'DeletedAt' 
GO

ALTER TABLE dbo.Exams ADD CONSTRAINT PK_Exams PRIMARY KEY CLUSTERED (ExamId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO
ALTER TABLE dbo.Exams ADD CONSTRAINT UK_Exam_Name_DeletedAt UNIQUE NONCLUSTERED (Name, DeletedAt)
GO

GO
IF EXISTS(SELECT * FROM sys.sysobjects WHERE NAME = 'Insurance' AND xtype = 'U')
BEGIN
	DROP TABLE dbo.Insurance;
END
GO
;



CREATE TABLE dbo.Insurance 
    (
     InsuranceId INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     Name VARCHAR (50) NOT NULL , 
     Description VARCHAR (250) , 
     PercentageTypeOne DECIMAL (18,6) NOT NULL , 
     PercentageTypeTwo DECIMAL (18,6) NOT NULL , 
     PercentageTypeThree DECIMAL (18,6) NOT NULL , 
     "IsEnabled " BIT NOT NULL , 
     DeletedAt DATETIME 
    )
GO 



EXEC sp_addextendedproperty 'MS_Description' , 'Stores information about health insurance plans or medical health plans' , 'USER' , 'dbo' , 'TABLE' , 'Insurance' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'nique identifier for each health insurance plan' , 'USER' , 'dbo' , 'TABLE' , 'Insurance' , 'COLUMN' , 'InsuranceId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The name of the health insurance plan' , 'USER' , 'dbo' , 'TABLE' , 'Insurance' , 'COLUMN' , 'Name' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Description of the health insurance plan' , 'USER' , 'dbo' , 'TABLE' , 'Insurance' , 'COLUMN' , 'Description' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'A percentage value related to the health insurance plan' , 'USER' , 'dbo' , 'TABLE' , 'Insurance' , 'COLUMN' , 'PercentageTypeOne' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Another percentage value related to the health insurance plan' , 'USER' , 'dbo' , 'TABLE' , 'Insurance' , 'COLUMN' , 'PercentageTypeTwo' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Another percentage value related to the health insurance plan' , 'USER' , 'dbo' , 'TABLE' , 'Insurance' , 'COLUMN' , 'PercentageTypeThree' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Indicates if the record  is currently active in the system' , 'USER' , 'dbo' , 'TABLE' , 'Insurance' , 'COLUMN' , 'IsEnabled ' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The date when the record  was logically deleted from the system' , 'USER' , 'dbo' , 'TABLE' , 'Insurance' , 'COLUMN' , 'DeletedAt' 
GO

ALTER TABLE dbo.Insurance ADD CONSTRAINT PK_Insurance PRIMARY KEY CLUSTERED (InsuranceId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO
ALTER TABLE dbo.Insurance ADD CONSTRAINT UK_Insurance_Name_DeletedAt UNIQUE NONCLUSTERED (Name, DeletedAt)
GO

GO
IF EXISTS(SELECT * FROM sys.sysobjects WHERE NAME = 'Patients' AND xtype = 'U')
BEGIN
	DROP TABLE dbo.Patients;
END
GO
;



CREATE TABLE dbo.Patients 
    (
     PatientId INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     InsuranceId INTEGER , 
     InsuranceType TINYINT , 
     FirstName VARCHAR (50) NOT NULL , 
     LastName VARCHAR (50) NOT NULL , 
     Document VARCHAR (20)  NOT NULL , 
     "DateOfBirth " DATETIME NOT NULL , 
     Gender TINYINT NOT NULL , 
     PhoneOne VARCHAR (20) NOT NULL , 
     PhoneTwo VARCHAR (20) , 
     Email VARCHAR (50) , 
     AddressLineOne VARCHAR , 
     AddressLineTwo VARCHAR , 
     "IsEnabled " BIT NOT NULL , 
     DeletedAt DATETIME 
    )
GO 



EXEC sp_addextendedproperty 'MS_Description' , 'Stores information about patients and their medical records.' , 'USER' , 'dbo' , 'TABLE' , 'Patients' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Patients table unique identifier' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'PatientId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Foreign key referencing the unique identifier of the insurance plan associated with the procedure' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'InsuranceId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Type of Insurance' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'InsuranceType' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The  name of the patient' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'FirstName' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The last name  of the patient' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'LastName' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Document of Patient' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'Document' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The date of birth of the patient' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'DateOfBirth ' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The gender of the patient
0: Male, 
1: Female,
2: NonBinary' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'Gender' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The phone one  number of the patient.' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'PhoneOne' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The phone two  number of the patient.' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'PhoneTwo' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The email address of the patient.' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'Email' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The address line one of the patient.' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'AddressLineOne' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The address line two of the patient.' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'AddressLineTwo' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Indicates if the record  is currently active in the system' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'IsEnabled ' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The date when the record  was logically deleted from the system' , 'USER' , 'dbo' , 'TABLE' , 'Patients' , 'COLUMN' , 'DeletedAt' 
GO

ALTER TABLE dbo.Patients ADD CONSTRAINT PK_Patients PRIMARY KEY CLUSTERED (PatientId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO
ALTER TABLE dbo.Patients ADD CONSTRAINT UK_Patient_Document_DeletedAt UNIQUE NONCLUSTERED (Document, DeletedAt)
GO

GO
IF EXISTS(SELECT * FROM sys.sysobjects WHERE NAME = 'Procedures' AND xtype = 'U')
BEGIN
	DROP TABLE dbo.Procedures;
END
GO
;



CREATE TABLE dbo.Procedures 
    (
     ProcedureId INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     PatientId INTEGER NOT NULL , 
     TechnicianId INTEGER NOT NULL , 
     ExamId INTEGER NOT NULL , 
     Observation VARCHAR (200) , 
     "IsEnabled " BIT NOT NULL , 
     DeletedAt DATETIME 
    )
GO 



EXEC sp_addextendedproperty 'MS_Description' , 'Stores information about medical procedures and exams performed on patients' , 'USER' , 'dbo' , 'TABLE' , 'Procedures' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Unique identifier for each medical procedure' , 'USER' , 'dbo' , 'TABLE' , 'Procedures' , 'COLUMN' , 'ProcedureId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Foreign key referencing the unique identifier of the patient associated with the procedure' , 'USER' , 'dbo' , 'TABLE' , 'Procedures' , 'COLUMN' , 'PatientId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Foreign key referencing the unique identifier of the technician performing the procedure' , 'USER' , 'dbo' , 'TABLE' , 'Procedures' , 'COLUMN' , 'TechnicianId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Foreign key referencing the unique identifier of the exam associated with the procedure' , 'USER' , 'dbo' , 'TABLE' , 'Procedures' , 'COLUMN' , 'ExamId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Additional observation or notes related to the procedure' , 'USER' , 'dbo' , 'TABLE' , 'Procedures' , 'COLUMN' , 'Observation' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Indicates if the record  is currently active in the system' , 'USER' , 'dbo' , 'TABLE' , 'Procedures' , 'COLUMN' , 'IsEnabled ' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The date when the record  was logically deleted from the system' , 'USER' , 'dbo' , 'TABLE' , 'Procedures' , 'COLUMN' , 'DeletedAt' 
GO

    


CREATE NONCLUSTERED INDEX 
    IX_Procedures_PatientId ON dbo.Procedures 
    ( 
     PatientId 
    ) 
GO 


CREATE NONCLUSTERED INDEX 
    IX_Procedures_TechnicianId ON dbo.Procedures 
    ( 
     TechnicianId 
    ) 
GO 


CREATE NONCLUSTERED INDEX 
    IX_Procedures_ExamId ON dbo.Procedures 
    ( 
     ExamId 
    ) 
GO

ALTER TABLE dbo.Procedures ADD CONSTRAINT PK_Procedures PRIMARY KEY CLUSTERED (ProcedureId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

GO
IF EXISTS(SELECT * FROM sys.sysobjects WHERE NAME = 'Specialties' AND xtype = 'U')
BEGIN
	DROP TABLE dbo.Specialties;
END
GO
;



CREATE TABLE dbo.Specialties 
    (
     SpecialtyId INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     Name VARCHAR (60) NOT NULL , 
     Description VARCHAR (250) NOT NULL , 
     ConsultationValue DECIMAL (18,6) NOT NULL , 
     "IsEnabled " BIT NOT NULL , 
     DeletedAt DATETIME 
    )
GO 



EXEC sp_addextendedproperty 'MS_Description' , 'Stores information about medical specialties' , 'USER' , 'dbo' , 'TABLE' , 'Specialties' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Unique identifier for each medical specialty' , 'USER' , 'dbo' , 'TABLE' , 'Specialties' , 'COLUMN' , 'SpecialtyId' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The name of the medical specialty' , 'USER' , 'dbo' , 'TABLE' , 'Specialties' , 'COLUMN' , 'Name' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'escription of the medical specialty' , 'USER' , 'dbo' , 'TABLE' , 'Specialties' , 'COLUMN' , 'Description' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Value of Consultation ' , 'USER' , 'dbo' , 'TABLE' , 'Specialties' , 'COLUMN' , 'ConsultationValue' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Indicates if the record  is currently active in the system' , 'USER' , 'dbo' , 'TABLE' , 'Specialties' , 'COLUMN' , 'IsEnabled ' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The date when the record  was logically deleted from the system' , 'USER' , 'dbo' , 'TABLE' , 'Specialties' , 'COLUMN' , 'DeletedAt' 
GO

ALTER TABLE dbo.Specialties ADD CONSTRAINT PK_Specialties PRIMARY KEY CLUSTERED (SpecialtyId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO
ALTER TABLE dbo.Specialties ADD CONSTRAINT UK_Speciality_Name_DeletedAt UNIQUE NONCLUSTERED (Name, DeletedAt)
GO

GO
IF EXISTS(SELECT * FROM sys.sysobjects WHERE NAME = 'Technicians' AND xtype = 'U')
BEGIN
	DROP TABLE dbo.Technicians;
END
GO
;



CREATE TABLE dbo.Technicians 
    (
     TechnicianId INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     FirstName VARCHAR (50) NOT NULL , 
     LastName VARCHAR (50) NOT NULL , 
     Email VARCHAR (50) , 
     Phone VARCHAR (20) , 
     AddressLineOne VARCHAR , 
     AddressLineTwo VARCHAR , 
     InsuranceType TINYINT , 
     "IsEnabled " BIT NOT NULL , 
     DeletedAt DATETIME 
    )
GO 



EXEC sp_addextendedproperty 'MS_Description' , 'Stores information about technicians or technical staff' , 'USER' , 'dbo' , 'TABLE' , 'Technicians' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The first name of the technician' , 'USER' , 'dbo' , 'TABLE' , 'Technicians' , 'COLUMN' , 'FirstName' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The last name or surname of the technician' , 'USER' , 'dbo' , 'TABLE' , 'Technicians' , 'COLUMN' , 'LastName' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The email address of the technician' , 'USER' , 'dbo' , 'TABLE' , 'Technicians' , 'COLUMN' , 'Email' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The phone number of the technician' , 'USER' , 'dbo' , 'TABLE' , 'Technicians' , 'COLUMN' , 'Phone' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The address line one  of the patient.' , 'USER' , 'dbo' , 'TABLE' , 'Technicians' , 'COLUMN' , 'AddressLineOne' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The address line two of the patient.' , 'USER' , 'dbo' , 'TABLE' , 'Technicians' , 'COLUMN' , 'AddressLineTwo' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Type of Insurance' , 'USER' , 'dbo' , 'TABLE' , 'Technicians' , 'COLUMN' , 'InsuranceType' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'Indicates if the record  is currently active in the system' , 'USER' , 'dbo' , 'TABLE' , 'Technicians' , 'COLUMN' , 'IsEnabled ' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'The date when the record  was logically deleted from the system' , 'USER' , 'dbo' , 'TABLE' , 'Technicians' , 'COLUMN' , 'DeletedAt' 
GO

ALTER TABLE dbo.Technicians ADD CONSTRAINT PK_Technicians PRIMARY KEY CLUSTERED (TechnicianId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

ALTER TABLE dbo.Appointments 
    ADD CONSTRAINT FK_Appointments_Doctors FOREIGN KEY 
    ( 
     DoctorId
    ) 
    REFERENCES dbo.Doctors 
    ( 
     DoctorId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE dbo.Appointments 
    ADD CONSTRAINT FK_Appointments_Patients FOREIGN KEY 
    ( 
     PatientId
    ) 
    REFERENCES dbo.Patients 
    ( 
     PatientId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE dbo.Availability 
    ADD CONSTRAINT FK_Availability_Doctors FOREIGN KEY 
    ( 
     DoctorId
    ) 
    REFERENCES dbo.Doctors 
    ( 
     DoctorId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE dbo.Doctors 
    ADD CONSTRAINT FK_Doctors_Specialties FOREIGN KEY 
    ( 
     SpecialtyId
    ) 
    REFERENCES dbo.Specialties 
    ( 
     SpecialtyId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE dbo.Patients 
    ADD CONSTRAINT FK_Patients_Insurance FOREIGN KEY 
    ( 
     InsuranceId
    ) 
    REFERENCES dbo.Insurance 
    ( 
     InsuranceId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE dbo.Procedures 
    ADD CONSTRAINT FK_Procedures_Exams FOREIGN KEY 
    ( 
     ExamId
    ) 
    REFERENCES dbo.Exams 
    ( 
     ExamId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE dbo.Procedures 
    ADD CONSTRAINT FK_Procedures_Patients FOREIGN KEY 
    ( 
     PatientId
    ) 
    REFERENCES dbo.Patients 
    ( 
     PatientId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE dbo.Procedures 
    ADD CONSTRAINT FK_Procedures_Technicians FOREIGN KEY 
    ( 
     TechnicianId
    ) 
    REFERENCES dbo.Technicians 
    ( 
     TechnicianId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO





SET IDENTITY_INSERT dbo.Insurance ON;

INSERT INTO dbo.Insurance (InsuranceId, Name, Description, PercentageTypeOne, PercentageTypeTwo, PercentageTypeThree, IsEnabled, DeletedAt)
VALUES
(1, 'Basic Plan', 'Provides basic healthcare coverage.', 0.15, 0.25, 0.10, 1, NULL),
(2, 'Premium Plan', 'Comprehensive healthcare coverage with additional benefits.', 0.20, 0.35, 0.15, 1, NULL),
(3, 'Family Plan', 'Covers healthcare for the whole family at a discounted rate.', 0.18, 0.30, 0.12, 1, NULL),
(4, 'Senior Plan', 'Tailored for senior citizens with specialized care options.', 0.12, 0.20, 0.08, 1, NULL);

SET IDENTITY_INSERT dbo.Insurance OFF
;



SET IDENTITY_INSERT dbo.Patients ON;

INSERT INTO dbo.Patients (PatientId, InsuranceId, InsuranceType, FirstName, LastName, Document, DateOfBirth, Gender, PhoneOne, PhoneTwo, Email, AddressLineOne, AddressLineTwo, IsEnabled, DeletedAt)
VALUES
(1, 1, 1, 'John', 'Doe', '123456789', CONVERT(DATETIME, '1990-05-15 00:00:00', 120), 1, '+1 (123) 456-7890', '+1 (987) 654-3210', 'john.doe@email.com', '123 Main Street', 'Apt 4B', 1, NULL),
(2, 2, 2, 'Jane', 'Smith', '987654321', CONVERT(DATETIME, '1985-08-25 00:00:00', 120), 2, '+1 (555) 123-4567', NULL, 'jane.smith@email.com', '456 Oak Avenue', NULL, 1, NULL),
(3, 3, 1, 'Peter', 'Johnson', '456789123', CONVERT(DATETIME, '1995-02-10 00:00:00', 120), 1, '+1 (777) 888-9999', '+1 (444) 555-6666', 'michael.johnson@email.com', '789 Maple Lane', 'Suite 202', 1, NULL),
(4, 4, 2, 'Rose', 'Wayne', '789123456', CONVERT(DATETIME, '1980-11-05 00:00:00', 120), 2, '+1 (222) 333-4444', NULL, 'sophia.williams@email.com', '456 Pine Road', NULL, 1, NULL);

SET IDENTITY_INSERT dbo.Patients OFF;






SET IDENTITY_INSERT dbo.Specialties ON;

INSERT INTO dbo.Specialties (SpecialtyId, Name, Description, ConsultationValue, IsEnabled, DeletedAt)
VALUES
(1, 'Cardiology', 'Deals with disorders of the heart and blood vessels.', 250.00, 1, NULL),
(2, 'Pediatrics', 'Focuses on medical care for infants, children, and adolescents.', 200.00, 1, NULL),
(3, 'Dermatology', 'Specializes in the treatment of skin, hair, and nail conditions.', 180.00, 1, NULL),
(4, 'Orthopedics', 'Deals with the musculoskeletal system and related injuries.', 300.00, 1, NULL);

SET IDENTITY_INSERT dbo.Specialties OFF
;




SET IDENTITY_INSERT dbo.Doctors ON;

INSERT INTO dbo.Doctors (DoctorId, SpecialtyId, Crm, FirstName, LastName, Phone, Email, AddressLineOne, AddressLineTwo, IsEnabled, DeletedAt)
VALUES
(1, 1, '12345', 'John', 'Smith', '+1 (123) 456-7890', 'john.smith@email.com', '123 Main Street', 'Apt 4B', 1, NULL),
(2, 2, '67890', 'Emily', 'Johnson', '+1 (987) 654-3210', 'emily.johnson@email.com', '456 Oak Avenue', NULL, 1, NULL),
(3, 3, '54321', 'Michael', 'Brown', '+1 (555) 123-4567', 'michael.brown@email.com', '789 Maple Lane', 'Suite 202', 1, NULL),
(4, 4, '98765', 'Sophia', 'Williams', '+1 (777) 888-9999', 'sophia.williams@email.com', '456 Pine Road', NULL, 1, NULL);

SET IDENTITY_INSERT dbo.Doctors OFF
;



SET IDENTITY_INSERT dbo.Availability ON;

INSERT INTO dbo.Availability (AvailabilityId, DoctorId, DayOfWeek, StartTime, EndTime, IsEnabled, DeletedAt)
VALUES
(1, 1, 1, CONVERT(DATETIME, '2023-07-28 08:00:00', 120), CONVERT(DATETIME,'2023-07-28 17:00:00', 120), 1, NULL),
(2, 2, 2, CONVERT(DATETIME,'2023-07-29 09:30:00', 120), CONVERT(DATETIME,'2023-07-29 16:30:00', 120), 1, NULL),
(3, 3, 3, CONVERT(DATETIME,'2023-07-30 10:00:00', 120), CONVERT(DATETIME,'2023-07-30 18:00:00', 120), 1, NULL),
(4, 4, 4, CONVERT(DATETIME,'2023-07-31 08:30:00', 120), CONVERT(DATETIME,'2023-07-31 15:30:00', 120), 1, NULL);

SET IDENTITY_INSERT dbo.Availability OFF
;



SET IDENTITY_INSERT dbo.Exams ON;

INSERT INTO dbo.Exams (ExamId, Name, Description, Value, IsEnabled, DeletedAt)
VALUES
(1, 'Blood Test', 'Basic blood analysis', 80.00, 1, NULL),
(2, 'X-ray', 'Radiographic imaging', 150.00, 1, NULL),
(3, 'MRI', 'Magnetic resonance imaging', 300.00, 1, NULL),
(4, 'Ultrasound', 'Diagnostic ultrasound', 200.00, 1, NULL);

SET IDENTITY_INSERT dbo.Exams OFF
;




SET IDENTITY_INSERT dbo.Technicians ON;

INSERT INTO dbo.Technicians (TechnicianId, FirstName, LastName, Email, Phone, AddressLineOne, AddressLineTwo, InsuranceType, IsEnabled, DeletedAt)
VALUES
(1, 'Robert', 'Johnson', 'robert.johnson@example.com', '+1 (123) 456-7890', '123 Main Street', 'Apt 4B', 1, 1, NULL),
(2, 'Olivia', 'Smith', 'olivia.smith@example.com', '+1 (555) 123-4567', '456 Oak Avenue', NULL, 2, 1, NULL),
(3, 'William', 'Doe', 'william.doe@example.com', '+1 (777) 888-9999', '789 Maple Lane', 'Suite 202', 1, 1, NULL),
(4, 'Sophie', 'Williams', 'sophie.williams@example.com', '+1 (222) 333-4444', '456 Pine Road', NULL, 2, 1, NULL);

SET IDENTITY_INSERT dbo.Technicians OFF
;


SET IDENTITY_INSERT dbo.Appointments ON;

INSERT INTO dbo.Appointments (AppointmentId, PatientId, DoctorId, Status, Observation, IsEnabled, DeletedAt)
VALUES
(1, 1, 1, 1, 'Regular check-up', 1, NULL),
(2, 2, 2, 2, 'Vaccination', 1, NULL),
(3, 3, 3, 1, 'Follow-up consultation', 1, NULL),
(4, 4, 4, 3, 'Physical examination', 1, NULL);

SET IDENTITY_INSERT dbo.Appointments OFF
;


SET IDENTITY_INSERT dbo.Procedures ON;

INSERT INTO dbo.Procedures (ProcedureId, PatientId, TechnicianId, ExamId, Observation, IsEnabled, DeletedAt)
VALUES
(1, 1, 1, 1, 'Routine blood test', 1, NULL),
(2, 2, 2, 2, 'Chest X-ray', 1, NULL),
(3, 3, 3, 3, 'MRI Scan', 1, NULL),
(4, 4, 4, 4, 'Abdominal Ultrasound', 1, NULL);

SET IDENTITY_INSERT dbo.Procedures OFF
;

