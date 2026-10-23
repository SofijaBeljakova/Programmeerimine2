using MediatR;

namespace KooliProjekt.Application.Features.TodoLists
{
    public class GetTodoListQuery : IRequest<KooliProjekt.Application.Data.TodoLists>
    {
        public int Id { get; set; }
    }
}