using AutoMapper;
using MediatR;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Resource.Resources;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Exams.Commands
{
    public partial class CreateExamCommand : IRequest<Result<int>>
    {
        public string Name { get; set; } 
        public string? Description { get; set; }
        public decimal Value { get; set; }

        public bool IsEnabled { get; set; }
    }


    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, Result<int>>
    {
        private readonly IExamRepository _repository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreateExamCommandHandler(IExamRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            var registerExists = await _repository.Entities
               .Where(d => d.Name == request.Name)
               .AsNoTracking()
               .FirstOrDefaultAsync();

            if (registerExists != null)
            {
                return Result<int>.Fail(string.Format(SharedResource.MESSAGE_EXAM_EXISTS, request.Name));
            }

            var register = _mapper.Map<Exam>(request);
            await _repository.AddAsync(register);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(register.Id);
        }
    }
}
