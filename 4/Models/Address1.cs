using System;
using System.Collections.Generic;

namespace NewspaperServer.Models;

public partial class Address1
{
    public int AddressId { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int HouseNumber { get; set; }

    public int ZipCode { get; set; }

    public virtual ICollection<Subscrition> Subscritions { get; set; } = new List<Subscrition>();

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
