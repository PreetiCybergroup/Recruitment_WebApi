using FluentValidation;

namespace Recruitment.Application.RecruitmentProcess.Commands.CreateInterviewProcess
{
   public class CreateInterviewProcessCommandValidator: AbstractValidator<CreateInterviewProcessCommand>
    {
        public CreateInterviewProcessCommandValidator()
        { 
          RuleFor(x => x.CandidateId).NotEmpty();
        }
    }
}
