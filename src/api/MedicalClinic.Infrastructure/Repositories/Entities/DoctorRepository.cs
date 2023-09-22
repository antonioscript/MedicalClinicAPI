using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IRepositoryAsync<Doctor> _repository;
        public DoctorRepository(IRepositoryAsync<Doctor> repository)
        {
            _repository = repository;
        }

        public IQueryable<Doctor> Entities => _repository.Entities.Where(c => !c.DeletedAt.HasValue);

        public async Task<Doctor> AddAsync(Doctor entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Doctor entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.IsEnabled = false;
            await _repository.UpdateAsync(entity);
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            //return await _repository.GetByIdAsync(id);
            var register = await _repository.GetByIdAsync(id);
            register = register != null && register.DeletedAt.HasValue ? null : register;
            return register;
        }

        public async Task<List<Doctor>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(Doctor entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
