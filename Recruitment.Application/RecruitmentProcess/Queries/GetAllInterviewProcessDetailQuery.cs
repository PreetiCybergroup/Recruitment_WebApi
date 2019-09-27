using MediatR;
using MongoDB.Driver;
using Recruitment.Domain.Entities;

namespace Recruitment.Application.RecruitmentProcess.Queries
{
   public class GetAllInterviewProcessDetailQuery: IRequest<InterviewProcessListDetailModel>
    {
        public IMongoCollection<InterviewProcess> interviewprocess { get; set; }
    }
}
