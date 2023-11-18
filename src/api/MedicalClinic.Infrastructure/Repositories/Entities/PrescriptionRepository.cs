using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly IRepositoryAsync<Prescription> _repository;
        public PrescriptionRepository(IRepositoryAsync<Prescription> repository)
        {
            _repository = repository;
        }

        public IQueryable<Prescription> Entities => _repository.Entities;

        public async Task<Prescription> AddAsync(Prescription entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Prescription entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<Prescription>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Prescription> GetByIdAsync(int id)
        {
            //return await _repository.GetByIdAsync(id);
            var register = await _repository.GetByIdAsync(id);
            return register;
        }

        public async Task<List<Prescription>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(Prescription entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
