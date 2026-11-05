using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.TodoLists
{
    public class SaveTodoListCommandHandler : IRequestHandler<SaveTodoListCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveTodoListCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveTodoListCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            
            KooliProjekt.Application.Data.TodoLists list;

            if (request.Id == 0)
            {
                list = new KooliProjekt.Application.Data.TodoLists();
                _dbContext.TodoLists.Add(list);
            }
            else
            {
                list = await _dbContext.TodoLists.FindAsync(new object[] { request.Id }, cancellationToken);
                if (list == null)
                {
                    return result.AddError("TodoList not found.");
                }
            }

            list.Title = request.Title;
            

            await _dbContext.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}