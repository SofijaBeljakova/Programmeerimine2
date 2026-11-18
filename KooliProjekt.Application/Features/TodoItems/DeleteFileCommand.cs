using MediatR;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.TodoItems
{
    public class DeleteFileCommand : IRequest<OperationResult>
    {
        public int Id { get; set; } // ID элемента TodoItem или ID файла
        public string FileName { get; set; } = string.Empty;
    }
}