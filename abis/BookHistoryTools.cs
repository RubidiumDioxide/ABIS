using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abis
{
    public static class BookHistoryTools
    {
        public static void AddBookHistory(AbisContext db, List<string> Inputs)
        {
            BookHistory bookHistory = new BookHistory
            {
                BookIsbn = long.Parse(Inputs[0]),
                Quantity = byte.Parse(Inputs[1]),
                Action = Inputs[2],
                Date = DateOnly.FromDateTime(DateTime.Today),
            };

            db.BookHistories.Add(bookHistory);
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                db.BookHistories.Remove(bookHistory);
                throw new Exception(ex.Message);
            }
        }
    }
}
