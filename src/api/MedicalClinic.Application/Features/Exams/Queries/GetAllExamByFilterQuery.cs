using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Exam;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Exams.Queries
{
    public class GetAllExamByFilterQuery : IRequest<Result<List<ExamResponse>>>
    {
        public ExamRequestFilter AppRequest { get; set; }

        public GetAllExamByFilterQuery(ExamRequestFilter appRequest)
        {
            AppRequest = appRequest;
        }

    }

    public class GetAllCompetitorCompaniesByFilterQueryHandler : IRequestHandler<GetAllExamByFilterQuery, Result<List<ExamResponse>>>
    {
        private readonly IExamRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCompetitorCompaniesByFilterQueryHandler(IExamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ExamResponse>>> Handle(GetAllExamByFilterQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .Where(p =>
                       (String.IsNullOrEmpty(request.AppRequest.Name) || p.Name.Contains(request.AppRequest.Name))
                       && (String.IsNullOrEmpty(request.AppRequest.Description) || p.Description.Contains(request.AppRequest.Description))

                       && (request.AppRequest.Value == null || p.Value == request.AppRequest.Value)
                       && (request.AppRequest.IsEnabled == null || p.IsEnabled == request.AppRequest.IsEnabled)
                        )
                .ToListAsync();

            var listResult = _mapper.Map<List<ExamResponse>>(list);
            return Result<List<ExamResponse>>.Success(listResult); ;
        }

    }
}