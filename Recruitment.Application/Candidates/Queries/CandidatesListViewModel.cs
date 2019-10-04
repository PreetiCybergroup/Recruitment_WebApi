using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Recruitment.Domain.Entities;

namespace Recruitment.Application.Candidates.Queries
{
    public class CandidatesListViewModel
    {
        public IEnumerable<Candidate> candidates { get; set; }
        
    }
}

