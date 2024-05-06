using Microsoft.EntityFrameworkCore;
using FileUploadOperation.Models;
using Microsoft.Win32;


namespace FileUpload.Data
{
    public class ApplicationDBContext : DbContext
    {

       
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {


        }

        public DbSet<Fileimplementation> Files { get; set; }

        public DbSet<TourBooking> TourBookings { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Register> Registers { get; set; }
    }
   


}

