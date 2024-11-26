using System;
using System.Collections.Generic;

namespace abis;

public partial class BookHistory
{
    public long OperationId { get; set; }

    public long BookIsbn { get; set; }

    public string Action { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual Book BookIsbnNavigation { get; set; } = null!;
}
