using AutoMapper;
using MediatR;
using MongoDB.Driver;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.Application.Candidates.Queries
{
    public class GetCandidateListQueryHandler : IRequestHandler<GetAllCandidateDetailQuery, CandidatesListViewModel>
    {
        private readonly IResumeRepository _context;
        private readonly IMapper _mapper;

        public GetCandidateListQueryHandler(IResumeRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CandidatesListViewModel> Handle(GetAllCandidateDetailQuery request, CancellationToken cancellationToken)
        {
            var candidates = await _context.GetAll();
            
            return new CandidatesListViewModel
            {
                candidates =  _mapper.Map<IEnumerable<Candidate>>(candidates)
            };
        }
    }

}
