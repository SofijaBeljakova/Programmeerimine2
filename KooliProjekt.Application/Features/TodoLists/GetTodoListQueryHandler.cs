using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.TodoLists
{
    public class GetTodoListQueryHandler : IRequestHandler<GetTodoListQuery, global::KooliProjekt.Application.Data.TodoLists>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetTodoListQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<global::KooliProjekt.Application.Data.TodoLists> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            var list = await _dbContext.TodoLists.FindAsync(new object[] { request.Id }, cancellationToken);
            return list;
        }
    }
}