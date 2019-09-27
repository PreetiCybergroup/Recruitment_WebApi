using FluentValidation;

namespace Recruitment.Application.RecruitmentProcess.Commands.UpdateInterviewProcess
{
   public class UpdateInterviewProcessCommandValidator: AbstractValidator<UpdateInterviewProcessCommand>
    {
        public UpdateInterviewProcessCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
