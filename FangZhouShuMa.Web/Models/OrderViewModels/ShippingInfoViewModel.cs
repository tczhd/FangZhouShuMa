using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.OrderViewModels
{
    public class ShippingInfoViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }


        public string Address { get; set; }


        public string Address2 { get; set; }


        public string City { get; set; }


        public string Zip { get; set; }

        public string PhoneNumber { get; set; }


        public string PhoneExt { get; set; }

        public int CountryId { get; set; }

        public string StateName { get; set; }


        public string StoreName { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public int ShippingMethodId { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }
    }
}
