using System;
using System.Collections.Generic;
using System.Text;
using Recruitment.Domain.Entities;

namespace Recruitment.Application.Interfaces
{
  public  interface IInterviewRoundRepository : IMongoRepository<InterviewRound>
    {
    }
}
