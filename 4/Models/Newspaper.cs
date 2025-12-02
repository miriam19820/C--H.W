using System;
using System.Collections.Generic;

namespace NewspaperServer.Models;

public partial class Newspaper
{
    public int NewsId { get; set; }

    public string? TypeNews { get; set; }

    public virtual ICollection<NewsForPack> NewsForPacks { get; set; } = new List<NewsForPack>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
