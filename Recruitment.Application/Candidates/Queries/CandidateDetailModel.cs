using Recruitment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Recruitment.Application.Candidates.Queries
{
   public class CandidateDetailModel
    {
        //public string Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ResumePath { get; set; }
        public string TechnicalSkills { get; set; }
        public string Experience { get; set; }
        public string Keyword { get; set; }
       
        public static Expression<Func<Candidate, CandidateDetailModel>> Projection
        {
            get
            {
                return candidateModel => new CandidateDetailModel
                {
                    Name = candidateModel.Name,
                    DateOfBirth = candidateModel.DateOfBirth,
                    Email = candidateModel.Email,
                    Mobile = candidateModel.Mobile,
                    ResumePath = candidateModel.ResumePath,
                    TechnicalSkills = candidateModel.TechnicalSkills,
                    Experience = candidateModel.Experience,
                    Keyword = candidateModel.Keyword
                };
            }
        }

        public static CandidateDetailModel Create(Candidate candidate)
        {
            return Projection.Compile().Invoke(candidate);
        }
    }
}
