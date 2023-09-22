using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly IRepositoryAsync<Availability> _repository;
        public AvailabilityRepository(IRepositoryAsync<Availability> repository)
        {
            _repository = repository;
        }

        public IQueryable<Availability> Entities => _repository.Entities.Where(c => !c.DeletedAt.HasValue);

        public async Task<Availability> AddAsync(Availability entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Availability entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.IsEnabled = false;
            await _repository.UpdateAsync(entity);
        }

        public async Task<List<Availability>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Availability> GetByIdAsync(int id)
        {
            //return await _repository.GetByIdAsync(id);
            var register = await _repository.GetByIdAsync(id);
            register = register != null && register.DeletedAt.HasValue ? null : register;
            return register;
        }

        public async Task<List<Availability>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(Availability entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
