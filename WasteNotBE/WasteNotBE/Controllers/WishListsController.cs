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

namespace WasteNotBE.Controllers
{
    public class WishListsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        public WishListsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: WishLists
        //[Route("Profile")]
        //public async Task<IActionResult> Index()
        //{
        //    var user = await GetCurrentUserAsync();
       
        //    var applicationDbContext = _context.WishLists.Include(w => w.User).Include(w => w.WishListItems).Where(w => w.UserId == user.Id);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        // GET: WishLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await GetCurrentUserAsync();

            if (id == null)

            {
                return RedirectToAction(nameof(CantFind));
            }

            var wishList = await _context.WishLists
                .Include(w => w.User)
                .Include(w => w.WishListItems)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (wishList == null)
            {
                return RedirectToAction(nameof(CantFind));
            }

            var Items = await _context.WishListItems
                .Include(w => w.Item)
                .Where(w => w.ItemId == w.Item.Id && w.WishListId == wishList.Id)
                .ToListAsync();
            
            wishList.WishListItems = Items;
            


          
            return View(wishList);
        }



        // GET: WishLists/Create
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return RedirectToAction(nameof(PleaseLogin));
            }

            return View();
        }

        // POST: WishLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title")] WishList wishList)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                wishList.UserId = user.Id;
                _context.Add(wishList);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "WishLists", new { id = wishList.Id });
            }
            //ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", wishList.UserId);
            return View(wishList);
        }

        // GET: WishLists/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var wishList = await _context.WishLists.FindAsync(id);
        //    if (wishList == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", wishList.UserId);
        //    return View(wishList);
        //}

        // POST: WishLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Title")] WishList wishList)
        //{
        //    if (id != wishList.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(wishList);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!WishListExists(wishList.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", wishList.UserId);
        //    return View(wishList);
        //}

        // GET: WishLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await GetCurrentUserAsync();
         
            if (id == null)
            {
                return RedirectToAction(nameof(CantFind));
            }

            var wishList = await _context.WishLists
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return RedirectToAction(nameof(PleaseLogin));
            }
            if (user.Id != wishList.User.Id)
            {
                return RedirectToAction(nameof(UhOh));
            }

            if (wishList == null)
            {
                return RedirectToAction(nameof(CantFind));
            }

            return View(wishList);
        }

        // POST: WishLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await GetCurrentUserAsync();
            var wishList = await _context.WishLists.FindAsync(id);
            _context.WishLists.Remove(wishList);
            await _context.SaveChangesAsync();
            return RedirectToAction("UserProfile", "Profile", new { id = user.Id });
        }
 

        private bool WishListExists(int id)
        {
            return _context.WishLists.Any(e => e.Id == id);
        }

        public IActionResult PleaseLogin()
        {
            return View();
        }

        public IActionResult UhOh()
        {
            return View();
        }

        public IActionResult CantFind()
        {
            return View();
        }
    }
}
