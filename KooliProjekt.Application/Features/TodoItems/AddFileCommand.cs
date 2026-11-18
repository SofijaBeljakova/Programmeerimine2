using System.IO;
using MediatR;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.TodoItems
{
    public class AddFileCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Stream FileStream { get; set; }
    }
}