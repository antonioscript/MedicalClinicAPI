using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class CanceledAppointmentRepository : ICanceledAppointmentRepository
    {
        private readonly IRepositoryAsync<CanceledAppointment> _repository;
        public CanceledAppointmentRepository(IRepositoryAsync<CanceledAppointment> repository)
        {
            _repository = repository;
        }

        public IQueryable<CanceledAppointment> Entities => _repository.Entities;

        public async Task<CanceledAppointment> AddAsync(CanceledAppointment entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(CanceledAppointment entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<CanceledAppointment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CanceledAppointment> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<CanceledAppointment>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(CanceledAppointment entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
