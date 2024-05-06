using FileUploadOperation.Models;
using FileUpload.Data;
using FileUploadOperation.Controllers;

namespace FileUploadOperation.Repositary
{
    public interface ITourRepositary
    {
        int AddTourBook(TourBooking booking);
        IEnumerable<TourBooking> GetAllTourbook();
        int Delete(int id);

      
        IEnumerable<Country> GetCountries();
        int GetAllUpdate(TourBooking details);
    }



   
    }



