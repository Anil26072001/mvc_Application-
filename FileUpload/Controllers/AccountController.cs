using FileUpload.Data;
using FileUploadOperation.Interfaces;
using FileUploadOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Linq.Expressions;

namespace FileUploadOperation.Controllers
{

    public class AccountController : Controller
    {
        private readonly Idetails _login;
        private readonly ApplicationDBContext _context;
        private readonly UserLogin _applicationUser;
        private readonly IHttpContextAccessor _contextAccessor;
        public AccountController(ApplicationDBContext context, Idetails login, IHttpContextAccessor httpContextAccessor)
        {

            _login = login;
            _context = context;
            _contextAccessor = httpContextAccessor;
        }

        [HttpGet]

        public IActionResult RegistrationPage()
        {
            return View();
        }


        [HttpPost]
       // [Route("RegistrationPage")]
        public IActionResult RegistrationPage(Register register)
        {
            try
            {
                    _login.AddUsers(register);
                    ViewBag.Message = "Welcome " + register.Email + " Registered successfully";
                    //ViewBag["RegistrationSuccess"] = true;
                    return RedirectToAction("LoginPage", "Account");
                


            }
            catch (Exception)
            {
                throw;
            }

            //try
            //{
            //    _login.AddUsers(register);

            //    return RedirectToAction("LoginPage");
            //}
            //catch (Exception)
            //{
            //    return NotFound();
            //}

        }




        //[Route("")]

        //[Route("Account")]
        //[Route("")]
        //[Route("LoginPage")]

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]

        public IActionResult LoginPage(string Email, String password)
        {

            //bool isSuccess = _login.AuthenticatedUser(Email, password);

            //if (isSuccess)
            //{
            //    //TempData["email"]=email;
            //    ViewBag.email = "Successfully Login User";

            //    return RedirectToAction("ListPage", "Account");
            //}
            //else
            //{
            //    ViewBag.email = "Sorry Invalid credentials";
            //    return View();

            //}
            try
            {
                bool myuser = _login.AuthenticatedUser(Email, password);

                if (myuser)
                {
                    //var session = _contextAccessor.HttpContext.Session;
                    //session.SetString("User", "Valid");
                    return RedirectToAction("listpage", "Account");
                }
                else
                {
                    ViewBag.email = "Sorry Invalid credentials";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

       // [AuthenticationUser]
        public IActionResult ListPage()
        {
            List<Register> list = _login.GetUsers();

            if (list != null)
            {
                return View(list);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(Register model)
        {
            if (ModelState.IsValid)
            {
                _context.Registers.Add(model);
                _context.SaveChanges();

                return RedirectToAction("ListPage");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public IActionResult forgetpassword(string email)
        {

           
            return View($"Received email:{email}");

        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool check = _login.DeleteUser(id);
                if (check)
                {
                    return RedirectToAction("ListPage");
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return NotFound();

            }
        }

        public IActionResult view(int id)
        {
            try
            {
                var view = _context.Registers.Find(id);
                return View(view);
            
            }
            catch (Exception)
            {

                throw;
            }
        }

    }


}

