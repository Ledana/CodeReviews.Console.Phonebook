using Microsoft.EntityFrameworkCore;
using PhoneBook.Ledana.Models;

namespace PhoneBook.Ledana.Controllers
{
    internal class EmailController
    {
        internal static void SendEmail(Email email)
        {
            try
            {
                using var context = new ContactContext();
                context.Emails.Add(email);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't send email");
            }
        }
        internal static List<Email> GetEmails()
        {
            try
            {
                using var context = new ContactContext();
                var emails = context.Emails
                    .Include(e => e.Contact)
                    .ToList();
                return emails;
            }
            catch
            {
                Console.WriteLine("Couldn't get emails");
            }
        }
    }
}
