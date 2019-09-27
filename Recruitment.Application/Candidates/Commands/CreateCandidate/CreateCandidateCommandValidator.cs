using FluentValidation;

namespace Recruitment.Application.Candidates.Commands.CreateCandidate
{
   public class CreateCandidateCommandValidator : AbstractValidator<CreateCandidateCommand>
    {
        public CreateCandidateCommandValidator()
        {
           // RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(60).NotEmpty();
            RuleFor(x => x.Mobile).MaximumLength(15).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.DateOfBirth).MaximumLength(30).NotEmpty();
            RuleFor(x => x.ResumeLink).MaximumLength(-1).NotEmpty();
        }
    }
}
