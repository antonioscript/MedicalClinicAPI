using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly IRepositoryAsync<Specialty> _repository;
        public SpecialtyRepository(IRepositoryAsync<Specialty> repository)
        {
            _repository = repository;
        }

        public IQueryable<Specialty> Entities => _repository.Entities.Where(c => !c.DeletedAt.HasValue);

        public async Task<Specialty> AddAsync(Specialty entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Specialty entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.IsEnabled = false;
            await _repository.UpdateAsync(entity);
        }

        public async Task<List<Specialty>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Specialty> GetByIdAsync(int id)
        {
            //return await _repository.GetByIdAsync(id);
            var register = await _repository.GetByIdAsync(id);
            register = register != null && register.DeletedAt.HasValue ? null : register;
            return register;
        }

        public async Task<List<Specialty>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(Specialty entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
