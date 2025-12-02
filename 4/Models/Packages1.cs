using System;
using System.Collections.Generic;

namespace NewspaperServer.Models;

public partial class Packages1
{
    public int PackageId { get; set; }

    public string PackageType { get; set; } = null!;

    public int? Payment { get; set; }

    public int? NumNewspaper { get; set; }

    public string? NumSubscrition { get; set; }

    public virtual ICollection<NewsForPack> NewsForPacks { get; set; } = new List<NewsForPack>();

    public virtual ICollection<Subscrition> Subscritions { get; set; } = new List<Subscrition>();
}
