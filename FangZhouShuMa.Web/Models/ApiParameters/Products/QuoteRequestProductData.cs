using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.ApiParameters.Products
{
    public class QuoteRequestProductData
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public List<QuoteRequestProductCustomFieldData> QuoteRequestProductCustomFieldData { get; set; }
    }
}
