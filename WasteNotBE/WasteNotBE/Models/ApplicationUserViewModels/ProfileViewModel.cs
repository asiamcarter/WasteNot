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
        //[Display(Name = "Username")]
        //public string Username { get; set; }

        //[Display(Name = "First Name")]
        //public string FirstName { get; set; }

        //[Display(Name = "Last Name")]
        //public string LastName { get; set; }

        //[Display(Name = "Bio")]
        //public string Story { get; set; }

        //[Display(Name = "Photo")]
        //public string PhotoURL { get; set; }


    }
}
