using AutoMapper;
using MediatR;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Resource.Resources;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Technicians.Commands
{
    public partial class CreateTechnicianCommand : IRequest<Result<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public string? AddressLineOne { get; set; }
        public string? AddressLineTwo { get; set; }
        public byte? InsuranceType { get; set; }

        public bool IsEnabled { get; set; }
    }


    public class CreateTechnicianCommandHandler : IRequestHandler<CreateTechnicianCommand, Result<int>>
    {
        private readonly ITechnicianRepository _repository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreateTechnicianCommandHandler(ITechnicianRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateTechnicianCommand request, CancellationToken cancellationToken)
        {
            var registerExists = await _repository.Entities
               .Where(d => d.FirstName == request.FirstName && d.LastName == request.LastName)
               .AsNoTracking()
               .FirstOrDefaultAsync();

            if (registerExists != null)
            {
                return Result<int>.Fail(string.Format(SharedResource.MESSAGE_TECHNICIAN_EXISTS, request.FirstName, request.LastName));
            }

            var register = _mapper.Map<Technician>(request);
            await _repository.AddAsync(register);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(register.Id);
        }
    }
}
