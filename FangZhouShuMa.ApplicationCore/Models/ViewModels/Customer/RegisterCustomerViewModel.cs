using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Models.ViewModels.Customer
{
    public class RegisterCustomerViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "电子邮箱")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} 至少 {2} 最大 {1}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码必须匹配.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public CustomerViewModel Customer { get; set; }
    }
}
