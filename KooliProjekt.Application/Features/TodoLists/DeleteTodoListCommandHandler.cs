using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.TodoLists
{
    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteTodoListCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.TodoItems
                .Where(item => item.TodoListId == request.Id)
                .ExecuteDeleteAsync();

            await _dbContext.TodoLists
                .Where(list => list.Id == request.Id)
                .ExecuteDeleteAsync();

            return new OperationResult();
        }
    }
}
