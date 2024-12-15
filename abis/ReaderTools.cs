using Microsoft.EntityFrameworkCore;
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
            try
            {
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                _db.Readers.Remove(reader);
                throw new Exception(ex.Message);
            }
            ReaderHistoryTools.AddReaderHistory(_db, new List<string> { reader.GradebookNum.ToString(), "Добавление" });
        }
        
        public static void DeleteReader(AbisContext _db, int _gradebookNum)
        {
            Reader reader = _db.Readers.Find(_gradebookNum);

            if (reader != null)
            {
                _db.Readers.Remove(reader);
                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    _db.Readers.Add(reader);
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("Failed to delete a reader: null reference");
            }
        }

        public static void EditReader(AbisContext _db, int _gradebookNum, List<string> Inputs)
        {
            Reader reader = _db.Readers.Find(_gradebookNum);
            Reader reader_reserve = new Reader(reader);

            if (reader != null)
            {
                reader.Surname = Inputs[1];
                reader.FirstName = Inputs[2];
                reader.LastName = Inputs[3];
                reader.GroupNum = short.Parse(Inputs[4]);
                reader.DateOfBirth = DateOnly.Parse(Inputs[5]);
                reader.Active = bool.Parse(Inputs[6]);
                reader.Debt = bool.Parse(Inputs[7]);

                try
                {
                    _db.SaveChanges();
                }
                catch
                {
                    reader = reader_reserve;
                    reader_reserve = null;
                    throw new Exception("Failed to edit a reader");
                }
            }
            else
            {
                throw new Exception("Failed to edit a reader");
            }

            if (reader.Active == false && reader_reserve.Active == true)
            {
                ReaderHistoryTools.AddReaderHistory(_db, new List<string> { reader.GradebookNum.ToString(), "Деактивирован" });
            }
            if (reader.Active == true && reader_reserve.Active == false)
            {
                ReaderHistoryTools.AddReaderHistory(_db, new List<string> { reader.GradebookNum.ToString(), "Активирован" });
            }
        }

        public static void DeactivateReader(AbisContext _db, int _gradebookNum)
        {
            Reader reader = _db.Readers.Find(_gradebookNum);

            if (reader != null && reader.Active == true)
            {
                    reader.Active = false;
                    try
                    {
                        _db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        reader.Active = true;
                        throw new Exception(ex.Message);
                    }
            }
            else
            {
                throw new Exception("Failed to deactivate a book");
            }

            ReaderHistoryTools.AddReaderHistory(_db, new List<string> { reader.GradebookNum.ToString(), "Деактивирован" });
        }

        public static void DebtUpdate(AbisContext _db)
        {
            _db.BookReaders.Load();

            foreach(Reader r in _db.Readers.ToList())
            {
                if (r.Active == true)
                {
                    if (_db.BookReaders.Where(c => c.ReaderGradebookNum == r.GradebookNum && c.Returned != true && c.DateDeadline < DateOnly.FromDateTime(DateTime.Today)).ToList().Count() != 0)
                    {
                        r.Debt = true;
                    }
                    else
                    {
                        r.Debt = false; 
                    }
                }
            }

            _db.SaveChanges(); 
        }
    }
}