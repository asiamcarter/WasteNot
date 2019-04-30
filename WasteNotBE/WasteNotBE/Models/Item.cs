using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteNotBE.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string SourceLink { get; set; }
        public string PhotoUrl { get; set; }
        public string ReplacementTag { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
