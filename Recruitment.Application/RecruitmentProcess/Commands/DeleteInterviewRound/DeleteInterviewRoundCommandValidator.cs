using FluentValidation;

namespace Recruitment.Application.RecruitmentProcess.Commands.DeleteInterviewRound
{
    public class DeleteInterviewRoundCommandValidator : AbstractValidator<DeleteInterviewRoundCommand>
    {
        public DeleteInterviewRoundCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
