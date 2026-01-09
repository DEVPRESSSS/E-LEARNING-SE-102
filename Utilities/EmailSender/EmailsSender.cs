using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace E_LEARNING_SE_102_PROJECT.Utilities.EmailSender
{
    public class EmailsSender : IEmailSender
    {
      

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
