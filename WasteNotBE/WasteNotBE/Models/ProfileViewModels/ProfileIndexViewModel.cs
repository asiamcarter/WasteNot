using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteNotBE.Models.ProfileViewModels
{
    public class ProfileIndexViewModel
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public WishList UserWishList { get; set; }
        public WishListItem WishListItem { get; set; }
        public <List><GroupedItems> GroupedItems {get;set;}

    }
}
