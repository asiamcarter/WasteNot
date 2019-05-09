using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WasteNotBE.Models
{
    public class ApplicationUser: IdentityUser
    {  

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Story")]
        public string Story { get; set; }

        [Display(Name = "Photo")]
        public string PhotoURL { get; set; }

        public bool isAdmin { get; set; }

        List<WishList> UserWishLists { get; set; }
    }
}
