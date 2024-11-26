using System;
using System.Collections.Generic;

namespace abis;

public partial class ReaderHistory
{
    public long OperationId { get; set; }

    public int ReaderGradebookNum { get; set; }

    public string Action { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual Reader ReaderGradebookNumNavigation { get; set; } = null!;
}
