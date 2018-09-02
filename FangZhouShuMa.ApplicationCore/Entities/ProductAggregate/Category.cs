using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.ApplicationCore.Entities.ProductAggregate
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Groups = new HashSet<Group>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Sequence { get; set; }

        public bool Active { get; set; }

        [StringLength(50)]
        public string Abbreviation { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
