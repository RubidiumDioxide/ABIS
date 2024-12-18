/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using static System.Collections.Specialized.BitVector32;
using System;
using abis.Entities;

namespace abis.Tools
{
    public static class BookTools
    {
        public static void AddBook(AbisContext _db, List<string> Inputs)
        {
            Book book = new Book
            {
                Isbn = long.Parse(Inputs[0]),
                Title = Inputs[1],
                Author = Inputs[2],
                Pages = short.Parse(Inputs[3]),
                PublishingHouse = Inputs[4],
                YearPublished = short.Parse(Inputs[5]),
                Description = Inputs[6],
                Quantity = byte.Parse(Inputs[7]),
                Active = bool.Parse(Inputs[8]),
            };

            _db.Books.Add(book);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _db.Books.Remove(book);
                throw new Exception(ex.Message);
            }
            BookHistoryTools.AddBookHistory(_db, new List<string> { book.Isbn.ToString(), book.Quantity.ToString(), "Добавление" });
        }

        public static void DeleteBook(AbisContext _db, long _isbn)
        {
            Book book = _db.Books.Find(_isbn);

            if (book != null)
            {
                _db.Books.Remove(book);
                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    _db.Books.Add(book);
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("Failed to delete a book: null reference");
            }
        }

        public static void EditBook(AbisContext _db, long _isbn, List<string> Inputs)
        {
            Book book = _db.Books.Find(_isbn);
            Book book_reserve = new Book(book);

            if (book != null)
            {
                book.Title = Inputs[1];
                book.Author = Inputs[2];
                book.Pages = short.Parse(Inputs[3]);
                book.PublishingHouse = Inputs[4];
                book.YearPublished = short.Parse(Inputs[5]);
                book.Description = Inputs[6];
                book.Quantity = byte.Parse(Inputs[7]);
                book.Active = bool.Parse(Inputs[8]);

                try
                {
                    _db.SaveChanges();
                }
                catch
                {
                    book = book_reserve;
                    book_reserve = null;
                    throw new Exception("Failed to edit a Book");
                }
            }
            else
            {
                throw new Exception("Failed to edit a Book");
            }

            if (book.Quantity > book_reserve.Quantity)
            {
                BookHistoryTools.AddBookHistory(_db, new List<string> { book.Isbn.ToString(), Math.Abs(book.Quantity - book_reserve.Quantity).ToString(), "Добавление" });
            }
            if (book.Quantity < book_reserve.Quantity)
            {
                BookHistoryTools.AddBookHistory(_db, new List<string> { book.Isbn.ToString(), Math.Abs(book.Quantity - book_reserve.Quantity).ToString(), "Удаление" });
            }
        }

        public static void DeactivateBook(AbisContext _db, long _isbn)
        {
            Book book = _db.Books.Find(_isbn);

            if (book != null)
            {
                book.Active = false;
                try
                {
                    _db.SaveChanges();
                }
                catch
                {
                    book.Active = true;
                    throw new Exception("Failed to deactivatate a book");
                }
            }
            else
            {
                throw new Exception("Failed to deactivate a book");
            }
        }

        /*public static void DecQuantity(AbisContext _db, long _isbn)
        {
            Book book = _db.Books.Find(_isbn);

            book.Quantity -= 1;
            
            _db.SaveChanges();
        }*/
    }
}
