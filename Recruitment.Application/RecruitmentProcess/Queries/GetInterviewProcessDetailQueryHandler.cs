using MediatR;
using Recruitment.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Recruitment.Domain.Entities;

namespace Recruitment.Application.RecruitmentProcess.Queries
{
    public class GetInterviewProcessDetailQuery : IRequest<InterviewProcessDetailModel>
    {
        public string Id { get; set; }
        public class GetInterviewProcessDetailQueryHandler : IRequestHandler<GetInterviewProcessDetailQuery, InterviewProcessDetailModel>
        {
            private readonly IInterviewProcessRepository _context;

            public GetInterviewProcessDetailQueryHandler(IInterviewProcessRepository context)
            {
                _context = context;
            }

            public async Task<InterviewProcessDetailModel> Handle(GetInterviewProcessDetailQuery request, CancellationToken cancellationToken)
            {
                var interviewprocess = new InterviewProcess();
                interviewprocess = await _context.GetById(request.Id);

                return InterviewProcessDetailModel.Create(interviewprocess);

            }
        }
     }

  }
    

    