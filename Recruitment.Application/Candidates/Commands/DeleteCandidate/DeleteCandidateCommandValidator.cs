using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Application.Candidates.Commands.DeleteCandidate
{
   public class DeleteCandidateCommandValidator:AbstractValidator<DeleteCandidateCommand>
    {
        public DeleteCandidateCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
