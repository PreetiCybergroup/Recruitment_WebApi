using MediatR;
using MongoDB.Driver;
using Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Application.Candidates.Queries
{
    public class GetAllCandidateDetailQuery: IRequest<CandidatesListViewModel>
    {
        public IList<Candidate> candidates { get; set; }
        //public string keywords { get; set; }
    }
}
