using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.Web.Models.AccountViewModels
{
    public class CustomerViewModel
    {

        [Required]
        [Display(Name = "公司名称")]
        public string Company { get; set; }

        [Required]
        [Display(Name = "联系人")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "地址")]
        public string Address{ get; set; }

        [Required]
        [Display(Name = "城市")]
        public string City { get; set; }
        [Required]
        [Display(Name = "省")]
        public string StateName { get; set; }
        [Required]
        [Display(Name = "电话")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "邮编")]
        public string Zip { get; set; }
    }
}
