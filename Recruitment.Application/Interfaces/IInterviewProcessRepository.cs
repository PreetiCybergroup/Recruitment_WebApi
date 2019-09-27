
using MongoDB.Driver;
using Recruitment.Domain.Entities;

namespace Recruitment.Application.Interfaces
{
  public interface IInterviewProcessRepository : IMongoRepository<InterviewProcess>
    {
        //IMongoCollection<InterviewProcess> DbSet { get; }
    }
}
