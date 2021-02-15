using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Models
{
    public class Cart
    {
        [Key]
        public int Cart_id { get; set; }
        public int Farmers_id { get; set; }
        [ForeignKey("Farmers_id")]
        public Farmers Farmers { get; set; }

        public int Crops_id { get; set; }
        [ForeignKey("Crops_id")]
        public Crops Crops { get; set; }

    }
}
