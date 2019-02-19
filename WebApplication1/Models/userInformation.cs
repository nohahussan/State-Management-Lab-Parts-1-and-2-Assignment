using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class userInformation
    {

       
        [Required(ErrorMessage = "Full name required")]
        public string Name { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
           ErrorMessage = "Please enter a valid e-mail adress ()")]
        [Required(ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a valid password adress")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please this field is required")]
        [Range(1,110)]
        public string Age { get; set; }

        


    }

    
}