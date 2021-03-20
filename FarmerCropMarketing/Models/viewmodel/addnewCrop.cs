using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Models.viewmodel
{
    public class addnewCrop
    {
        public int crop_id { get; set; }
        [Required]
        [Display(Name = "Crop Name")]
        public String crop_name { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int crop_quantity { get; set; }
        [Required]
        [Display(Name = "Price")]
        public int crop_price { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description ")]
        public String crop_description { get; set; }
        
        [Display(Name = "You Want To Sell this Crop")]
        public bool youwanttosell { get; set; }

        [Required]
        [Display(Name = "Crop image")]
        public IFormFile crop_image { get; set; }

    }
}
