using AutoMapper;
using MediatR;
using MedicalClinic.Application.DTOs.Exam;
using MedicalClinic.Application.Extensions;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using MedicalClinic.Infrastructure.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Application.Features.Exams.Queries
{
    public class GetAllPagedExamQuery : IRequest<PaginatedResult<ExamResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPagedExamQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllPagedExamQueryHandler : IRequestHandler<GetAllPagedExamQuery, PaginatedResult<ExamResponse>>
    {
        private readonly IExamRepository _repository;
        private readonly IMapper _mapper;


        public GetAllPagedExamQueryHandler(IExamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<ExamResponse>> Handle(GetAllPagedExamQuery request, CancellationToken cancellationToken)
        {
            var paginatedList = await _repository.Entities
                .Where(b => b.IsEnabled)
                .AsNoTracking()
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var listResult = _mapper.Map<PaginatedResult<ExamResponse>>(paginatedList);
            return listResult;
        }

    }
}