using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.TodoItems
{
    public class AddFileCommandHandler : IRequestHandler<AddFileCommand, OperationResult>
    {
        private readonly IFileClient _fileClient;

        public AddFileCommandHandler(IFileClient fileClient)
        {
            _fileClient = fileClient;
        }

        public async Task<OperationResult> Handle(AddFileCommand request, CancellationToken cancellationToken)
        {
            if (request.FileStream == null || request.FileStream.Length == 0)
            {
                var result = new OperationResult();
                result.AddError("File is empty or null.");
                return result;
            }

            string folder = Path.Combine("todoitems", request.Id.ToString());
            await _fileClient.SaveAsync(folder, request.FileName, request.FileStream);

            return new OperationResult();
        }
    }
}