using System;
using System.Linq.Expressions;
using Recruitment.Domain.Entities;

namespace Recruitment.Application.RecruitmentProcess.Queries
{
   public class InterviewProcessDetailModel
    {
        //public string candidateId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string candidateName { get; set; }
        

        public static Expression<Func<InterviewProcess, InterviewProcessDetailModel>> Projection
        {
            get
            {
                return interviewProcessModel => new InterviewProcessDetailModel
                {
                    candidateName = interviewProcessModel.candidateName,
                    Status = interviewProcessModel.FeedbackStatus,
                    Date = interviewProcessModel.StartDate
                };
            }
        }

        public static InterviewProcessDetailModel Create(InterviewProcess interviewProcess)
        {
            return Projection.Compile().Invoke(interviewProcess);
        }
    }
}
