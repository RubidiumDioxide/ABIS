using System;
using System.Collections.Generic;

namespace abis;

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

    public virtual ReaderHistory? ReaderHistory { get; set; }
}
