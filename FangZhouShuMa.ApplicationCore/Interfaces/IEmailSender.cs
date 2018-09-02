using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Interfaces
{

    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
