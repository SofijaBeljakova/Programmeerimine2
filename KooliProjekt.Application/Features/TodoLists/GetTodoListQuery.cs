using MediatR;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.TodoLists
{
    public class GetTodoListQuery : IRequest<OperationResult<TodoListDto>>
    {
        public int Id { get; set; }
    }
}