using FangZhouShuMa.ApplicationCore.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Interfaces.Services
{
    public interface ISiteUserService
    {
        Task<SiteUser> CreateSiteUserAsync(string userId, string firstName, string lastName);
    }
}
