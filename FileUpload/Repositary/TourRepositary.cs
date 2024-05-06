using FileUpload.Data;
using FileUploadOperation.Controllers;
using FileUploadOperation.Migrations;
using FileUploadOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FileUploadOperation.Repositary
{
    public class TourRepositary : ITourRepositary
    {
        private readonly ApplicationDBContext _context;


        public TourRepositary(ApplicationDBContext context)
        {
            _context = context;
        }

        public int AddTourBook(TourBooking booking)
        {
            TourBooking tour = new TourBooking();
            tour.TourBookingId = booking.TourBookingId;
            tour.FirstName = booking.FirstName;
            tour.LastName = booking.LastName;
            tour.Email = booking.Email;
            tour.Phone = booking.Phone;
            tour.City = booking.City;
            tour.Country = booking.Country;
            tour.TimeofIncident = booking.TimeofIncident;
            tour.Howmanypeople = booking.Howmanypeople;
            tour.Whichtoursorevents = booking.Whichtoursorevents;
            tour.bestwaytocontact = booking.bestwaytocontact;
            tour.besttimeofday = booking.besttimeofday;
            tour.AnythingElse = booking.AnythingElse;
            tour.HowDidYouHear = booking.HowDidYouHear;


            var res = _context.TourBookings.Add(booking);

            if (res != null)
            {
                _context.SaveChanges();
                return 1;
            }
            return 0;

        }

        public IEnumerable<TourBooking> GetAllTourbook()
        {
            try
            {
                var getall = _context.TourBookings.Where(u => u.IsActive == true).ToList();
                return getall;
            }
            catch (Exception)
            { 
                throw;
            }
        }


        public int Delete(int id)
        {
            int i = 0;
            var deleteid = _context.TourBookings.Find(id);
 
            if (deleteid != null)
            {
                deleteid.IsActive = false;
                i = _context.SaveChanges();
            }
            return i;
        }


        public IEnumerable<Country> GetCountries()
        {
            try
            {
                return _context.Countries.ToList();
            }
            catch (Exception)
            {

                throw;

            }
        }

        //public int GetAllUpdate(int id, TourBooking tourbook)
        //{
        //  var update = _context.TourBookings.FirstOrDefault();

        //  if (update != null)
        //  {

        //      update.firstName = tourbook.FirstName;
        //      update.lastName = tourbook.LastName;
        //      update.Email = tourbook.Email;
        //      update.Phone = tourbook.Phone;
        //      update.TimeofIncident = tourbook.TimeofIncident;
        //      update.Howmanypeople = tourbook.Howmanypeople;
        //      update.Whichtoursorevents = tourbook.Whichtoursorevents;
        //      update.bestwaytocontact = tourbook.bestwaytocontact;
        //      update.besttimeofday = tourbook.besttimeofday;
        //      update.AnythingElse = tourbook.AnythingElse;
        //      update.HowDidYouHear = tourbook.HowDidYouHear;

        //  }



        //      _context.SaveChanges();



        //int success=_context.SaveChanges();
        //  return success;
        //}

        public int GetAllUpdate( TourBooking details)
        {
            var user = _context.TourBookings.Where(u => u.TourBookingId == details.TourBookingId).First();
            user.LastName = details.LastName;
            user.FirstName = details.FirstName;
            user.Email = details.Email;
            user.Phone = details.Phone;
            user.TimeofIncident = details.TimeofIncident;
            user.Howmanypeople = details.Howmanypeople;
            user.Whichtoursorevents =  details.Whichtoursorevents;
            user.bestwaytocontact = details.bestwaytocontact;
            user.besttimeofday = details.besttimeofday;
            user.AnythingElse = details.AnythingElse;
            user.HowDidYouHear = details.HowDidYouHear;
           int result= _context.SaveChanges();


            return result;
        }

        
    }
}
