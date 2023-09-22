using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly IRepositoryAsync<Insurance> _repository;
        public InsuranceRepository(IRepositoryAsync<Insurance> repository)
        {
            _repository = repository;
        }

        public IQueryable<Insurance> Entities => _repository.Entities.Where(c => !c.DeletedAt.HasValue);

        public async Task<Insurance> AddAsync(Insurance entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Insurance entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.IsEnabled = false;
            await _repository.UpdateAsync(entity);
        }

        public async Task<List<Insurance>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Insurance> GetByIdAsync(int id)
        {
            //return await _repository.GetByIdAsync(id);
            var register = await _repository.GetByIdAsync(id);
            register = register != null && register.DeletedAt.HasValue ? null : register;
            return register;
        }

        public async Task<List<Insurance>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(Insurance entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
