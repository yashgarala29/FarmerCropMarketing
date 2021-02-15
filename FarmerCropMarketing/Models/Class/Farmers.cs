using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Models
{
    public class Farmers
    {
        [Key]
        public int Farmers_id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String Farmers_name { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "please enter valid email ")]
        public String Farmers_email { get; set; }
        
        [Required]
        [Display(Name = "Mobile number")]
        [DataType(DataType.Text)]
        public string Farmers_mobile_no { get; set; }
        [Required]
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Farmers_address { get; set; }

        public String Farmers_image { get; set; }

        public IList<Cart> Cart { get; set; }
        public IList<Crops> Crops { get; set; }


    }
}
