using Lerin.Data;
using Lerin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Lerin.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<UserViewModel> _passwordHasher;
        public AuthController( AppDbContext dbContext) 
        {
            _context = dbContext;
            _passwordHasher = new PasswordHasher<UserViewModel>();
        }

        // GET: AuthController/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        // GET: AuthController/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Post: AuthController/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the user from the database
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.username == model.username);

                if (user != null)
                {
                    // Verify the password
                    var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.passwordHash, model.password);

                    if (passwordVerificationResult == PasswordVerificationResult.Success)
                    {
                        // Password is correct, implement logic to sign in the user
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid username or password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password1");
                }
            }
         

            // If login fails, add an error and redisplay the form
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                // Retrieve the user from the database
                var userInDb = await _context.Users
                    .FirstOrDefaultAsync(u => u.username == model.username);
                if (userInDb != null)
                {
                    // If register fails, add an error and redisplay the form
                    ModelState.AddModelError(string.Empty, "Username already exists.");
                    return View(model);
                }

                var user = new UserViewModel()
                {
                    username = model.username
                };
                // Hash the password and assign it to the PasswordHash property
                user.passwordHash = _passwordHasher.HashPassword(user, model.password);

                // Save the user to the database
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
