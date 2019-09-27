using FluentValidation;

namespace Recruitment.Application.RecruitmentProcess.Commands.UpdateInterviewRound
{
  public class UpdateInterviewRoundCommandValidator: AbstractValidator<UpdateInterviewRoundCommand>
    {
        public UpdateInterviewRoundCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }

    }
}
