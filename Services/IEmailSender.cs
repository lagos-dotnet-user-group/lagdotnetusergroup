namespace WebApplication.Services
{
    public interface IEmailSender
    {
        // Task SendEmailAsync(string email, string subject, string message);

        bool SendEmail(string email, string subject, string message);
        bool SendEmail(string email, string emailName, string subject, string message);

    }
}
