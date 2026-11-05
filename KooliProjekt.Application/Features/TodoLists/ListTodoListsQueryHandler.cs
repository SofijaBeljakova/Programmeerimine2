using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using System.Linq;

namespace KooliProjekt.Application.Features.TodoLists
{
    public class ListTodoListsQueryHandler : IRequestHandler<ListTodoListsQuery, OperationResult<PagedResult<TodoListDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListTodoListsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<TodoListDto>>> Handle(ListTodoListsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PagedResult<TodoListDto>>();

            // Явно приводим к IQueryable, чтобы метод расширения GetPagedAsync точно сработал
            IQueryable<global::KooliProjekt.Application.Data.TodoLists> query = _dbContext.TodoLists;

            var pagedList = await query.GetPagedAsync(request.PageNumber, request.PageSize);

            var pagedResultDto = new PagedResult<TodoListDto>
            {
                CurrentPage = pagedList.CurrentPage,
                PageSize = pagedList.PageSize,
                PageCount = pagedList.PageCount,
                RowCount = pagedList.RowCount,
                Results = pagedList.Results.Select(x => new TodoListDto
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList()
            };

            result.Value = pagedResultDto;

            return result;
        }
    }
}