using CoreStudentDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreStudentDatabase.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index(RegistrationModel _registration)
        {
            if (ModelState.IsValid)
            {
                using (var entities = new StudentDbContext())
                {
                    var adminData = entities.TblAdmins.Where(x=> x.Username == _registration.Username).FirstOrDefault();
                    if (adminData != null) 
                    {
						ViewBag.RegistrationError = "Username already taken";
						return View(_registration);
					}

					string ePassword = Helpers.Encryption.Encrypt(_registration.UserPassword);
                    var nAdmin = new TblAdmin()
                    {
                        Username = _registration.Username,
                        Password = ePassword,
                        DateCreated = DateTime.Now,
                        Email = _registration.Email,
                        Name = _registration.Name,
                        IsActive = true
                    };

                    entities.TblAdmins.Add(nAdmin);
                    if(entities.SaveChanges() > 0)
                    {
						ViewBag.RegistrationSuccess = "Admin has been registered";
						return View();
                    }

                }
            }

            return View(_registration);
        }
    }
}
