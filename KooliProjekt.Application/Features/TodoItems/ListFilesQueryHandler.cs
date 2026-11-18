using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.TodoItems
{
    public class ListFilesQueryHandler : IRequestHandler<ListFilesQuery, OperationResult<IEnumerable<string>>>
    {
        private readonly IFileClient _fileClient;

        public ListFilesQueryHandler(IFileClient fileClient)
        {
            _fileClient = fileClient;
        }

        public async Task<OperationResult<IEnumerable<string>>> Handle(ListFilesQuery request, CancellationToken cancellationToken)
        {
            string folder = Path.Combine("todoitems", request.Id.ToString());
            var files = await _fileClient.ListAsync(folder);

            return new OperationResult<IEnumerable<string>>(files); 
        }
    }
}