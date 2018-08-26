using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.DataAccess.Entities
{
    public partial class Slot 
    {
        public int Id { get; set; }
        public int SignupId { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int FormId { get; set; }
        public int? PeopleNeed { get; set; }
    }
}
