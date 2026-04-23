using Microsoft.EntityFrameworkCore;
using PhoneBook.Ledana.Models;

namespace PhoneBook.Ledana.Controllers;
    internal class ContactController
    {
        internal static void AddContact(Contact contact)
        {
            try
            {
                using var context = new ContactContext();
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't add the contact");
            }
        }

        internal static void DeleteContact(Contact contact)
        {
            try
            {
                using var context = new ContactContext();
                context.Contacts.Remove(contact);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't delete the contact");
            }
        }

        internal static List<Contact> GetAllContacts()
        {
            try
            {
                using var context = new ContactContext();
                var contacts = context.Contacts.Include(c => c.Category)
                    .ToList();
                return contacts;
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't get contacts");
            return [];
            }
        }

        internal static void UpdateContact(Contact contact)
        {
            try
            {
                using var context = new ContactContext();
                context.Contacts.Update(contact);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't update the contact");
            }
        }
        internal static bool ValidatePhoneNumber(string phoneNumber)
        {
            using var context = new ContactContext();
            var phoneNumberExists = context.Contacts.Where(c => c.PhoneNumber == phoneNumber).Any();
            return phoneNumberExists;
        }
    }
