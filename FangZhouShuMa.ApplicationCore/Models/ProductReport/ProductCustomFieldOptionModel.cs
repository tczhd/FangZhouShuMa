using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Models.ProductReport
{
    public class ProductCustomFieldOptionModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Sequence { get; set; }
    }
}
