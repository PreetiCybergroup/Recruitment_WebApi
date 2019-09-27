using System;
using System.Linq.Expressions;
using Recruitment.Domain.Entities;

namespace Recruitment.Application.RecruitmentProcess.Queries
{
   public class InterviewProcessDetailModel
    {
        public string candidateId { get; set; }
        public string InterviewRound { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        

        public static Expression<Func<InterviewProcess, InterviewProcessDetailModel>> Projection
        {
            get
            {
                return interviewProcessModel => new InterviewProcessDetailModel
                {
                    candidateId = interviewProcessModel.CandidateId,
                    Status = interviewProcessModel.FeedbackStatus
                };
            }
        }

        public static InterviewProcessDetailModel Create(InterviewProcess interviewProcess)
        {
            return Projection.Compile().Invoke(interviewProcess);
        }
    }
}
