/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace abis
{
    public static class BookReaderTools
    {
        public static void AddBookReader(AbisContext db, List<string> Inputs)
        {
            BookReader bookReader = new BookReader
            {
                ReaderGradebookNum = int.Parse(Inputs[0]),
                BookIsbn = long.Parse(Inputs[1]),
                DateBorrowed = DateOnly.FromDateTime(DateTime.Today),
                DateDeadline = DateOnly.FromDateTime(DateTime.Today).AddDays(10),
                Returned = false
            };

            Book book = db.Books.Find(bookReader.BookIsbn);

            if(book.Quantity <= 0 || book.Active == false)
            {
                throw new Exception("No such books availible");
            }

            db.BookReaders.Add(bookReader);
            book.Quantity -= 1;

            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                db.BookReaders.Remove(bookReader);
                book.Quantity += 1;
                throw new Exception(ex.Message);
            }
        }

        public static void CloseBookReader(AbisContext db, long id)
        {
            BookReader bookReader = db.BookReaders.Find(id);

            if(bookReader == null)
            {
                throw new Exception("Failed to close a BookReader: null reference");
            }

            if (bookReader.Returned)
            {
                throw new Exception("BookReader already closed");
            }

                Book book = db.Books.Find(bookReader.BookIsbn);

                bookReader.DateReturned = DateOnly.FromDateTime(DateTime.Today);
                bookReader.Returned = true;
                book.Quantity += 1;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    bookReader.DateReturned = null;
                    bookReader.Returned = false;
                    book.Quantity -= 1;
                    throw new Exception(ex.Message);
                }
        }
        /*public static void DeleteBookReader(AbisContext db, long bookIsbn, int readerGradebookNum) 
        {
            BookReader bookReader = db.BookReaders.Find(readerGradebookNum, bookIsbn); 
            
            if(bookReader != null)
            {
                db.BookReaders.Remove(bookReader);
                db.SaveChanges(); 
            }
        }*/
        public static void EditBookReader(AbisContext db, long id, List<string> Inputs)
        {
            BookReader bookReader = db.BookReaders.Find(id);
            BookReader bookReader_reserve = bookReader;

            if (bookReader != null) 
            {
                bookReader.DateReturned = DateOnly.Parse(Inputs[0]);
                bookReader.DateDeadline = DateOnly.Parse(Inputs[1]);
                bookReader.Returned = bool.Parse(Inputs[2]);

                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    bookReader = bookReader_reserve;
                    bookReader_reserve = null;
                    throw new Exception("Failed to edit a BookReader");
                }
            }
            else
            {
                throw new Exception("failed to edit a BookReader");
            }
        }
    }
}
