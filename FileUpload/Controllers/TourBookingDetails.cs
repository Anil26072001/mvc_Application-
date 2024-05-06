using FileUpload.Data;
using FileUploadOperation.Interfaces;
using FileUploadOperation.Models;
using FileUploadOperation.Repositary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;


namespace FileUploadOperation.Controllers
{
    public class TourBookingDetails : Controller
    {
        
        private readonly ITourRepositary _tourRepositary;
        private readonly ApplicationDBContext _db;


        public TourBookingDetails( ITourRepositary tourRepositary, ApplicationDBContext db)
        {
            _db=db;
            _tourRepositary = tourRepositary;

        }

       
        [HttpGet]
        public IActionResult TourBook()
        {
            try
            {
                IEnumerable<Country> countries1 = _db.Countries.ToList();
                // var countries = _tour.GetCountries();
                ViewBag.ListCountry = countries1;
                return View();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        public IActionResult TourBook(TourBooking booking)
        {
            try
            {
                int res = _tourRepositary.AddTourBook(booking);
                if (res > 0)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    ModelState.AddModelError("", "Error occurred while adding tourbook.");
                }

                ViewBag.Country = _tourRepositary.GetCountries();
                return View(booking);


            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Delete(int id)
        {
            try
            {
                int deletedUser = _tourRepositary.Delete(id);

                if (deletedUser == null)
                {
                    return NotFound();
                }
                TempData["SuccessMessage"] = "TourUser deleted successfully!";
                return RedirectToAction("List");

            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "An error occurred while processing your request.";

                return View("List");

            }

        }


        public IActionResult List()
        {
            try
            {
                IEnumerable<TourBooking> data = _tourRepositary.GetAllTourbook();
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IActionResult DisplayView( int id)
        {
            try
            {

                var Details = _db.TourBookings.Find(id);

                var countryName = _db.Countries
                           .Where(c => c.CountryId == Details.CountryId)
                           .Select(c => c.CountryName)
                           .FirstOrDefault();

                var cityName = _db.Cities
                          .Where(c => c.CityId == Details.CityId)
                          .Select(c => c.CityName)
                          .FirstOrDefault();
                ViewBag.countryName = countryName;
                ViewBag.cityName = cityName;

                return View(Details);

            }
            catch (Exception)
            {

                throw;
            }
        }

 

    [HttpGet]
    public IActionResult Update(int id)
    {
            try
            {
                var update = _db.TourBookings.Find(id);
                if (update == null)
                {
                    return NotFound();
                }
                else
                {
                    var countryName = _db.Countries
                               .Where(c => c.CountryId == update.CountryId)
                               .Select(c => c.CountryName)
                               .FirstOrDefault();
                    var cityName = _db.Cities
                              .Where(c => c.CityId == update.CityId)
                              .Select(c => c.CityName)
                              .FirstOrDefault();
                    ViewBag.countryName = countryName;
                    ViewBag.cityName = cityName;
                    return View(update);
                }
            }
            catch (Exception)
            {
                throw;
            }
    }


    [HttpPost]
    public IActionResult Update(TourBooking details)
    {
            try
            {
                var data = _tourRepositary.GetAllUpdate(details);
                if (data == 1)
                {
                    return RedirectToAction("List");
                }
                return View(data);
            }
            catch (Exception)
            {
                throw;
            }
    }


     
    public IActionResult  country()
    {
           // Pass the countries to the view
           return View();
    }
        public IActionResult GetCitys(int countryId)
        {
            try
            {
                var citis = _db.Cities.Where(c => c.CountryId == countryId).ToList();
                return Json(citis);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
