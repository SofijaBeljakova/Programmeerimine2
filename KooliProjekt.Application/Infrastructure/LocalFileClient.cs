using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Infrastructure.Files
{
    public class LocalFileClient : IFileClient
    {
        private readonly string _filesRoot;

        public LocalFileClient(FileStore fileStore)
        {
            _filesRoot = fileStore.FilesRoot;
        }

        public Task DeleteAsync(string folder, string fileName)
        {
            string path = Path.Combine(_filesRoot, folder, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return Task.CompletedTask;
        }

        public Task<Stream> GetAsync(string folder, string fileName)
        {
            string path = Path.Combine(_filesRoot, folder, fileName);
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return Task.FromResult(stream);
        }

        public Task<IEnumerable<string>> ListAsync(string folder)
        {
            string path = Path.Combine(_filesRoot, folder);
            if (!Directory.Exists(path))
            {
                return Task.FromResult(Enumerable.Empty<string>());
            }

            var files = Directory.GetFiles(path).Select(Path.GetFileName).ToList();
            return Task.FromResult<IEnumerable<string>>(files);
        }

        public async Task SaveAsync(string folder, string fileName, Stream stream)
        {
            string path = Path.Combine(_filesRoot, folder);
            Directory.CreateDirectory(path);

            string fullPath = Path.Combine(path, fileName);
            using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}