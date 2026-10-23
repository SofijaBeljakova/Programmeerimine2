using System.Collections.Generic;
using MediatR;

namespace KooliProjekt.Application.Features.TodoLists
{
    public class ListTodoListsQuery : IRequest<IEnumerable<global::KooliProjekt.Application.Data.TodoLists>>
    {
    }
}