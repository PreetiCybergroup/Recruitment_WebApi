using Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Recruitment.Application.RecruitmentProcess.Queries
{
   public class InterviewRoundDetailModel
    {
        public string InterviewRoundTypeId { get; set; }

        public string InterviewProcessId { get; set; }

        public string Interviewer { get; set; }

        public string FeedbackId { get; set; }
        public DateTime Date { get; set; }

        public static Expression<Func<InterviewRound, InterviewRoundDetailModel>> Projection
        {
            get
            {
                return interviewRoundModel => new InterviewRoundDetailModel
                {
                    InterviewRoundTypeId = interviewRoundModel.InterviewRoundTypeId,
                    InterviewProcessId = interviewRoundModel.InterviewProcessId,
                    Interviewer = interviewRoundModel.Interviewer,
                    FeedbackId =interviewRoundModel.FeedbackId,
                    Date = interviewRoundModel.Date
                 };
            }
        }

        public static InterviewRoundDetailModel Create(InterviewRound interviewRound)
        {
            return Projection.Compile().Invoke(interviewRound);
        }
    }
}
