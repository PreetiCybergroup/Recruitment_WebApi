using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;
using Recruitment.Application.Candidates.Common;

namespace Recruitment.Application.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateCommand : IRequest
    {
       // public string UserName { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Resume { get; set; }
        public string FileName { get; set; }
        //public string ResumeLink { get; set; }
        public string Keyword { get; set; }
        public string TechnicalSkills { get; set; }
        public string Experience { get; set; }

        public class Handler : IRequestHandler<CreateCandidateCommand, Unit>
        {
            private readonly IResumeRepository _context;
            private readonly IMediator _mediator;

            public Handler(IResumeRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
            {
                // Resume Code
                //var ResumeLink = UploadResume.uploadResumeDoc(_context.ftpPath, request.FileName, request.Resume, _context.ftpUserName, _context.ftpPassword);
                var ResumeLink = UploadResume.uploadResumeDoc(request.FileName, request.Resume);
                var entity = new Candidate
                {
                    UserName = request.Name,
                    Name =        request.Name,
                    DateOfBirth = request.DateOfBirth,
                    Email =       request.Email,
                    Mobile =      request.Mobile,
                    ResumePath =  ResumeLink,
                    Keyword = request.Keyword,
                    TechnicalSkills = request.TechnicalSkills,
                    Experience = request.Experience
                };
                  _context.Add(entity);
                
                return Unit.Value;
            }

        }
    }
}

        
