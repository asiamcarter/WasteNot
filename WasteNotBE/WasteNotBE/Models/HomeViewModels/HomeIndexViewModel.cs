using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteNotBE.Models.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public ICollection<Item> ItemList { get; set; }
    }
}
