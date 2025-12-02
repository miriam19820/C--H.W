using System;
using System.Collections.Generic;

namespace NewspaperServer.Models;

public partial class Worker
{
  

    public string WorkerId { get; set; } = null!;

    public int? AddressId { get; set; }

    public int? TypeWorkerId { get; set; }

    public int? SalaryForHour { get; set; }

    public int? NumForWeek { get; set; }

    public virtual Address1? Address { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual TypeWorker? TypeWorker { get; set; }
}