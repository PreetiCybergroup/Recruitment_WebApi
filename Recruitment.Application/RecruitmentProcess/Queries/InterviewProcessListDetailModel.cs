using System;
using System.Collections.Generic;
using MediatR;
using Recruitment.Domain.Entities;


namespace Recruitment.Application.RecruitmentProcess.Queries
{
  public  class InterviewProcessListDetailModel
    {
        public IEnumerable<InterviewProcess> interviewprocesslist;
    }
}
