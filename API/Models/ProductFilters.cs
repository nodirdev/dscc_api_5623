using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ProductFilters
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public double PriceFrom { get; set; }
        public double PriceTo { get; set; }
        public bool ASC { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
    }
}
