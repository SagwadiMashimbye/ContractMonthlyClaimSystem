using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ContractMonthlyClaimSystem.Context;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IPasswordHasher<User> _passwordHasher;

        public HomeController(ApplicationDbContext context, UserManager<User> userManager, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Display the Login view
        }

        public IActionResult Index()
        {
            var currentUser = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);
            return View(currentUser);
        }


        public IActionResult Track()
        {
            return View(); // Welcome page after login
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(u => u.UserName == model.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("UserName", "User not found.");
                }
                else
                {
                    var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);
                    if (passwordVerificationResult == PasswordVerificationResult.Success)
                    {
                        // Sign in the user
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        // Optional: Redirect based on user role if needed
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Invalid password.");
                    }
                }
            }
            return View(model);
        }


        public IActionResult Form()
        {
            return View(); // Additional page for the logged-in user
        }

        public IActionResult Verify()
        {
            return View(); // Additional page for the logged-in user
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitClaim(string name, string surname, int hoursWorked, decimal hourlyRate, string modelName, string description)
        {
            // Check if the lecturer exists in the database
            var lecturer = _context.Lecturers.SingleOrDefault(l => l.Name == name && l.Surname == surname);
            if (lecturer == null)
            {
                ViewBag.UserNotFound = "Lecturer not found. Please check the name and surname.";
                return View("Form");
            }

            // Create and save the claim object
            var claim = new Claim
            {
                ClaimDate = DateTime.Now,
                HoursWorked = hoursWorked,
                HourlyRate = hourlyRate,
                LecturerId = lecturer.LecturerId, // Ensure this matches your model's property
                ClaimStatus = "Pending" // or whatever status is appropriate
            };

            _context.Claims.Add(claim);
            _context.SaveChanges(); // Save the claim first to get its ID

            // Now add the ClaimDetail
            var claimDetail = new ClaimDetail
            {
                ClaimId = claim.ClaimId, // Link to the claim
                ModelName = modelName,
                Description = description,
                TotalClaimAmount = claim.TotalAmount,
                TotalHoursWorked = hoursWorked
            };

            _context.ClaimDetails.Add(claimDetail);
            _context.SaveChanges(); // Save the claim detail

            return RedirectToAction("Track"); // Redirect to the tracking page or any other page
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel()); // Display the registration view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if a user with the same username or email already exists
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserName == model.UserName || u.Email == model.Email);

                if (existingUser != null)
                {
                    // Add a model state error
                    ModelState.AddModelError(string.Empty, "Username or email already exists. Please choose a different one.");
                    return View(model); // Return to the registration view with the error
                }

                // Create the user object and store the basic info
                var user = new User
                {
                    UserId = Guid.NewGuid().ToString(), // Generate a new unique ID
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = _passwordHasher.HashPassword(new User(), model.Password), // Hash the password
                    Role = model.Role,
                    Phone = model.Phone
                };

                // Store the user in the Users table
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Depending on the selected role, create and store the corresponding object
                switch (model.Role)
                {
                    case "Lecturer":
                        var lecturer = new Lecturer
                        {
                            LecturerId = Guid.NewGuid().ToString(),
                            Name = model.Name,
                            Surname = model.Surname,
                            Email = model.Email,
                            Phone = model.Phone,
                            UserId = user.UserId
                        };
                        _context.Lecturers.Add(lecturer);
                        break;

                    case "Program Coordinator":
                        var coordinator = new ProgrammeCoordinator
                        {
                            CoordinatorId = Guid.NewGuid().ToString(),
                            Name = model.Name,
                            Surname = model.Surname,
                            Email = model.Email,
                            Phone = model.Phone,
                            UserId = user.UserId
                        };
                        _context.ProgrammeCoordinators.Add(coordinator);
                        break;

                    case "Academic Manager":
                        var manager = new AcademicManager
                        {
                            ManagerId = Guid.NewGuid().ToString(),
                            Name = model.Name,
                            Surname = model.Surname,
                            Email = model.Email,
                            Phone = model.Phone,
                            UserId = user.UserId
                        };
                        _context.AcademicManagers.Add(manager);
                        break;
                }

                // Save the changes to the appropriate table
                await _context.SaveChangesAsync();

                // Redirect to the login page after successful registration
                return RedirectToAction("Login");
            }

            // If model validation fails, return the same view with validation errors
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
