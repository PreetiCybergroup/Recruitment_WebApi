using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Recruitment.Application.Interfaces;
using System.Threading;
using Recruitment.Domain.Entities;

namespace Recruitment.Application.RecruitmentProcess.Commands.UpdateInterviewProcess
{
    public class UpdateInterviewProcessCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string FeedbackStatus { get; set; }
        public string EndDate { get; set; }

        public class Handler : IRequestHandler<UpdateInterviewProcessCommand, bool>
        {
            private readonly IInterviewProcessRepository _context;

            public Handler(IInterviewProcessRepository context)
            {
                _context = context;
            }

            public async Task<bool> Handle(UpdateInterviewProcessCommand request, CancellationToken cancellationToken)
            {
                var interviewProcess = new InterviewProcess();
                interviewProcess.Id = request.Id;
                interviewProcess.FeedbackStatus = request.FeedbackStatus;
                interviewProcess.EndDate = System.DateTime.Now;
                var result = await _context.Update(interviewProcess);
                return result;
            }
        }
    }
}