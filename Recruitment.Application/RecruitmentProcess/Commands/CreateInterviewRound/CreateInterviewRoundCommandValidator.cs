using FluentValidation;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;

namespace Recruitment.Application.RecruitmentProcess.Commands.CreateInterviewRound
{
   public class CreateInterviewRoundCommandValidator: AbstractValidator<CreateInterviewRoundCommand>
    {
        public CreateInterviewRoundCommandValidator()
        {
            RuleFor(x => x.InterviewProcessId).NotEmpty();
            RuleFor(x => x.InterviewRoundTypeId).NotEmpty();
        }
        
    }
}
