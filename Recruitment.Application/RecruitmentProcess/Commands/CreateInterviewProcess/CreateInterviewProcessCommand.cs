using MediatR;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.Application.RecruitmentProcess.Commands.CreateInterviewProcess
{
    public class CreateInterviewProcessCommand : IRequest
    {
        public string CandidateId { get; set; }
        public string FeedbackStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public class Handler : IRequestHandler<CreateInterviewProcessCommand, Unit>
        {
            private readonly IInterviewProcessRepository _context;
            private readonly IMediator _mediator;

            public Handler(IInterviewProcessRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateInterviewProcessCommand request, CancellationToken cancellationToken)
            {
                var entity = new InterviewProcess
                {
                    CandidateId = request.CandidateId,
                    FeedbackStatus = request.FeedbackStatus,
                    StartDate = System.DateTime.Now,
                    EndDate = System.DateTime.Now
                };

                 _context.Add(entity);
                return Unit.Value;
            }
        }
    }
}
