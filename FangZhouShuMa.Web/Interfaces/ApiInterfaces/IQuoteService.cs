using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Web.Models.ApiParameters.Products;
using FangZhouShuMa.Web.Models.QuoteViewModels;

namespace FangZhouShuMa.Web.Interfaces.ApiInterfaces
{
    interface IQuoteService
    {
        QuoteResultViewModel Quote(QuoteRequestProductData quoteRequestProductData);
    }
}
