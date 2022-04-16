using Core.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFileUploader
    {
        Task<FileRepo> FileUploadToDatabase(List<IFormFile> files);
        FileRepo FileInformations(List<IFormFile> files);
    }
}
