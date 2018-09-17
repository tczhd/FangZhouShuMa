using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.BasketViewModels
{
    public class BasketItemViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OldUnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public string PictureUrl { get; set; }
        public List<BasketItemDetailViewModel> BasketItemDetails { get; set; }
    }
}
