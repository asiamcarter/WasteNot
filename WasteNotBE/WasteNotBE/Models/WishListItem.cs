using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteNotBE.Models
{
    public class WishListItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int WishListId { get; set; }
        public WishList WishList { get; set; }
    }
}
