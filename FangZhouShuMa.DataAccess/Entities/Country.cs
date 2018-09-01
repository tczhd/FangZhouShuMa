using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.DataAccess.Entities
{
    public class Country
    {
        public int CountryId { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(2)]
        public string ISO2 { get; set; }

        [Required]
        [StringLength(3)]
        public string ISO3 { get; set; }

        public short NumCode { get; set; }

        public bool Active { get; set; }
    }
}
