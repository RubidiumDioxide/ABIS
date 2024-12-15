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

    public virtual ICollection<BookHistory> BookHistories { get; set; } = new List<BookHistory>();

    public virtual ICollection<BookReader> BookReaders { get; set; } = new List<BookReader>();

    public Book() { }

    public Book(Book book)
    {
        Isbn = book.Isbn;
        Title = book.Title;
        Author = book.Author;
        Pages = book.Pages;
        PublishingHouse = book.PublishingHouse;
        YearPublished = book.YearPublished;
        Description = book.Description;
        Quantity = book.Quantity;
        Active = book.Active;
    }
}
