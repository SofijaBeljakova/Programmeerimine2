using MediatR;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using KooliProjekt.Application.Dto;

namespace KooliProjekt.Application.Features.TodoLists
{
    public class ListTodoListsQuery : IRequest<OperationResult<PagedResult<TodoListDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}