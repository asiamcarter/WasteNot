using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteNotBE.Models.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public int Id { get; set; }
        public List<Item> ItemList { get; set; }
    }
}
