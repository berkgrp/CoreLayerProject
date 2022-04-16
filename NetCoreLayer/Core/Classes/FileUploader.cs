using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Core.Classes
{
    public class FileUploader : IFileUploader
    {
        private FileRepo _fileRepo;
        public FileUploader(FileRepo fileRepo)
        {
            _fileRepo = fileRepo;
        }

        public async Task<FileRepo> FileUploadToDatabase(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var fileExtension = Path.GetExtension(file.FileName);
                _fileRepo = new FileRepo
                {
                    FileName = fileName,
                    FileExtension = fileExtension,
                    FileType = file.ContentType,
                };
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    _fileRepo.FileData = dataStream.ToArray();
                }
            }
            return _fileRepo;
        }

        public FileRepo FileInformations(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var fileExtension = Path.GetExtension(file.FileName);
                _fileRepo = new FileRepo
                {
                    FileName = fileName,
                    FileExtension = fileExtension,
                    FileType = file.ContentType,
                };
            }
            return _fileRepo;
        }
    }
}
