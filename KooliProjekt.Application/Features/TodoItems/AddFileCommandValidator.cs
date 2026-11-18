using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.TodoItems
{
    public class AddFileCommandValidator : AbstractValidator<AddFileCommand>
    {
        private readonly ApplicationDbContext _context;

        public AddFileCommandValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .MustAsync(async (id, cancellation) =>
                {
                    return await _context.TodoItems.AnyAsync(t => t.Id == id, cancellation);
                }).WithMessage("The specified TodoItem does not exist in the database.");

            RuleFor(x => x.FileName)
                .NotEmpty().WithMessage("File name is required.");

            RuleFor(x => x.FileStream)
                .NotNull().WithMessage("File is required.")
                .Must(s => s != null && s.Length > 0).WithMessage("File cannot be empty.");
        }
    }
}