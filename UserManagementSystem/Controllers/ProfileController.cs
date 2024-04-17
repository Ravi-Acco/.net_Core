using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Data;
using UserManagementSystem.Models;
using UserManagementSystem.ViewModel;

namespace UserManagementSystem.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ProfileController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProfileViewModel());
        }

        //profile/index
        [HttpGet]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var profiles = _context.Profiles.Where(n => n.UserId == userId).ToList();
            return View(profiles);
        }

        //profile/create
        [HttpPost]
        public IActionResult Create(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                var profile = new Profile()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Color = model.Color,
                    UserId = userId
                };
                _context.Profiles.Add(profile);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Profile");
            }
            return View(model);
        }

        //profile/edit
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var profile = _context.Profiles.FirstOrDefault(n => n.Id == id);
            if(profile.UserId == userId)
            {
                var model = new ProfileViewModel()
                {
                    Id = profile.Id,
                    Title = profile.Title,
                    Description = profile.Description,
                    CreatedDate = profile.CreatedDate,
                    UserId = userId,
                    Color = profile.Color,
                };
                return View(model);   
            }
            else 
            {
                return Content("You are not authorised to edit.");
            }
        }

        //profile/edit
        [HttpPost]
        public IActionResult Edit(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                if (model.UserId ==userId)
                {
                    var profile = new Profile()
                    {
                        Title = model.Title,
                        Id = model.Id,
                        CreatedDate=model.CreatedDate,
                        Description = model.Description,
                        Color = model.Color,
                        UserId = userId
                    };
                    _context.Profiles.Update(profile);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index), "Profile");
                }
            }
            return View(model);
        }


        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return Content("Id is Null.");
            };
            var userId = _userManager.GetUserId(HttpContext.User);
            var profile = _context.Profiles.FirstOrDefault(n => n.Id == id);
            if (profile.UserId == userId)
            {
                
                _context.Profiles.Remove(profile);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Content("You are not authorised to delete.");
            }
        }
    }
}
