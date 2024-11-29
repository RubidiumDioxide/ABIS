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
            //int _readerGradebookNum = int.Parse(Inputs[0]); 
            //long _bookIsbn = long.Parse(Inputs[1]);
            //DateOnly _dateBorrowed = DateOnly.Parse(Inputs[2]);

            BookReader bookReader = new BookReader
            {
                ReaderGradebookNum = int.Parse(Inputs[0]),
                BookIsbn = long.Parse(Inputs[1]),
                DateBorrowed = DateOnly.Parse(Inputs[2]),
                DateDeadline = DateOnly.Parse(Inputs[2]).AddDays(10),
                Returned = false
            };

            db.BookReaders.Add(bookReader); 
            db.SaveChanges(); 
        }

        public static void DeleteBookReader(AbisContext db, long bookIsbn, int readerGradebookNum) 
        {
            BookReader bookReader = db.BookReaders.Find(readerGradebookNum, bookIsbn); 
            
            if(bookReader != null)
            {
                db.BookReaders.Remove(bookReader);
                db.SaveChanges(); 
            }
        }

        public static void EditBookReader(AbisContext db, long bookIsbn, int readerGradebookNum, List<string> Inputs)
        {
            BookReader bookReader = db.BookReaders.Find(readerGradebookNum, bookIsbn);

            if (bookReader != null) 
            {
                bookReader.DateReturned = DateOnly.Parse(Inputs[0]);
                bookReader.Returned = true;

                db.SaveChanges(); 
            }
        }
    }
}
