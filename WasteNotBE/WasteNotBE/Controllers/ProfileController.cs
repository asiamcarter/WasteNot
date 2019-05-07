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

        // GET: Profile
        public async Task<IActionResult> Index()
        {
            var DatabaseUsers = await _context.ApplicationUsers.ToListAsync();
            var ViewList = new List<ProfileViewModel>();
            foreach (var user in DatabaseUsers)
            {
                var newViewModel = new ProfileViewModel();
                newViewModel.User = user;
                ViewList.Add(newViewModel);
            }

            return View(ViewList);  
        }

        // GET: Profile/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileViewModel = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (profileViewModel == null)
            {
                return NotFound();
            }

            return View(profileViewModel);
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
        public async Task<IActionResult> Create([Bind("Id,Username,FirstName,LastName,Story,PhotoURL")] ProfileViewModel profileViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profileViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profileViewModel);
        }

        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileViewModel = await _context.ProfileViewModel.FindAsync(id);
            if (profileViewModel == null)
            {
                return NotFound();
            }
            return View(profileViewModel);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,FirstName,LastName,Story,PhotoURL")] ProfileViewModel profileViewModel)
        {
            if (id != profileViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileViewModelExists(profileViewModel.Id))
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
            return View(profileViewModel);
        }

        // GET: Profile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileViewModel = await _context.ProfileViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileViewModel == null)
            {
                return NotFound();
            }

            return View(profileViewModel);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profileViewModel = await _context.ProfileViewModel.FindAsync(id);
            _context.ProfileViewModel.Remove(profileViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileViewModelExists(int id)
        {
            return _context.ProfileViewModel.Any(e => e.Id == id);
        }
    }
}
