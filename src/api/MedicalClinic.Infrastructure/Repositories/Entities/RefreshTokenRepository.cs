using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Domain.Entities.Identity;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IRepositoryAsync<RefreshToken> _repository;
        public RefreshTokenRepository(IRepositoryAsync<RefreshToken> repository)
        {
            _repository = repository;
        }

        public IQueryable<RefreshToken> Entities => _repository.Entities;

        public async Task<RefreshToken> AddAsync(RefreshToken entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(RefreshToken entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<RefreshToken>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<RefreshToken> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<RefreshToken>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(RefreshToken entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
