using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly IRepositoryAsync<Medication> _repository;
        public MedicationRepository(IRepositoryAsync<Medication> repository)
        {
            _repository = repository;
        }

        public IQueryable<Medication> Entities => _repository.Entities;

        public async Task<Medication> AddAsync(Medication entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Medication entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<Medication>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Medication> GetByIdAsync(int id)
        {
            //return await _repository.GetByIdAsync(id);
            var register = await _repository.GetByIdAsync(id);
            return register;
        }

        public async Task<List<Medication>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(Medication entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
