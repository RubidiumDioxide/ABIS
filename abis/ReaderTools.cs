using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abis
{
    public static class ReaderTools
    {
        public static void AddReader(AbisContext _db, List<string> Inputs)
        {
            Reader reader = new Reader
            {
                GradebookNum = int.Parse(Inputs[0]),
                Surname = Inputs[1],
                FirstName = Inputs[2],
                LastName = Inputs[3],  
                GroupNum = short.Parse(Inputs[4]),
                DateOfBirth = DateOnly.Parse(Inputs[5]),
                Active = bool.Parse(Inputs[6]), 
                Debt = bool.Parse(Inputs[7])
            };

            _db.Readers.Add(reader);
            _db.SaveChanges();
        }

        /*public static void DeleteReader(AbisContext _db, long _gradebookNum)
        {
            Reader reader = _db.Readers.Where(b => b.GradebookNum == _gradebookNum).FirstOrDefault();

            if (reader != null)
            {
                _db.Readers.Remove(reader);
                _db.SaveChanges();
            }
        }*/

        public static void EditReader(AbisContext _db, long _gradebookNum, List<string> Inputs)
        {
            Reader reader = _db.Readers.Find(_gradebookNum);

            if (reader != null)
            {
                reader.Surname = Inputs[1];
                reader.FirstName = Inputs[2];
                reader.LastName = Inputs[3];
                reader.GroupNum = short.Parse(Inputs[4]);
                reader.DateOfBirth = DateOnly.Parse(Inputs[5]);
                reader.Active = bool.Parse(Inputs[6]);
                reader.Debt = bool.Parse(Inputs[7]);

                _db.SaveChanges();
            }
        }

        public static void DeactivateReader(AbisContext _db, int _gradebookNum)
        {
            Reader reader = _db.Readers.Find(_gradebookNum);

            if (reader != null)
            {
                reader.Active = false;
                try
                {
                    _db.SaveChanges();
                }
                catch
                {
                    reader.Active = true;
                    throw new Exception("Failed to deactivatate a book");
                }
            }
            else
            {
                throw new Exception("Failed to deactivate a book");
            }
        }
    }
}