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
using WasteNotBE.Models.WishListItemViewModels;

namespace WasteNotBE.Controllers
{
    public class WishListItemsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        public WishListItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: WishListItems
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.WishListItems.Include(w => w.Item).Include(w => w.WishList);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        // GET: WishListItems/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var wishListItem = await _context.WishListItems
        //        .Include(w => w.Item)
        //        .Include(w => w.WishList)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (wishListItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(wishListItem);
        //}

        // GET: WishListItems/Create
        public async Task<IActionResult> Create(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(CantFind));
            }
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return RedirectToAction(nameof(PleaseLogin));
            }
            ViewData["WishListId"] = new SelectList(_context.WishLists.Where(w=> w.UserId == user.Id), "Id", "Title");
            return View();
        }

        // POST: WishListItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromRoute] int id, WishListItemCreateViewModel wishListItem)
        {
           
            if (ModelState.IsValid)
            {
                wishListItem.NewWishListItem.ItemId = id;
                _context.Add(wishListItem.NewWishListItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "WishLists", new { id = wishListItem.NewWishListItem.WishListId });
            
                //return RedirectToAction(nameof(Index));
            }
          
            ViewData["WishListId"] = new SelectList(_context.WishLists, "Id", "", wishListItem.NewWishListItem.WishListId);
            return View(wishListItem);
        }

        // GET: WishListItems/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var wishListItem = await _context.WishListItems.FindAsync(id);
        //    if (wishListItem == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id", wishListItem.ItemId);
        //    ViewData["WishListId"] = new SelectList(_context.WishLists, "Id", "Id", wishListItem.WishListId);
        //    return View(wishListItem);
        //}

        // POST: WishListItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ItemId,WishListId")] WishListItem wishListItem)
        //{
        //    if (id != wishListItem.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(wishListItem);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!WishListItemExists(wishListItem.Id))
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
        //    ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id", wishListItem.ItemId);
        //    ViewData["WishListId"] = new SelectList(_context.WishLists, "Id", "Id", wishListItem.WishListId);
        //    return View(wishListItem);
        //}

        // GET: WishListItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(CantFind));
            }

            var wishListItem = await _context.WishListItems
                .Include(w => w.Item)
                .Include(w => w.WishList)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            var user = await GetCurrentUserAsync();
            if( user == null)
            {
                return RedirectToAction(nameof(PleaseLogin));
            }
            if (wishListItem.WishList.User.Id != user.Id)
            {
                return RedirectToAction(nameof(UhOh));
            }

            if (wishListItem == null)
            {
                return RedirectToAction(nameof(CantFind));
            }

            return View(wishListItem);
        }

        // POST: WishListItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wishListItem = await _context.WishListItems.FindAsync(id);
            _context.WishListItems.Remove(wishListItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "WishLists", new { id = wishListItem.WishListId });
            //return RedirectToAction("Index", "Home");
        }

        private bool WishListItemExists(int id)
        {
            return _context.WishListItems.Any(e => e.Id == id);
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
