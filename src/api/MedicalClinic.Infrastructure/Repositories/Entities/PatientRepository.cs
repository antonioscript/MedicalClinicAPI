using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IRepositoryAsync<Patient> _repository;
        public PatientRepository(IRepositoryAsync<Patient> repository)
        {
            _repository = repository;
        }

        public IQueryable<Patient> Entities => _repository.Entities.Where(c => !c.DeletedAt.HasValue);

        public async Task<Patient> AddAsync(Patient entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Patient entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.IsEnabled = false;
            await _repository.UpdateAsync(entity);
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            //return await _repository.GetByIdAsync(id);
            var register = await _repository.GetByIdAsync(id);
            register = register != null && register.DeletedAt.HasValue ? null : register;
            return register;
        }

        public async Task<List<Patient>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(Patient entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
