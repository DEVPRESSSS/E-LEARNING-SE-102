using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace E_LEARNING_SE_102_PROJECT.Utilities.EmailSender
{
    public class EmailsSender : IEmailSender
    {
        public readonly string _sendGrid;
        public EmailsSender(IConfiguration configuration)
        {
            _sendGrid = Environment.GetEnvironmentVariable("SEND_GRID_API_KEY") ?? string.Empty;    
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                //Pass the sendgrid secret to SendGridClient
                var client = new SendGridClient(_sendGrid);

                //Declare the sender
                var from = new EmailAddress("montemorjeraldd@gmail.com", "Password recovery!");

                //Get the receiver and the html message
                var to = new EmailAddress(email);

                //Create a singel email sender
                var message = MailHelper.CreateSingleEmail(from, to, subject,"", htmlMessage);

                //Send the email
                var response = await client.SendEmailAsync(message);

                //Check if the status code is ok if not it will throw error
                if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    var errorBody = await response.Body.ReadAsStringAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email to {email}: {ex.Message}");
            }
        }
    }
}
