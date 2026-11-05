using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.TodoLists
{
    public class DeleteTodoListCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
    }
}
