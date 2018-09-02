using System.Security.Principal;

namespace FangZhouShuMa.ApplicationCore.Interfaces
{
    public interface IIdentityParser<T>
    {
        T Parse(IPrincipal principal);
    }
}
