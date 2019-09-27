using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Recruitment.Domain.Entities;

namespace Recruitment.Application.Candidates.Queries
{
    public class CandidatesListViewModel
    {
        public IList<Candidate> candidates { get; set; }
        
    }
}

