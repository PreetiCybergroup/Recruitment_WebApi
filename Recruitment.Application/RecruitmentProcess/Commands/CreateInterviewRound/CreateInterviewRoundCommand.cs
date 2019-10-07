using MediatR;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.Application.RecruitmentProcess.Commands.CreateInterviewRound
{
    public class CreateInterviewRoundCommand: IRequest
    {
        public string InterviewRoundTypeId { get; set; }
        public string InterviewProcessId { get; set; }
        public string InterviewerId { get; set; }
        public string FeedbackId { get; set; }
        public DateTime Date { get; set; }
        public class Handler : IRequestHandler<CreateInterviewRoundCommand, Unit>
        {
            private readonly IInterviewRoundRepository _context;
            private readonly IMediator _mediator;

            public Handler(IInterviewRoundRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateInterviewRoundCommand request, CancellationToken cancellationToken)
            {
                var entity = new InterviewRound
                {
                    InterviewRoundTypeId = request.InterviewRoundTypeId,
                    InterviewProcessId = request.InterviewProcessId,
                    InterviewerId = request.InterviewerId,
                    FeedbackId = request.FeedbackId,
                    Date = System.DateTime.Now
                };

                _context.Add(entity);
                return Unit.Value;
            }
        }

    }
}
