using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamBlazorProd.Data
{
    public class IceCream
    {
        [Key]
        public int IceCreamId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime productStartDate { get; set; }
        public string Description { get; set; }
    }
}
