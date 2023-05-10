using CoreStudentDatabase.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreStudentDatabase.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginModel _admin)
        {
            if (ModelState.IsValid)
            {
                var ePassword = Helpers.Encryption.Encrypt(_admin.Password);

                using (var entities = new StudentDbContext())
                {
                    var aData = entities.TblAdmins.Where(x=> x.Username == _admin.Username && x.Password == ePassword).FirstOrDefault();

                    if(aData == null)
                    {
                        ViewBag.ErrorMessage = "Invalid username/password";
                        return View(_admin);
                    }
                    
                    var claims = new List<Claim>{
                        new Claim(ClaimTypes.Name, aData.Email),
                        new Claim("Username", aData.Username),
                        new Claim(ClaimTypes.Role,"Admin")
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims,CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh= true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                        IsPersistent=true,
                        IssuedUtc = DateTimeOffset.UtcNow
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

					return LocalRedirect("/Dashboard");

                }
            }

            return View();
        }
    }
}
