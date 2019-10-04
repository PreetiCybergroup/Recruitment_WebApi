using FluentValidation;

namespace Recruitment.Application.Candidates.Commands.CreateCandidate
{
   public class CreateCandidateCommandValidator : AbstractValidator<CreateCandidateCommand>
    {
        public CreateCandidateCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(60).NotEmpty();
            RuleFor(x => x.Mobile).MaximumLength(10).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.DateOfBirth).MaximumLength(30).NotEmpty();
        }
    }
}
