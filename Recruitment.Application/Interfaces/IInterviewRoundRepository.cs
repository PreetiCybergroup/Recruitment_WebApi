using Recruitment.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruitment.Application.Interfaces
{
  public  interface IInterviewRoundRepository : IMongoRepository<InterviewRound>
    {
        Task<IEnumerable<Domain.Entities.InterviewRound>> GetAll(string id);
    }
}
