using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MedicalClinic.Domain.Entities;
using System.Data;
using MedicalClinic.Infrastructure.EntitiesConfiguration;

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

        public bool HasChanges => ChangeTracker.HasChanges();

        //TODO : Verificar se precisa dos itens de configuração abaixo, se não, pode excluir

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Availability> Availabilities { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<Insurance> Insurances { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Procedure> Procedures { get; set; } = null!;
        public virtual DbSet<Specialty> Specialties { get; set; } = null!;
        public virtual DbSet<Technician> Technicians { get; set; } = null!;
        public virtual DbSet<Prescription> Prescriptions { get; set; } = null!;
        public virtual DbSet<Medication> Medications { get; set; } = null!;
        public virtual DbSet<Forwarding> Forwardings { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=MedicalClinicDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
                
                //TODO: Verificar como utilizar o GetDbConnection
                //public IDbConnection Connection => Database.GetDbConnection(); 
    }
        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AppointmentConfiguration());
            builder.ApplyConfiguration(new AvailabilityConfiguration());
            builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new ExamConfiguration());
            builder.ApplyConfiguration(new InsuranceConfiguration());
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new ProcedureConfiguration());
            builder.ApplyConfiguration(new SpecialtyConfiguration());
            builder.ApplyConfiguration(new TechnicianConfiguration());
            builder.ApplyConfiguration(new PrescriptionConfiguration());
            builder.ApplyConfiguration(new MedicationConfiguration());
            builder.ApplyConfiguration(new ForwardingConfiguration());

        }
    }
}
