using MediatR;
using Microsoft.EntityFrameworkCore;
using MedicalClinic.Infrastructure.Shared.Results;
using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Resource.Resources;
using System.Net.Mail;
using MedicalClinic.Application.DTOs.Medication;
using MedicalClinic.Application.DTOs.Forwarding;

namespace MedicalClinic.Application.Features.Prescriptions.Commands
{
    public class UpdatePrescriptionCommand : IRequest<Result<int>>
    {
        public UpdatePrescriptionCommand()
        {
            Medications = new HashSet<MedicationRequestFilter>();
            Forwardings = new HashSet<ForwardingRequestFilter>();
        }

        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Observation { get; set; } = null!;

        public virtual ICollection<MedicationRequestFilter> Medications { get; set; }
        public virtual ICollection<ForwardingRequestFilter> Forwardings { get; set; }


        public class UpdateCompetitorCompaniesCommandHandler : IRequestHandler<UpdatePrescriptionCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPrescriptionRepository _repository;

            public UpdateCompetitorCompaniesCommandHandler(IPrescriptionRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdatePrescriptionCommand command, CancellationToken cancellationToken)
            {
                var register = await _repository.GetByIdAsync(command.Id);

                if (register == null)
                {
                    return Result<int>.Fail(string.Format(SharedResource.MESSAGE_PRESCRIPTION_NOT_FOUND, command.Id));
                }
                else
                {
                    var registerExists = await _repository.Entities
                        .Where(d => d.Id != command.Id && d.AppointmentId == command.AppointmentId)
                        .Include(e => e.Medications)
                        .Include(e => e.Forwardings)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                    if (registerExists != null)
                    {
                        return Result<int>.Fail(string.Format(SharedResource.MESSAGE_PRESCRIPTION_EXISTS, command.AppointmentId));
                    }
                    else
                    {
                        register.AppointmentId = command.AppointmentId;
                        register.Observation = command.Observation ?? register.Observation;

                        #region Update Medication
                        foreach (var medication in command.Medications) 
                        { 
                            if (medication.Id == null || medication.Id == 0)
                            {
                                var newMedication = new Medication()
                                {
                                    PrescriptionId = command.Id,
                                    Name = medication.Name,
                                    SubstituteOne = medication.SubstituteOne,
                                    SubstituteTwo = medication.SubstituteTwo,
                                    Instruction = medication.Instruction
                                };

                                register.Medications.Add(newMedication);
                            }
                            else
                            {
                                var existingMedication = register.Medications.Where(a => a.Id == medication.Id).FirstOrDefault();
                                if (existingMedication != null)
                                {
                                    existingMedication.Id = medication.Id;

                                    existingMedication.Name = medication.Name;
                                    existingMedication.SubstituteOne = medication.SubstituteOne;
                                    existingMedication.SubstituteTwo = medication.SubstituteTwo;
                                    existingMedication.Instruction = medication.Instruction;
                                }
                            }
                        }
                        #endregion


                        #region Update Forwardings
                        foreach (var forwarding in command.Forwardings)
                        {
                            if (forwarding.Id == null || forwarding.Id == 0)
                            {
                                var newForwarding = new Forwarding()
                                {
                                    PrescriptionId = command.Id,
                                    SpecialtyId = (int)forwarding.SpecialtyId,
                                    Observation = forwarding.Observation,
                                };

                                register.Forwardings.Add(newForwarding);
                            }
                            else
                            {
                                var existingForwarding = register.Forwardings.Where(a => a.Id == forwarding.Id).FirstOrDefault();
                                if (existingForwarding != null)
                                {
                                    existingForwarding.Id = forwarding.Id;

                                    existingForwarding.PrescriptionId = (int)forwarding.PrescriptionId;
                                    existingForwarding.SpecialtyId = (int)forwarding.SpecialtyId;
                                    existingForwarding.Observation = forwarding.Observation;
                                }
                            }
                        }

                        #endregion

                        await _repository.UpdateAsync(register);
                        await _unitOfWork.Commit(cancellationToken);
                        return Result<int>.Success(register.Id);
                    }
                }

                
            }
        }
    }
}