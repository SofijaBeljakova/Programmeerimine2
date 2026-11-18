using FluentValidation;

namespace KooliProjekt.Application.Features.TodoItems
{
    public class DeleteFileCommandValidator : AbstractValidator<DeleteFileCommand>
    {
        public DeleteFileCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.");

            RuleFor(x => x.FileName)
                .NotEmpty().WithMessage("File name is required.");
        }
    }
}