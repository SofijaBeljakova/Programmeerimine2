using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.TodoLists
{
    public class GetTodoListQueryHandler : IRequestHandler<GetTodoListQuery, OperationResult<TodoListDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetTodoListQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<TodoListDto>> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<TodoListDto>();

            var list = await _dbContext.TodoLists.FindAsync(new object[] { request.Id }, cancellationToken);

            if (list == null)
            {
                result.AddError("Not found");
                return result;
            }

            result.Value = new TodoListDto
            {
                Id = list.Id,
                Title = list.Title
            };

            return result;
        }
    }
}