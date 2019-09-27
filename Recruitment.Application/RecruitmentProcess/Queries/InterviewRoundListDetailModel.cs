using MediatR;
using Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Application.RecruitmentProcess.Queries
{
    public class InterviewRoundListDetailModel : IRequest<InterviewRound>
    {
        public IEnumerable<InterviewRound> interviewRoundList;
    }

}
