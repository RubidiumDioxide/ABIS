using System;
using System.Collections.Generic;

namespace abis;

public partial class Book
{
    public long Isbn { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public short Pages { get; set; }

    public string PublishingHouse { get; set; } = null!;

    public short YearPublished { get; set; }

    public string? Description { get; set; }

    public byte Quantity { get; set; }

    public bool Active { get; set; }

    public virtual BookHistory? BookHistory { get; set; }

    public virtual ICollection<BookReader> BookReaders { get; set; } = new List<BookReader>();
}
