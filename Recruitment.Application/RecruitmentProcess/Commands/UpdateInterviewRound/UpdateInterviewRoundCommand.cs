using MediatR;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.Application.RecruitmentProcess.Commands.UpdateInterviewRound
{
    public class UpdateInterviewRoundCommand : IRequest
    {
        public string Id { get; set; }
        public string FeedbackId { get; set; }
        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public class Handler : IRequestHandler<UpdateInterviewRoundCommand, Unit>
        {
            private readonly IInterviewRoundRepository _context;

            public Handler(IInterviewRoundRepository context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateInterviewRoundCommand request, CancellationToken cancellationToken)
            {
                var interviewRound = new InterviewRound();
                interviewRound.Id = request.Id;
                interviewRound.FeedbackId = request.FeedbackId;
                interviewRound.Date = System.DateTime.Now;
                _context.Update(interviewRound);
                return Unit.Value;
            }
        }
    }
}
