using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class ForwardingRepository : IForwardingRepository
    {
        private readonly IRepositoryAsync<Forwarding> _repository;
        public ForwardingRepository(IRepositoryAsync<Forwarding> repository)
        {
            _repository = repository;
        }

        public IQueryable<Forwarding> Entities => _repository.Entities;

        public async Task<Forwarding> AddAsync(Forwarding entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Forwarding entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<Forwarding>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Forwarding> GetByIdAsync(int id)
        {
            //return await _repository.GetByIdAsync(id);
            var register = await _repository.GetByIdAsync(id);
            return register;
        }

        public async Task<List<Forwarding>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(Forwarding entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
