using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Recruitment.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Recruitment.Domain.Entities;
using MongoDB.Driver;

namespace Recruitment.Application.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateCommand : IRequest
    {
        public string Id { get; set; }

        public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand,Unit>
        {
            private readonly IResumeRepository _context;

            public DeleteCandidateCommandHandler(IResumeRepository context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
            {
                _context.Remove(request.Id);
                return Unit.Value;
            }

        }
    }
}