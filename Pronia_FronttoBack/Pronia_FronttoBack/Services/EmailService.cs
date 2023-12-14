using MailKit.Net.Smtp;
using MimeKit;

namespace Pronia_FronttoBack.Services
{
    public class EmailService
    {
        public async Task SendMail(string ToMail, string Subject, string Body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("g.suleymanli10010@gmail.com"));
            email.To.Add(MailboxAddress.Parse(ToMail));
            email.Subject = Subject;
            email.Body = new TextPart("html") { Text = Body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.inbox.ru", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("g.suleymanli10010@gmail.com", "hhwo qyhw elda oouw");
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
