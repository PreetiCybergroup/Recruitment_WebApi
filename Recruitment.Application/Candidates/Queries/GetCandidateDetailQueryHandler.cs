using MediatR;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Recruitment.Application.Candidates.Queries
{
    public class GetCandidateDetailQueryHandler : IRequestHandler<GetCandidateDetailQuery, CandidateDetailModel>
    {
        private readonly IResumeRepository _context;

        public GetCandidateDetailQueryHandler(IResumeRepository context)
        {
            _context = context;
        }

        public async Task<CandidateDetailModel> Handle(GetCandidateDetailQuery request, CancellationToken cancellationToken)
        {
            Candidate candidate = new Candidate();
            var candidateEntity =  await _context.DbSet.FindAsync<Candidate>(Builders<Candidate>.Filter.Eq(x => x.Id, request.Id)); 
            if (candidateEntity != null)
            {
              candidate =  candidateEntity.FirstOrDefault();
            }
           return CandidateDetailModel.Create(candidate);
        }
    }
}
