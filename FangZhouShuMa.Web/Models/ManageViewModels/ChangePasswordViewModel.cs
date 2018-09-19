using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.ManageViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密雄霸")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "密码最少6位", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认蜜码")]
        [Compare("NewPassword", ErrorMessage = "密码不一致.")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
