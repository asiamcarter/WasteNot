using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WasteNotBE.Models.ApplicationUserViewModels
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public List<WishList> UserWishLists { get; set; }
        public WishList WishList { get; set; }
        public List<WishListItem> WishListItems { get; set; }
        public List<Item> Items { get; set; }

        public List<GroupedItems> GroupedItems { get; set; }


    }
}
