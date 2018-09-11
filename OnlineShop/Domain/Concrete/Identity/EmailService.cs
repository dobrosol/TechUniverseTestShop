using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Domain.Concrete.Identity
{
     public class EmailService : IIdentityMessageService
     {
          public Task SendAsync(IdentityMessage message)
          {
               EmailMessenger emailMessenger = new EmailMessenger(message.Destination);

               return emailMessenger.SendMessageAsync(message.Subject, message.Body);
          }
     }
}
