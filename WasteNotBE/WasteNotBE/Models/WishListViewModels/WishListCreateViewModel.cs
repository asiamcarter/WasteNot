﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteNotBE.Models.WishListViewModels
{
    public class WishListCreateViewModel
    {
        public WishList WishList { get; set; }
        public ApplicationUser User {get;set;}
        public string UserId { get; set; }
    }
}
