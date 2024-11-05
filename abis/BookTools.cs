/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace abis
{
    public static class BookTools
    {
        public static void AddBook(AbisContext _db, List<string> Inputs)
        {
            Book book = new Book
            {
                Isbn = long.Parse(Inputs[0]),
                Title = Inputs[1],
                Pages = short.Parse(Inputs[2]),
                PublishingHouse = Inputs[3],
                YearPublished = short.Parse(Inputs[4]),
                Description = Inputs[5],
                Quantity = byte.Parse(Inputs[6])
            };

            _db.Books.Add(book);
            _db.SaveChanges();
        }
        public static void DeleteBook(AbisContext _db, long _isbn)
        {
            Book book = _db.Books.Where(b => b.Isbn == _isbn).FirstOrDefault();

            if (book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
            }
        }

        public static void EditBook(AbisContext _db, long _isbn, List<string> Inputs)
        {
            Book book = _db.Books.Where(b => b.Isbn == _isbn).FirstOrDefault();

            if (book != null)
            {
                book.Title = Inputs[1];
                book.Pages = short.Parse(Inputs[2]);
                book.PublishingHouse = Inputs[3];
                book.YearPublished = short.Parse(Inputs[4]);
                book.Description = Inputs[5];
                book.Quantity = byte.Parse(Inputs[6]);

                _db.SaveChanges();
            }
        }
    }
}
