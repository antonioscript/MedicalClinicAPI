using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Exam;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Exams.Queries
{
    public class GetExamByIdQuery : IRequest<Result<ExamResponse>>
    {
        public int Id { get; set; }

        public class GetCompetitorCompanyByIdQueryHandler : IRequestHandler<GetExamByIdQuery, Result<ExamResponse>>
        {
            private readonly IExamRepository _repository;
            private readonly IMapper _mapper;

            public GetCompetitorCompanyByIdQueryHandler(IExamRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<ExamResponse>> Handle(GetExamByIdQuery query, CancellationToken cancellationToken)
            {
                var result = await _repository.Entities
                    .Where(d => d.Id == query.Id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var mappedCompetitorCompany = _mapper.Map<ExamResponse>(result);
                return Result<ExamResponse>.Success(mappedCompetitorCompany);
            }
        }
    }
}