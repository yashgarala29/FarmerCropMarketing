using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Models.viewmodel
{
    public class editmspcrop : addmspcrop
    {
        public int id{get;set; }
        public string ExistringImagePath { get; set; }
        
        [Display(Name = "Crops image")]
        public new IFormFile Crops_image { get; set; }
    }
}
