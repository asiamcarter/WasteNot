using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WasteNotBE.Data;
using WasteNotBE.Models;
using WasteNotBE.Models.ApplicationUserViewModels;

namespace WasteNotBE.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Profile
        public async Task<IActionResult> UserProfile([FromRoute]string id)
        {
            var user = await GetCurrentUserAsync();
            var applicationUser = await _context.ApplicationUsers
               .FirstOrDefaultAsync(m => m.Id == id);
            var UserProfile = new ProfileViewModel();
            UserProfile.User = applicationUser;
            var userWishlists = await _context.WishLists
                .Include(w => w.WishListItems)
                .Where(w => w.UserId == id)
                .ToListAsync();

            UserProfile.UserWishLists = userWishlists;
      

            return View(UserProfile);
        }

        // GET: Profile/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // GET: Profile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Story,PhotoURL,isAdmin")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //access user that's logged in
            var currentUser = await GetCurrentUserAsync();

            //edit only available for logged in user's profile
            if (id == null || id != currentUser.Id)
            {
                return NotFound();
            }

            var User = await _context.ApplicationUsers.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            return View(User);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,Story,PhotoURL,isAdmin")] ApplicationUser User)
        {
            //access user that's logged in
            var currentUser = await GetCurrentUserAsync();

            if (id != User.Id || id != currentUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //update current user with every property that I've determined to be updateable 
                try
                {
                    currentUser.FirstName = User.FirstName;
                    currentUser.LastName = User.LastName;
                    currentUser.Story = User.Story;
                    currentUser.PhotoURL = User.PhotoURL;
               
        
                    _context.Update(currentUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(User.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
  
            return View(User);
        }

        // GET: Profile/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.ApplicationUsers.FindAsync(id);
            _context.ApplicationUsers.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}
