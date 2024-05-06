using FileUpload.Data;
using FileUploadOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace FileUploadOperation.Repositary
{
    public class Authentication1 : IfileUpload
    {
        private readonly IWebHostEnvironment _host;
        private readonly ApplicationDBContext _db;

        public Authentication1(IWebHostEnvironment host, ApplicationDBContext db)
        {
            _host = host;
            _db = db;
        }

        public async Task fileupload(IFormFile file)
        {
            string filefolder = Path.Combine(_host.WebRootPath, "uploadfiles");
            if (!Directory.Exists(filefolder))
            {
                Directory.CreateDirectory(filefolder);
            }

            string filename = Path.GetFileName(file.FileName);
            string path = Path.Combine(filefolder, filename);

            using (FileStream str = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(str);        //  
            }
            var existuser = await _db.Files.FirstOrDefaultAsync(u => u.FileName == file.FileName);
            //if (existuser != null)
            //{
            //    _db.Files.Remove(existuser);
            //}
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var filesmodel = new Fileimplementation
                {
                    FileName = file.FileName,
                    Filepath = file.ContentType,
                    Size = stream.ToArray()

                };
                _db.Files.Add(filesmodel);
                if (existuser == null)
                {
                    await _db.SaveChangesAsync();
                }
            }
        }




        public List<Fileimplementation> Getfiles()
        {
            List<Fileimplementation> users = _db.Files.ToList();

            return users;

        }


        public MemoryStream DownloadFile(string path)
        {
            var mem = new MemoryStream();
            if (System.IO.File.Exists(path))
            {
                var net = new System.Net.WebClient();
                var data = net.DownloadData(path);
                var content = new System.IO.MemoryStream(data);
                mem = content;
            }
            mem.Position = 0;
            return mem;


            
        }



        public bool FileCheck(string fileName)
        {
            var wwwrootpath = _host.WebRootPath;
            var folderpath = Path.Combine(wwwrootpath, "uploadfiles");

            if (!Directory.Exists(folderpath))
            {

            }
            var filepath = Path.Combine(folderpath, fileName);


            if (System.IO.File.Exists(filepath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
