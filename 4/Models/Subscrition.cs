using System;
using System.Collections.Generic;

namespace NewspaperServer.Models;

public partial class Subscrition
{
    public int SubId { get; set; }

    public int AddressId { get; set; }

    public DateOnly? DateAdd { get; set; }

    public int PackageId { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual Address1 Address { get; set; } = null!;

    public virtual Packages1 Package { get; set; } = null!;
}
