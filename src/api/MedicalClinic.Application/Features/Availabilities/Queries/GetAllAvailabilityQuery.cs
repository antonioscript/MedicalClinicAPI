using AutoMapper;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MedicalClinic.Application.Features.Availabilities.Queries
{
    public class GetAllAvailabilityQuery : IRequest<List<AvailabilityResponse>>
    {
        public GetAllAvailabilityQuery()
        {

        }
    }

    public class GetAllAvailabilityQueryHandler : IRequestHandler<GetAllAvailabilityQuery, List<AvailabilityResponse>>
    {
        private readonly IAvailabilityRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAvailabilityQueryHandler(IAvailabilityRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<List<AvailabilityResponse>> Handle(GetAllAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                //.Include(a => a.Doctor)
                .AsNoTracking()
                .ToListAsync();

            var listResult = _mapper.Map<List<AvailabilityResponse>>(list);

            return listResult;
        }
    }

}
