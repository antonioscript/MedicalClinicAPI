using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class TechnicianRepository : ITechnicianRepository
    {
        private readonly IRepositoryAsync<Technician> _repository;
        public TechnicianRepository(IRepositoryAsync<Technician> repository)
        {
            _repository = repository;
        }

        public IQueryable<Technician> Entities => _repository.Entities.Where(c => !c.DeletedAt.HasValue);

        public async Task<Technician> AddAsync(Technician entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Technician entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.IsEnabled = false;
            await _repository.UpdateAsync(entity);
        }

        public async Task<List<Technician>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Technician> GetByIdAsync(int id)
        {
            //return await _repository.GetByIdAsync(id);
            var register = await _repository.GetByIdAsync(id);
            register = register != null && register.DeletedAt.HasValue ? null : register;
            return register;
        }

        public async Task<List<Technician>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(Technician entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
