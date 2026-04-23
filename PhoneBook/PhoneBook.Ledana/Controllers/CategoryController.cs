using Microsoft.EntityFrameworkCore;
using PhoneBook.Ledana.Models;

namespace PhoneBook.Ledana.Controllers;
    internal class CategoryController
    {
        internal static List<Category> GetCategories()
        {
            try
            {
                using var context = new ContactContext();
                var categories = context.Categories
                    .Include(c => c.Contacts)
                    .ToList();
                return categories;
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't get the categories");
            return [];
            }
        }
        internal static void AddCategory(Category category)
        {
            try
            {
                using var context = new ContactContext();
                context.Categories.Add(category);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't add the category");
            }
        }

        internal static void DeleteCategory(Category category)
        {
            try
            {
                using var context = new ContactContext();
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't delete the category");
            }
        }

        internal static void UpdateCategory(Category category)
        {
            try
            {
                using var context = new ContactContext();
                context.Categories.Update(category);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't update the category");
            }
        }
    }
