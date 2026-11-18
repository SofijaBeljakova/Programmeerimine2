using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.TodoItems
{
    public class ListFilesQueryValidator : AbstractValidator<ListFilesQuery>
    {
        private readonly ApplicationDbContext _context;

        public ListFilesQueryValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .MustAsync(async (id, cancellation) =>
                {
                    return await _context.TodoItems.AnyAsync(t => t.Id == id, cancellation);
                }).WithMessage("The specified TodoItem does not exist in the database.");
        }
    }
}