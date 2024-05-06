using FileUploadOperation.Models;

namespace FileUploadOperation.Repositary
{
    public interface IfileUpload
    {
        Task fileupload(IFormFile file);
        //Task fileupload();
        public List<Fileimplementation> Getfiles();

         MemoryStream DownloadFile(string path);
        bool FileCheck(string fileName);
    }
}
