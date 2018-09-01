using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.DataAccess.Entities
{
    public class Group
    {
        public Group()
        {
            Products = new HashSet<Product>();
        }
        public int GroupId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Sequence { get; set; }

        public int CategoryId { get; set; }

        public bool Active { get; set; }

        [StringLength(50)]
        public string Abbreviation { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
