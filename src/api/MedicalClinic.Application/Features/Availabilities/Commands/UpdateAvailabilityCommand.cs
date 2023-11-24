using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Enums;
using MedicalClinic.Application.Enums;
using MedicalClinic.Resource.Resources;

namespace MedicalClinic.Application.Features.Availabilities.Commands
{
    public class UpdateAvailabilityCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }

        public AvailabilityDayOfWeekCodeDto DayOfWeek { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int AppointmentDuration { get; set; }

        public bool IsEnabled { get; set; }


        public class UpdateCompetitorCompaniesCommandHandler : IRequestHandler<UpdateAvailabilityCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IAvailabilityRepository _repository;

            public UpdateCompetitorCompaniesCommandHandler(IAvailabilityRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateAvailabilityCommand command, CancellationToken cancellationToken)
            {
                var register = await _repository.GetByIdAsync(command.Id);

                if (register == null)
                {
                    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_AVAILABILITY_NOT_FOUND, command.Id));
                }

                register.DoctorId = command.DoctorId;
                register.DayOfWeek = (AvailabilityDayOfWeekCode)command.DayOfWeek;
                register.StartTime = command.StartTime;
                register.EndTime = command.EndTime;
                register.AppointmentDuration = command.AppointmentDuration;
                register.IsEnabled = command.IsEnabled;

                await _repository.UpdateAsync(register);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(register.Id);
            }
        }
    }
}