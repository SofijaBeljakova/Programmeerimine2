using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.TodoLists
{
    public class ListTodoListsQueryHandler : IRequestHandler<ListTodoListsQuery, IEnumerable<global::KooliProjekt.Application.Data.TodoLists>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListTodoListsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<global::KooliProjekt.Application.Data.TodoLists>> Handle(ListTodoListsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.TodoLists.ToListAsync(cancellationToken);
        }
    }
}