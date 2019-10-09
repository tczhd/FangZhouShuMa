using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Entities
{
    public class Schedule : BaseEntity
    {
        public Schedule()
        {
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime LastUpdateDate { get; set; }
    }
}
