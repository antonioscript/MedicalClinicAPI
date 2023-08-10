using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.MedicalClinic.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AppointmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Appointment>> GetAppointmentListAsync()
        {
            return await _dbContext.Appointments.ToListAsync();
        }


        //private readonly IRepositoryAsync<Appointment> _repository;
        //public AppointmentRepository(IRepositoryAsync<Appointment> repository)
        //{
        //    _repository = repository;
        //}

        //public IQueryable<Appointment> Entities => _repository.Entities.Where(d => !d.DeletedAt.HasValue);

        //public async Task<Appointment> AddAsync(Appointment entity)
        //{
        //    return await _repository.AddAsync(entity);
        //}

        //public async Task DeleteAsync(Appointment entity)
        //{
        //    entity.DeletedAt = DateTime.Now;
        //    await _repository.UpdateAsync(entity);
        //}

        //public async Task<List<Appointment>> GetAllAsync()
        //{
        //    return await _repository.GetAllAsync();
        //}

        //public async Task<Appointment> GetByIdAsync(int id)
        //{
        //    //return await _repository.GetByIdAsync(id);
        //    var register = await _repository.GetByIdAsync(id);
        //    register = register != null && register.DeletedAt.HasValue ? null : register;
        //    return register;
        //}

        //public async Task<List<Appointment>> GetPagedReponseAsync(int pageNumber, int pageSize)
        //{
        //    return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        //}

        //public async Task UpdateAsync(Appointment entity)
        //{
        //    await _repository.UpdateAsync(entity);
        //}
    }
}
