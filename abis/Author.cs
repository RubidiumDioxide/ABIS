using System;
using System.Collections.Generic;

namespace abis;

public partial class Author
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public virtual ICollection<Book> BookIsbns { get; set; } = new List<Book>();
}
