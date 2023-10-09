using AutoMapper;
using MediatR;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;

namespace MedicalClinic.Application.Features.Procedures.Commands
{
    public partial class CreateProcedureCommand : IRequest<Result<int>>
    {
        public int PatientId { get; set; }
        public int TechnicianId { get; set; }
        public int ExamId { get; set; }
        public string? Observation { get; set; }

        public bool IsEnabled { get; set; }
    }


    public class CreateProcedureCommandHandler : IRequestHandler<CreateProcedureCommand, Result<int>>
    {
        private readonly IProcedureRepository _repository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreateProcedureCommandHandler(IProcedureRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateProcedureCommand request, CancellationToken cancellationToken)
        {
            //var registerExists = await _repository.Entities
            //   .Where(d => d.Name == request.Name)
            //   .AsNoTracking()
            //   .FirstOrDefaultAsync();

            //if (registerExists != null)
            //{
            //    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_Procedure_EXISTS, request.Name));
            //}

            var register = _mapper.Map<Procedure>(request);
            await _repository.AddAsync(register);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(register.Id);
        }
    }
}
