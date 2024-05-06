using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileUploadOperation.Models
{
    public class City
    {
        
        public int CityId { get; set; } 

        public string CityName { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public bool IsActive { get; set; } = true;


    }
}
