
using Recruitment.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Recruitment.Domain.Entities;

namespace Recruitment.Application.RecruitmentProcess.Queries
{
    public class GetInterviewRoundDetailQuery : IRequest<InterviewRoundDetailModel>
    {
        public string Id { get; set; }
    }

    public class GetInterviewRoundDetailQueryHandler : IRequestHandler<GetInterviewRoundDetailQuery, InterviewRoundDetailModel>
    {
        private readonly IInterviewRoundRepository _context;

        public GetInterviewRoundDetailQueryHandler(IInterviewRoundRepository context)
        {
            _context = context;
        }

        public async Task<InterviewRoundDetailModel> Handle(GetInterviewRoundDetailQuery request, CancellationToken cancellationToken)
        {
            var interviewround = new InterviewRound();
            interviewround = await _context.GetById(request.Id);
            return InterviewRoundDetailModel.Create(interviewround);
        }
    }



}
