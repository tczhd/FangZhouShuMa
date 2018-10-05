using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace FangZhouShuMa.Api.Models.User
{
    [DataContract(Name = "user")]
    public class User
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
        [DataMember(Name = "user_name")]
        public string Username { get; set; }
        [DataMember(Name = "password")]
        public string Password { get; set; }
        [DataMember(Name = "token")]
        public string Token { get; set; }
    }
}
