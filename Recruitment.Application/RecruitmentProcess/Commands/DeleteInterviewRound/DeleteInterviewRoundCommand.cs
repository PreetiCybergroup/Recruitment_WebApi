using MediatR;
using Recruitment.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.Application.RecruitmentProcess.Commands.DeleteInterviewRound
{
   public class DeleteInterviewRoundCommand: IRequest
    {
        public string Id { get; set; }
        public class DeleteInterviewRoundCommandHandler : IRequestHandler<DeleteInterviewRoundCommand, Unit>
        {
            private readonly IInterviewRoundRepository _context;

            public DeleteInterviewRoundCommandHandler(IInterviewRoundRepository context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteInterviewRoundCommand request, CancellationToken cancellationToken)
            {

                _context.Remove(request.Id);
                return Unit.Value;
            }


        }
    }
}
