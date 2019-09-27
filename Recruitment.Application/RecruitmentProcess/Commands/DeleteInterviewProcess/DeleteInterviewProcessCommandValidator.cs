using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Recruitment.Application.RecruitmentProcess.Commands.DeleteInterviewProcess
{
   public class DeleteInterviewProcessCommandValidator: AbstractValidator<DeleteInterviewProcessCommand>
    {
        public DeleteInterviewProcessCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
