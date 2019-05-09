using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteNotBE.Models
{
    public class GroupedItems
    {
        public int WishListId { get; set; }
        public string WishListTitle { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
