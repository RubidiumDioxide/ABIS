using System;
using System.Collections.Generic;

namespace abis.Entities;

public partial class Reader
{
    public int GradebookNum { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public short GroupNum { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public bool Active { get; set; }

    public bool Debt { get; set; }

    public virtual ICollection<BookReader> BookReaders { get; set; } = new List<BookReader>();

    public virtual ICollection<ReaderHistory> ReaderHistories { get; set; } = new List<ReaderHistory>();

    public Reader() { }

    public Reader(Reader reader)
    {
        GradebookNum = reader.GradebookNum;
        Surname = reader.Surname;
        FirstName = reader.FirstName;
        LastName = reader.LastName;
        GroupNum = reader.GroupNum;
        DateOfBirth = reader.DateOfBirth;
        Active = reader.Active;
        Debt = reader.Debt;
    }
}
