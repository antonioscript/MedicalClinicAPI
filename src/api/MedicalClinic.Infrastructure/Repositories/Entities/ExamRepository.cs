using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Infrastructure.Repositories.Entities
{
    public class ExamRepository : IExamRepository
    {
        private readonly IRepositoryAsync<Exam> _repository;
        public ExamRepository(IRepositoryAsync<Exam> repository)
        {
            _repository = repository;
        }

        public IQueryable<Exam> Entities => _repository.Entities.Where(c => !c.DeletedAt.HasValue);

        public async Task<Exam> AddAsync(Exam entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Exam entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.IsEnabled = false;
            await _repository.UpdateAsync(entity);
        }

        public async Task<List<Exam>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Exam> GetByIdAsync(int id)
        {
            //return await _repository.GetByIdAsync(id);
            var register = await _repository.GetByIdAsync(id);
            register = register != null && register.DeletedAt.HasValue ? null : register;
            return register;
        }

        public async Task<List<Exam>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetPagedReponseAsync(pageNumber, pageSize);
        }

        public async Task UpdateAsync(Exam entity)
        {
            await _repository.UpdateAsync(entity);
        }

    }
}
