using System;
using System.Collections.Generic;

namespace abis;

public partial class BookReader
{
    public int ReaderGradebookNum { get; set; }

    public long BookIsbn { get; set; }

    public DateOnly DateBorrowed { get; set; }

    public DateOnly? DateReturned { get; set; }

    public DateOnly DateDeadline { get; set; }

    public bool Returned { get; set; }

    public virtual Book BookIsbnNavigation { get; set; } = null!;

    public virtual Reader ReaderGradebookNumNavigation { get; set; } = null!;
}
