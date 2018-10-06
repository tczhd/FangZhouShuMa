using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FangZhouShuMa.Api.Models.Orders
{
    [DataContract(Name = "shipping_info")]

    public class ShippingInfoViewModel
    {
        [DataMember(Name = "first_name")]

        public string FirstName { get; set; }
        [DataMember(Name = "last_name")]


        public string LastName { get; set; }
        [DataMember(Name = "company")]


        public string Company { get; set; }
        [DataMember(Name = "address")]


        public string Address { get; set; }

        [DataMember(Name = "address2")]

        public string Address2 { get; set; }

        [DataMember(Name = "city")]

        public string City { get; set; }

        [DataMember(Name = "zip")]

        public string Zip { get; set; }
        [DataMember(Name = "phone_number")]

        public string PhoneNumber { get; set; }

        [DataMember(Name = "phone_ext")]

        public string PhoneExt { get; set; }
        [DataMember(Name = "country_id")]

        public int CountryId { get; set; }
        [DataMember(Name = "state_name")]

        public string StateName { get; set; }

        [DataMember(Name = "store_name")]

        public string StoreName { get; set; }
        [DataMember(Name = "title")]

        public string Title { get; set; }
        [DataMember(Name = "notes")]

        public string Notes { get; set; }
        [DataMember(Name = "last_update_date")]

        public DateTime? LastUpdateDate { get; set; }
        [DataMember(Name = "shipping_method_id")]

        public int ShippingMethodId { get; set; }
        [DataMember(Name = "discount")]

        public decimal Discount { get; set; }
        [DataMember(Name = "sub_total")]

        public decimal SubTotal { get; set; }
    }
}
