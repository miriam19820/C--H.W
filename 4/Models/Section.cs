using System;
using System.Collections.Generic;

namespace NewspaperServer.Models;

public partial class Section
{
    public int SectionsId { get; set; }

    public string? NameSec { get; set; }

    public int CategoryId { get; set; }

    public int NewsId { get; set; }

    public string? WorkerId { get; set; }

  

    public virtual Newspaper News { get; set; } = null!;

    public virtual Worker? Worker { get; set; }
}
