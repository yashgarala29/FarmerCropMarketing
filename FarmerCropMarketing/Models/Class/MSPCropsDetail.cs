using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Models.Class
{
    public class MSPCropsDetail
    {
        [Key]
        public int MSPCrops_id { get; set; }

        [Required]
        [Display(Name = "Crops Name")]
        public String Crops_name { get; set; }
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

        [Required]
        [Display(Name = "Crop Buying Start Date")]
        public DateTime Crop_Buying_Staring_Date { get; set; }

        [Required]
        [Display(Name = "Crop Buying End Date")]
        public DateTime Crop_Buying_End_Date { get; set; }

        public IList<MSPSellCrops> MSPSellCrops { get; set; }


    }
}
