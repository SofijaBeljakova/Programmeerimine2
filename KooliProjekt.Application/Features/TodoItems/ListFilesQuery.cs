using System.Collections.Generic;
using MediatR;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.TodoItems
{
    public class ListFilesQuery : IRequest<OperationResult<IEnumerable<string>>>
    {
        public int Id { get; set; } 
    }
}