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
           var candidate = await  _context.GetById(request.Id);
           return CandidateDetailModel.Create(candidate);
        }
    }
}
