using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.MedicalClinic.Infrastructure.DbContexts
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Availability> Availabilities { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<Insurance> Insurances { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Procedure> Procedures { get; set; } = null!;
        public virtual DbSet<Specialty> Specialties { get; set; } = null!;
        public virtual DbSet<Technician> Technicians { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=MedicalClinicDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasComment("Stores information about medical appointments or consultations");

                entity.HasIndex(e => e.DoctorId, "IX_Appointments_DoctorId");

                entity.HasIndex(e => e.PatientId, "IX_Appointments_Patientid");

                entity.Property(e => e.AppointmentId).HasComment("Unique identifier for each medical appointment");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasComment("The date when the record  was logically deleted from the system");

                entity.Property(e => e.DoctorId).HasComment("Foreign key referencing the unique identifier of the doctor associated with the appointment");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("IsEnabled ")
                    .HasComment("Indicates if the record  is currently active in the system");

                entity.Property(e => e.Observation)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Additional observation or notes related to the appointment");

                entity.Property(e => e.PatientId).HasComment("Foreign key referencing the unique identifier of the patient associated with the appointment");

                entity.Property(e => e.Status).HasComment("Indicates the Status of the Query, being:\r\n0:Scheduled\r\n1:Confirmed\r\n2: Cancelled");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointments_Doctors");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointments_Patients");
            });

            modelBuilder.Entity<Availability>(entity =>
            {
                entity.ToTable("Availability");

                entity.HasComment("Stores information about the availability schedule for doctors.");

                entity.HasIndex(e => e.DoctorId, "IX_Availability_DoctorId");

                entity.Property(e => e.AvailabilityId).HasComment("Unique identifier for each availability entry.");

                entity.Property(e => e.DayOfWeek).HasComment("The day of the week when the doctor is available:\r\n0: Monday\r\n1: Tuesday\r\n2: Wednesday\r\n3: Thursday\r\n4: Friday\r\n5: Saturday\r\n6: Sunday");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasComment("The date when the record  was logically deleted from the system");

                entity.Property(e => e.DoctorId).HasComment("Foreign key referencing the doctor associated with this availability");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasComment("The end time of the doctors availability for the specified day");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("IsEnabled ")
                    .HasComment("Indicates if the record  is currently active in the system");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasComment("The start time of the doctors availability for the specified day.");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Availabilities)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Availability_Doctors");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasComment("Stores information about medical doctors, their specialties, and contact details.");

                entity.HasIndex(e => new { e.Crm, e.DeletedAt }, "UK_Doctor_Crm_DeletedAt")
                    .IsUnique();

                entity.Property(e => e.DoctorId).HasComment("Unique identifier for each doctor in the system");

                entity.Property(e => e.AddressLineOne)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("The address of the doctor");

                entity.Property(e => e.AddressLineTwo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("The address of the doctor");

                entity.Property(e => e.Crm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("The CRM (Conselho Regional de Medicina) number of the doctor");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasComment("The date when the record  was logically deleted from the system");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("The email address of the doctor.");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("The first name of the doctor.");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("IsEnabled ")
                    .HasComment("Indicates if the record  is currently active in the system");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment(" The last name or surname of the doctor");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("The phone number of the doctor.");

                entity.Property(e => e.SpecialtyId).HasComment("Unique identifier for each medical specialty");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctors_Specialties");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.DeletedAt }, "UK_Exam_Name_DeletedAt")
                    .IsUnique();

                entity.Property(e => e.ExamId).HasComment("Unique identifier for each medical exam");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasComment("The date when the record  was logically deleted from the system");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Description of the exam");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("IsEnabled ")
                    .HasComment("Indicates if the record  is currently active in the system");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("The name of the exam");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 6)")
                    .HasComment("The Value of Exam");
            });

            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.ToTable("Insurance");

                entity.HasComment("Stores information about health insurance plans or medical health plans");

                entity.HasIndex(e => new { e.Name, e.DeletedAt }, "UK_Insurance_Name_DeletedAt")
                    .IsUnique();

                entity.Property(e => e.InsuranceId).HasComment("nique identifier for each health insurance plan");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasComment("The date when the record  was logically deleted from the system");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasComment("Description of the health insurance plan");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("IsEnabled ")
                    .HasComment("Indicates if the record  is currently active in the system");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("The name of the health insurance plan");

                entity.Property(e => e.PercentageTypeOne)
                    .HasColumnType("decimal(18, 6)")
                    .HasComment("A percentage value related to the health insurance plan");

                entity.Property(e => e.PercentageTypeThree)
                    .HasColumnType("decimal(18, 6)")
                    .HasComment("Another percentage value related to the health insurance plan");

                entity.Property(e => e.PercentageTypeTwo)
                    .HasColumnType("decimal(18, 6)")
                    .HasComment("Another percentage value related to the health insurance plan");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasComment("Stores information about patients and their medical records.");

                entity.HasIndex(e => new { e.Document, e.DeletedAt }, "UK_Patient_Document_DeletedAt")
                    .IsUnique();

                entity.Property(e => e.PatientId).HasComment("Patients table unique identifier");

                entity.Property(e => e.AddressLineOne)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("The address line one of the patient.");

                entity.Property(e => e.AddressLineTwo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("The address line two of the patient.");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("DateOfBirth ")
                    .HasComment("The date of birth of the patient");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasComment("The date when the record  was logically deleted from the system");

                entity.Property(e => e.Document)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Document of Patient");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("The email address of the patient.");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("The  name of the patient");

                entity.Property(e => e.Gender).HasComment("The gender of the patient\r\n0: Male, \r\n1: Female,\r\n2: NonBinary");

                entity.Property(e => e.InsuranceId).HasComment("Foreign key referencing the unique identifier of the insurance plan associated with the procedure");

                entity.Property(e => e.InsuranceType).HasComment("Type of Insurance");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("IsEnabled ")
                    .HasComment("Indicates if the record  is currently active in the system");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("The last name  of the patient");

                entity.Property(e => e.PhoneOne)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("The phone one  number of the patient.");

                entity.Property(e => e.PhoneTwo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("The phone two  number of the patient.");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.InsuranceId)
                    .HasConstraintName("FK_Patients_Insurance");
            });

            modelBuilder.Entity<Procedure>(entity =>
            {
                entity.HasComment("Stores information about medical procedures and exams performed on patients");

                entity.HasIndex(e => e.ExamId, "IX_Procedures_ExamId");

                entity.HasIndex(e => e.PatientId, "IX_Procedures_PatientId");

                entity.HasIndex(e => e.TechnicianId, "IX_Procedures_TechnicianId");

                entity.Property(e => e.ProcedureId).HasComment("Unique identifier for each medical procedure");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasComment("The date when the record  was logically deleted from the system");

                entity.Property(e => e.ExamId).HasComment("Foreign key referencing the unique identifier of the exam associated with the procedure");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("IsEnabled ")
                    .HasComment("Indicates if the record  is currently active in the system");

                entity.Property(e => e.Observation)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Additional observation or notes related to the procedure");

                entity.Property(e => e.PatientId).HasComment("Foreign key referencing the unique identifier of the patient associated with the procedure");

                entity.Property(e => e.TechnicianId).HasComment("Foreign key referencing the unique identifier of the technician performing the procedure");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Procedures)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Procedures_Exams");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Procedures)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Procedures_Patients");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.Procedures)
                    .HasForeignKey(d => d.TechnicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Procedures_Technicians");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.HasComment("Stores information about medical specialties");

                entity.HasIndex(e => new { e.Name, e.DeletedAt }, "UK_Speciality_Name_DeletedAt")
                    .IsUnique();

                entity.Property(e => e.SpecialtyId).HasComment("Unique identifier for each medical specialty");

                entity.Property(e => e.ConsultationValue)
                    .HasColumnType("decimal(18, 6)")
                    .HasComment("Value of Consultation ");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasComment("The date when the record  was logically deleted from the system");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasComment("escription of the medical specialty");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("IsEnabled ")
                    .HasComment("Indicates if the record  is currently active in the system");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasComment("The name of the medical specialty");
            });

            modelBuilder.Entity<Technician>(entity =>
            {
                entity.HasComment("Stores information about technicians or technical staff");

                entity.Property(e => e.AddressLineOne)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("The address line one  of the patient.");

                entity.Property(e => e.AddressLineTwo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("The address line two of the patient.");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasComment("The date when the record  was logically deleted from the system");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("The email address of the technician");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("The first name of the technician");

                entity.Property(e => e.InsuranceType).HasComment("Type of Insurance");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("IsEnabled ")
                    .HasComment("Indicates if the record  is currently active in the system");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("The last name or surname of the technician");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("The phone number of the technician");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
