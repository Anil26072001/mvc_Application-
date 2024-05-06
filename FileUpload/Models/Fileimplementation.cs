using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileUploadOperation.Models
{
    public class Fileimplementation
    {
        [Key]
        public int Id { get; set; }
        public  string FileName { get; set; }
        public string Filepath { get; set; }

        public byte[] Size { get; set; }
    }
}
