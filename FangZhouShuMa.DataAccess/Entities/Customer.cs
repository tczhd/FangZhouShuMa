using FangZhouShuMa.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.DataAccess.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string UserId { get; set; }
        public virtual AspNetUsers AspNetUser { get; set; }


    }
}
