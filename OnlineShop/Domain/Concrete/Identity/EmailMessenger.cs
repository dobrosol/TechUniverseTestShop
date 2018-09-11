using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Domain.Concrete.Identity
{
     public class EmailMessenger
     {
          string from = "TechUniverseTestSite@gmail.com";
          string password = "UniverseTech1qazxsw23edc";

          SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

          MailMessage message;

          public EmailMessenger(string to)
          {
               client.DeliveryMethod = SmtpDeliveryMethod.Network;
               client.EnableSsl = true;
               client.Credentials = new NetworkCredential(from, password);

               message = new MailMessage(from, to);
               message.IsBodyHtml = true;
          }

          public Task SendMessageAsync(string subject, string body)
          {
               message.Body = body;
               message.Subject = subject;

               return client.SendMailAsync(message);
          }
     }
}