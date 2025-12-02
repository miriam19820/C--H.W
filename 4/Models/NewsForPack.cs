using System;
using System.Collections.Generic;

namespace NewspaperServer.Models;

public partial class NewsForPack
{
    public int NewsForPackId { get; set; }

    public int PackageId { get; set; }

    public int NewsId { get; set; }

    public virtual Newspaper News { get; set; } = null!;

    public virtual Packages1 Package { get; set; } = null!;
}
