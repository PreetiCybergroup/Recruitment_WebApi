using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Domain.Exceptions
{
    public class AddCandidateInvalidException:Exception
    {
        public AddCandidateInvalidException(string CandidateInfo, Exception ex)
            : base($"Candidate details \"{CandidateInfo}\" is invalid.", ex)
        {
        }
    }
}
