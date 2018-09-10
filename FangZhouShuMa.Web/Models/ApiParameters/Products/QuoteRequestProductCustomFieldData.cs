using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.ApiParameters.Products
{
    public class QuoteRequestProductCustomFieldData
    {
        public int ProductCustomFieldId { get; set; }
        public string ProductCustomFieldData { get; set; }

        public List<QuoteRequestProductCustomFieldOptionData> QuoteRequestProductCustomFieldOptionData { get; set; }
    }
}
