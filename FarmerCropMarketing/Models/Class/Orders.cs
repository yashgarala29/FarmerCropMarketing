using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Models
{
    public class Orders
    {
        [Key]
        public int Orders_id { get; set; }

        public int Farmers_id { get; set; }
        [ForeignKey("Farmers_id")]
        public Farmers Farmers { get; set; }

        public int Crops_id { get; set; }
        [ForeignKey("Crops_id")]
        public Crops Crops { get; set; }



        public int seller_id { get; set; }
         
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime order_date { get; set; }
        public string order_status { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime delivery_date { get; set; }

        //public ICollection<item_detail> customer_oreder { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int total_pricer { get; set; }
    }
}
