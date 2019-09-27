using MediatR;
using Recruitment.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.Application.RecruitmentProcess.Commands.DeleteInterviewProcess
{
    public class DeleteInterviewProcessCommand : IRequest
    {
        public string Id { get; set; }

        public class DeleteInterviewProcessCommandHandler : IRequestHandler<DeleteInterviewProcessCommand, Unit>
        {
            private readonly IInterviewProcessRepository _context;

            public DeleteInterviewProcessCommandHandler(IInterviewProcessRepository context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteInterviewProcessCommand request, CancellationToken cancellationToken)
            {

                _context.Remove(request.Id);
                return Unit.Value;
            }


        }
    }
}