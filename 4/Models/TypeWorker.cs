using System;
using System.Collections.Generic;

namespace NewspaperServer.Models;

public partial class TypeWorker
{
    public int TypeWorkerId { get; set; }

    public string? NameType { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
