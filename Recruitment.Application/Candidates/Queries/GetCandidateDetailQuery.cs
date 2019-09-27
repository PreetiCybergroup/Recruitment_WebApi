using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace Recruitment.Application.Candidates.Queries
{
   public class GetCandidateDetailQuery : IRequest<CandidateDetailModel>
   {
        public string Id { get; set; }
    }
   
}
