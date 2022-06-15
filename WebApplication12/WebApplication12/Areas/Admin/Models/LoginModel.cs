using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication12.Areas.Admin.Models
{
    public class LoginModel
    {
        [UserName]
        [Required]
        [Display(Name ="UserName")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public int Password { get; set; }
        public string Massage { get; set; }
    }
}