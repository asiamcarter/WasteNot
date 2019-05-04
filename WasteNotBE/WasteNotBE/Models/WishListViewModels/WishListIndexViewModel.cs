using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteNotBE.Models.WishListViewModels
{
    public class WishListIndexViewModel
    {
        public List<WishList> WishLists { get; set; }
        public WishList WishList { get; set; }
        public List<WishListItem> WishListItems { get; set; }
        public Item Item { get; set; }
        //public List<GroupedItems> GroupedItems { get; set; }
    }
}
