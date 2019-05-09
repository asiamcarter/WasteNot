using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WasteNotBE.Data;
using WasteNotBE.Models;
using WasteNotBE.Models.ItemViewModels;

namespace WasteNotBE.Controllers
{
    public class ItemsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Items
        //Method takes in search query as a string, if nothing is typed into the search bar, a list of the first 20 products is returned. If a search query is entered into the search bar, the string is matched against the catalog of items based on their replacement tags and titles. Items that have matches are returned.
        public async Task<IActionResult> Index(string SearchString)
        {
            if (string.IsNullOrEmpty(SearchString))
            {

                var items = await _context.Items
                    .Include(i => i.User)
                    .OrderByDescending(p => p.DateCreated)
                    .Take(20)
                    .ToListAsync();

                return View(items);
            } else
            {
                var items = await _context.Items
                   .Include(i => i.User)
                   .OrderByDescending(p => p.DateCreated)
                   .Where(i => i.ReplacementTag.Contains(SearchString) | i.Title.Contains(SearchString))
                   .ToListAsync();
                return View(items);
            }
       
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
       

        // GET: Items/Create
        public async Task <IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();

            var UserWishList = _context.WishLists.Where(w=>w.UserId == user.Id);
               
 
            List<SelectListItem> WishLists = new List<SelectListItem>();

           WishLists.Insert(0, new SelectListItem
            {
                Text = "Select A Wish List",
                Value = ""
            });
        
            foreach (var uwl in UserWishList)
            {
               
                SelectListItem li = new SelectListItem
                {
                    // Give a value to li
                    Value = uwl.Id.ToString(),
                    // Provide text to li
                    Text = uwl.Title
                };
            
                WishLists.Add(li);
            }

            var ItemCategories = _context.Categories;
            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.Insert(0, new SelectListItem
            {
                Text = "Choose A Category",
                Value = ""
            });

            foreach (var cat in ItemCategories)
            {

                SelectListItem li = new SelectListItem
                {
                    // Give a value to li
                    Value = cat.Id.ToString(),
                    // Provide text to li
                    Text = cat.Title
                };

                Categories.Add(li);
            }

            ItemCreateViewModel viewModel = new ItemCreateViewModel();

            viewModel.UserWishLists = WishLists;
            viewModel.ItemCategories = Categories;

            return View(viewModel);
        }



        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemCreateViewModel createditem)
        {
            //ModelState.Remove("Item.User");
            //ModelState.Remove("Item.UserId");
            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                createditem.Item.UserId = user.Id;
                _context.Add(createditem.Item);
                await _context.SaveChangesAsync();
                // Add Item to WishListItems
                var WishListItem = new WishListItem();
                //could also = passed in id
                WishListItem.WishListId = createditem.WishListId;
                WishListItem.ItemId = createditem.Item.Id;
                _context.WishListItems.Add(WishListItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = createditem.Item.Id });

            }

            var UserWishList = _context.WishLists
                .Where(w => w.UserId == user.Id);

            List<SelectListItem> WishLists = new List<SelectListItem>();

            WishLists.Insert(0, new SelectListItem
            {
                Text = "Select A Wish List",
                Value = ""
            });

            foreach (var uwl in UserWishList)
            {

                SelectListItem li = new SelectListItem
                {
                    // Give a value to li
                    Value = uwl.Id.ToString(),
                    // Provide text to li
                    Text = uwl.Title
                };

                WishLists.Add(li);
            }

            var ItemCategories = _context.Categories;
            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.Insert(0, new SelectListItem
            {
                Text = "Choose A Category",
                Value = ""
            });

            foreach (var cat in ItemCategories)
            {

                SelectListItem li = new SelectListItem
                {
                    // Give a value to li
                    Value = cat.Id.ToString(),
                    // Provide text to li
                    Text = cat.Title
                };

                Categories.Add(li);
            }
            createditem.UserWishLists = WishLists;
            createditem.ItemCategories = Categories;
            return View();
        }
        

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", item.UserId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CategoryId,SourceLink,PhotoUrl,ReplacementTag,UserId,DateCreated")] Item item)
        {
           
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", item.UserId);
            return View(item);
        }
        public IActionResult UhOh()
        {
            return View();
        }

        // GET: Items/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await GetCurrentUserAsync();
           
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user.Id != item.UserId)
            {
                return RedirectToAction(nameof(UhOh));
            }

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
