using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Models.Class
{
    public class MSPSellCrops
    {
        [Key]
        public int MSPSell_id { get; set; }
        [Required]
        [Display(Name = "quantity")]
        public int Crops_quantity { get; set; }

        public int Farmers_id { get; set; }
        [ForeignKey("Seller_id")]
        public Farmers Farmers { get; set; }

        public int MSPCrops_id { get; set; }
        [ForeignKey("MSPCrops_id")]
        public MSPCropsDetail MSPCropsDetail { get; set; }
    }
}
