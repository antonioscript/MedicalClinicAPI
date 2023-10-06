using AutoMapper;
using MedicalClinic.Application.DTOs.Exam;
using MedicalClinic.Application.Interfaces.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MedicalClinic.Application.Features.Exams.Queries
{
    public class GetAllExamQuery : IRequest<List<ExamResponse>>
    {
        public GetAllExamQuery()
        {

        }
    }

    public class GetAllExamQueryHandler : IRequestHandler<GetAllExamQuery, List<ExamResponse>>
    {
        private readonly IExamRepository _repository;
        private readonly IMapper _mapper;

        public GetAllExamQueryHandler(IExamRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<List<ExamResponse>> Handle(GetAllExamQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.Entities
                .AsNoTracking()
                .ToListAsync();

            var listResult = _mapper.Map<List<ExamResponse>>(list);

            return listResult;
        }
    }

}
