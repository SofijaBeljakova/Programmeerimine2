using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.TodoItems
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, OperationResult>
    {
        private readonly IFileClient _fileClient;

        public DeleteFileCommandHandler(IFileClient fileClient)
        {
            _fileClient = fileClient;
        }

        public async Task<OperationResult> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            string folder = Path.Combine("todoitems", request.Id.ToString());
            await _fileClient.DeleteAsync(folder, request.FileName);

            return new OperationResult(); 
        }
    }
}