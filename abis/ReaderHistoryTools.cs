using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abis
{
    public static class ReaderHistoryTools
    {
        public static void AddReaderHistory(AbisContext db, List<string> Inputs)
        {
            ReaderHistory readerHistory = new ReaderHistory {
                ReaderGradebookNum = int.Parse(Inputs[0]),
                Action = Inputs[1],
                Date = DateOnly.FromDateTime(DateTime.Today),
            };

            db.ReaderHistories.Add(readerHistory);
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                db.ReaderHistories.Remove(readerHistory);
                throw new Exception(ex.Message);
            }
        }
    }
}
