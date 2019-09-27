using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using MediatR;


namespace Recruitment.Application.Candidates.Queries
{
   public class GetCandidateDetailQueryValidator : AbstractValidator<GetCandidateDetailQuery>
        {
            public GetCandidateDetailQueryValidator()
            {
                RuleFor(v => v.Id).NotEmpty();
            }
        }
    }
