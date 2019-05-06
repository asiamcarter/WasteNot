using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WasteNotBE.Models.ItemViewModels
{
    public class ItemCreateViewModel
    {
        public Item Item { get; set; }
        public List<SelectListItem> UserWishLists { get; set; }
        public List<SelectListItem> ItemCategories { get; set; }
        public WishList WishList { get; set; }
        public int WishListId { get; set; }
        public WishListItem WishListItem { get; set; }

        //public List<SelectListItem> WishListOptions { get; set; }
    }
}

