using Recruitment.Domain.Entities;


namespace Recruitment.Application.Interfaces
{
   public interface IResumeRepository: IMongoRepository<Candidate>
    {
        string ftpPath { get; }
        string ftpUserName { get; }
        string ftpPassword { get; }
       
   }
}
