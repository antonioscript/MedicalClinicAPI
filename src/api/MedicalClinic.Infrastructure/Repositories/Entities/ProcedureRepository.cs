using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class ProcedureRepository : IProcedureRepository
    {
        private readonly IRepositoryAsync<Procedure> _repository;
        public ProcedureRepository(IRepositoryAsync<Procedure> repository)
        {
            _repository = repository;
        }

        public IQueryable<Procedure> Entities => _repository.Entities.Where(c => !c.DeletedAt.HasValue);

        public async Task<Procedure> AddAsync(Procedure entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Procedure entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.IsEnabled = false;
            await _repository.UpdateAsync(entity);
        }

        public async Task<List<Procedure>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Procedure> GetByIdAsync(int id)
        {
            //return await _repository.GetByIdAsync(id);
            var register = await _repository.GetByIdAsync(id);
            register = register != null && register.DeletedAt.HasValue ? null : register;
            return register;
        }

        public async Task<List<Procedure>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(Procedure entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
