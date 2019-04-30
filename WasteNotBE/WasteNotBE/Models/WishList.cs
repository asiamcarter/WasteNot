using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteNotBE.Models
{
    public class WishList
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Title { get; set; }
    }
}
