using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalClinic.Infrastructure.Migrations
{
    public partial class InitialIMigrationIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for each medical exam")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "The name of the exam"),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, comment: "Description of the exam"),
                    Value = table.Column<decimal>(type: "decimal(18,6)", nullable: false, comment: "The Value of Exam"),
                    IsEnabled = table.Column<bool>(name: "IsEnabled ", type: "bit", nullable: false, comment: "Indicates if the record  is currently active in the system"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "The date when the record  was logically deleted from the system")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false, comment: "nique identifier for each health insurance plan")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "The name of the health insurance plan"),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true, comment: "Description of the health insurance plan"),
                    PercentageTypeOne = table.Column<decimal>(type: "decimal(18,6)", nullable: false, comment: "A percentage value related to the health insurance plan"),
                    PercentageTypeTwo = table.Column<decimal>(type: "decimal(18,6)", nullable: false, comment: "Another percentage value related to the health insurance plan"),
                    PercentageTypeThree = table.Column<decimal>(type: "decimal(18,6)", nullable: false, comment: "Another percentage value related to the health insurance plan"),
                    IsEnabled = table.Column<bool>(name: "IsEnabled ", type: "bit", nullable: false, comment: "Indicates if the record  is currently active in the system"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "The date when the record  was logically deleted from the system")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.InsuranceId);
                },
                comment: "Stores information about health insurance plans or medical health plans");

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    SpecialtyId = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for each medical specialty")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false, comment: "The name of the medical specialty"),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false, comment: "escription of the medical specialty"),
                    ConsultationValue = table.Column<decimal>(type: "decimal(18,6)", nullable: false, comment: "Value of Consultation "),
                    AppointmentDuration = table.Column<int>(type: "int", nullable: false, comment: "Standard duration in minutes of the average consultation time for the referring doctor"),
                    IsEnabled = table.Column<bool>(name: "IsEnabled ", type: "bit", nullable: false, comment: "Indicates if the record  is currently active in the system"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "The date when the record  was logically deleted from the system")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.SpecialtyId);
                },
                comment: "Stores information about medical specialties");

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for each Technician")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "The first name of the technician"),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "The last name or surname of the technician"),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "The email address of the technician"),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "The phone number of the technician"),
                    AddressLineOne = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: "The address line one  of the patient."),
                    AddressLineTwo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: "The address line two of the patient."),
                    InsuranceType = table.Column<byte>(type: "tinyint", nullable: true, comment: "Type of Insurance"),
                    IsEnabled = table.Column<bool>(name: "IsEnabled ", type: "bit", nullable: false, comment: "Indicates if the record  is currently active in the system"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "The date when the record  was logically deleted from the system")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                },
                comment: "Stores information about technicians or technical staff");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false, comment: "Patients table unique identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceId = table.Column<int>(type: "int", nullable: true, comment: "Foreign key referencing the unique identifier of the insurance plan associated with the procedure"),
                    InsuranceType = table.Column<byte>(type: "tinyint", nullable: true, comment: "Type of Insurance"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "The  name of the patient"),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "The last name  of the patient"),
                    Document = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Document of Patient"),
                    DateOfBirth = table.Column<DateTime>(name: "DateOfBirth ", type: "datetime", nullable: false, comment: "The date of birth of the patient"),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false, comment: "The gender of the patient\r\n0: Male, \r\n1: Female,\r\n2: NonBinary"),
                    PhoneOne = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "The phone one  number of the patient."),
                    PhoneTwo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "The phone two  number of the patient."),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "The email address of the patient."),
                    AddressLineOne = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: "The address line one of the patient."),
                    AddressLineTwo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: "The address line two of the patient."),
                    IsEnabled = table.Column<bool>(name: "IsEnabled ", type: "bit", nullable: false, comment: "Indicates if the record  is currently active in the system"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "The date when the record  was logically deleted from the system")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Insurance",
                        column: x => x.InsuranceId,
                        principalTable: "Insurances",
                        principalColumn: "InsuranceId");
                },
                comment: "Stores information about patients and their medical records.");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for each doctor in the system")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for each medical specialty"),
                    Crm = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "The CRM (Conselho Regional de Medicina) number of the doctor"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "The first name of the doctor."),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: " The last name or surname of the doctor"),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "The phone number of the doctor."),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "The email address of the doctor."),
                    AddressLineOne = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: "The address of the doctor"),
                    AddressLineTwo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: "The address of the doctor"),
                    IsEnabled = table.Column<bool>(name: "IsEnabled ", type: "bit", nullable: false, comment: "Indicates if the record  is currently active in the system"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "The date when the record  was logically deleted from the system")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialties",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "SpecialtyId");
                },
                comment: "Stores information about medical doctors, their specialties, and contact details.");

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    ProcedureId = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for each medical procedure")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key referencing the unique identifier of the patient associated with the procedure"),
                    TechnicianId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key referencing the unique identifier of the technician performing the procedure"),
                    ExamId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key referencing the unique identifier of the exam associated with the procedure"),
                    Observation = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, comment: "Additional observation or notes related to the procedure"),
                    ProcedureDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "The date of Procedure"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, comment: "Indicates the Status of the Procedure, being:\r\n0:Scheduled\r\n1:Confirmed\r\n2: Cancelled\r\n3: Completed"),
                    IsEnabled = table.Column<bool>(name: "IsEnabled ", type: "bit", nullable: false, comment: "Indicates if the record  is currently active in the system"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "The date when the record  was logically deleted from the system")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.ProcedureId);
                    table.ForeignKey(
                        name: "FK_Procedures_Exams",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId");
                    table.ForeignKey(
                        name: "FK_Procedures_Patients",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                    table.ForeignKey(
                        name: "FK_Procedures_Technicians",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId");
                },
                comment: "Stores information about medical procedures and exams performed on patients");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for each medical appointment")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestingDoctorId = table.Column<int>(type: "int", nullable: true, comment: "Foreign key of the doctor who requested the consultation, if there is a request within the clinic itself"),
                    PatientId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key referencing the unique identifier of the patient associated with the appointment"),
                    DoctorId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key referencing the unique identifier of the doctor associated with the appointment"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "The date of Appointment"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, comment: "Indicates the Status of the Query, being:\r\n0:Scheduled\r\n1:Confirmed\r\n2: Cancelled\r\n3: Completed"),
                    Observation = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, comment: "Additional observation or notes related to the appointment"),
                    IsEnabled = table.Column<bool>(name: "IsEnabled ", type: "bit", nullable: false, comment: "Indicates if the record  is currently active in the system"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "The date when the record  was logically deleted from the system")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                    table.ForeignKey(
                        name: "FK_Appointments_Patients",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                    table.ForeignKey(
                        name: "FK_Appointments_Requesting_Doctor",
                        column: x => x.RequestingDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                },
                comment: "Stores information about medical appointments or consultations");

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    AvailabilityId = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for each availability entry.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key referencing the doctor associated with this availability"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false, comment: "The day of the week when the doctor is available:\r\n0: Monday\r\n1: Tuesday\r\n2: Wednesday\r\n3: Thursday\r\n4: Friday\r\n5: Saturday\r\n6: Sunday"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false, comment: "The start time of the doctors availability for the specified day."),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false, comment: "The end time of the doctors availability for the specified day"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates if the record  is currently active in the system"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "The date when the record  was logically deleted from the system")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.AvailabilityId);
                    table.ForeignKey(
                        name: "FK_Availability_Doctors",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                },
                comment: "Stores information about the availability schedule for doctors.");

            migrationBuilder.CreateTable(
                name: "CanceledAppointment",
                columns: table => new
                {
                    CanceledAppointmentId = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for each canceled appointment")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for  appointment"),
                    ReasonCancellation = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true, comment: "Reason for the cancellation of the appointment"),
                    CancellationDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Date when the appointment was canceled")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanceledAppointment", x => x.CanceledAppointmentId);
                    table.ForeignKey(
                        name: "FK_CanceledAppointments_Specialties",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId");
                },
                comment: "Table tracks canceled medical appointments, capturing details such as appointment and cancellation dates");

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "int", nullable: false, comment: "A unique identifier for each prescription.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false, comment: "An identifier that associates this prescription with a specific appointment or medical visit."),
                    Observation = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false, comment: "A field used to store observations or notes related to the prescription.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescription_Appointments",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId");
                },
                comment: "This table is structured to capture details about medical prescriptions, associating them with specific patients and doctors, recording the date of issuance and expiration, and providing space for any additional notes or instructions associated with the prescription.");

            migrationBuilder.CreateTable(
                name: "Forwardings",
                columns: table => new
                {
                    ForwardingId = table.Column<int>(type: "int", nullable: false, comment: "A unique identifier for each medical record forwarding activity.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false, comment: "An identifier that associates this Fowarding with a specific prescription. It establishes a relationship between Fowardings and the prescriptions in which they are prescribed."),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false, comment: "FK of SPecialty"),
                    Observation = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true, comment: "A field used to store observations or notes related to the fowarding.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forwardings", x => x.ForwardingId);
                    table.ForeignKey(
                        name: "FK_Forwarding_Prescriptions",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forwarding_Specialties",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "SpecialtyId");
                },
                comment: "The table is structured to capture details about medical referrals, linking them to specific prescriptions, associating them with medical specialties, and providing space for additional observations or notes.");

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationId = table.Column<int>(type: "int", nullable: false, comment: "A unique identifier for each medication, allowing for easy reference and linkage to prescriptions.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false, comment: "An identifier that associates this medication with a specific prescription. It establishes a relationship between medications and the prescriptions in which they are prescribed."),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "The name of the medication being prescribed."),
                    SubstituteOne = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: " field used to record the name of the first substitute medication, if applicable"),
                    SubstituteTwo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: "A field used to record the name of the second substitute medication, if applicable."),
                    Instruction = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Instructions related to the medication. This field provides guidance on how the medication should be taken, including dosage, frequency, and any additional directions")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationId);
                    table.ForeignKey(
                        name: "FK_Medication_Prescriptions",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The table is structured to facilitate the management and tracking of prescribed medications, including details about potential substitutes and specific usage instructions.");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Patientid",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RequestingDoctorId",
                table: "Appointments",
                column: "RequestingDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_DoctorId",
                table: "Availabilities",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "UK_CanceledAppointment_AppointmentId",
                table: "CanceledAppointment",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "UK_Doctor_Crm_DeletedAt",
                table: "Doctors",
                columns: new[] { "Crm", "DeletedAt" },
                unique: true,
                filter: "[DeletedAt] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UK_Exam_Name_DeletedAt",
                table: "Exams",
                columns: new[] { "Name", "DeletedAt" },
                unique: true,
                filter: "[DeletedAt] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Forwardings_PrescriptionId",
                table: "Forwardings",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Forwardings_SpecialtyId",
                table: "Forwardings",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "UK_Insurance_Name_DeletedAt",
                table: "Insurances",
                columns: new[] { "Name", "DeletedAt" },
                unique: true,
                filter: "[DeletedAt] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_PrescriptionId",
                table: "Medications",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_InsuranceId",
                table: "Patients",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "UK_Patient_Document_DeletedAt",
                table: "Patients",
                columns: new[] { "Document", "DeletedAt" },
                unique: true,
                filter: "[Document] IS NOT NULL AND [DeletedAt] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UK_Prescription_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_ExamId",
                table: "Procedures",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_PatientId",
                table: "Procedures",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_TechnicianId",
                table: "Procedures",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "UK_Procedures_ProcedureDate",
                table: "Procedures",
                column: "ProcedureDate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Speciality_Name_DeletedAt",
                table: "Specialties",
                columns: new[] { "Name", "DeletedAt" },
                unique: true,
                filter: "[DeletedAt] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UK_Technicians_FirstName_LastName",
                table: "Technicians",
                columns: new[] { "FirstName", "LastName" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "CanceledAppointment");

            migrationBuilder.DropTable(
                name: "Forwardings");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Insurances");
        }
    }
}
