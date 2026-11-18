using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Infrastructure.Files
{
    public interface IFileClient
    {
        Task SaveAsync(string folder, string fileName, Stream stream);
        Task<Stream> GetAsync(string folder, string fileName);
        Task DeleteAsync(string folder, string fileName);
        Task<IEnumerable<string>> ListAsync(string folder);
    }
}