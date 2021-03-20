using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Models
{
    public class Crops
    {
        [Key]
        public int Crops_id { get; set; }
       
        [Required]
        [Display(Name = "Crops Name")]
        public String Crops_name { get; set; }
        [Required]
        [Display(Name = "quantity")]
        public int Crops_quantity { get; set; }
        [Required]
        [Display(Name = "Price")]
        public int Crops_price { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description ")]
        public String Crops_description { get; set; }
        [Required]
        [Display(Name = "Crops image")]
        public String Crops_image { get; set; }
        public bool itComplited { get; set; }
        public bool buyOrsell { get; set; }
        public int Farmers_id { get; set; }
        [ForeignKey("Seller_id")]
        public Farmers Farmers { get; set; }


        public IList<Cart> Cart { get; set; }


    }
}
