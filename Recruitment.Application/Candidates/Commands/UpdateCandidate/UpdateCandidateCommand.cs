using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Recruitment.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Recruitment.Domain.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Net;
using System.IO;
using Recruitment.Application.Candidates.Common;

namespace Recruitment.Application.Candidates.Commands.UpdateCandidate
{
    public class UpdateCandidateCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Resume { get; set; }
        public string FileName { get; set; }
        public string ResumeLink { get; set; }

        public class Handler : IRequestHandler<UpdateCandidateCommand, Unit>
        {
            private readonly IResumeRepository _context;

            public Handler(IResumeRepository context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
            {

                var candidateinfo = new Candidate();
                candidateinfo.Id = request.Id;
                candidateinfo.DateOfBirth = request.DateOfBirth;
                candidateinfo.Email = request.Email;
                candidateinfo.Mobile = request.Mobile;
                candidateinfo.ResumePath = request.ResumeLink;
                
                await _context.Update(candidateinfo);
                return Unit.Value;

                
            }

            
        }
    }
}