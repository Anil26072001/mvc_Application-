using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FileUploadOperation.Models
{
    public class TourBooking
    {
        
        public int TourBookingId { get; set; }
        
        //[Column(TypeName="varchar(50)")]
        public  string? FirstName { get; set; }
        
        //[Column(TypeName = "varchar(50)")]
        public  string? LastName { get; set; }
        //[Column(TypeName = "varchar(50)")]
        public  string? Email { get; set; }
        //[Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }
        //[Column(TypeName = "DateTime")]
        public string? TimeofIncident { get; set; }

        
        public int Howmanypeople { get; set; }

        
        public string? Whichtoursorevents  { get; set; }

        
        public string? bestwaytocontact { get; set; }

        
        public string? besttimeofday { get; set; }

        
        public string? AnythingElse { get; set;}

       
        public string? HowDidYouHear { get; set; }


        public bool IsActive { get; set; } = true;


        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }



    }
}
