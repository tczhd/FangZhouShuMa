using FangZhouShuMa.Api.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Api.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
       // IEnumerable<User> GetAll();
    }
}
