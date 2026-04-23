using Microsoft.EntityFrameworkCore;
using PhoneBook.Ledana.Models;

namespace PhoneBook.Ledana.Controllers
{
    internal class SMSController
    {
        internal static List<SMS> GetSMS()
        {
            try
            {
                using var context = new ContactContext();
                var SMSs = context.SMSs
                    .Include(s => s.Contact)
                    .ToList();
                return SMSs;
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't get SMSs");
            }
        }

        internal static void SendSMS(SMS sms)
        {
            try
            {
                using var context = new ContactContext();
                context.SMSs.Add(sms);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't send SMS");
            }
        }
    }
}
