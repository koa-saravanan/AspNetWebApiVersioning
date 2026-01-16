using System;
using System.Collections.Generic;

namespace AspNetWebApiVersionsing.Models;

public partial class PlayerStatsCategory
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<PlayerStatsType> PlayerStatsTypes { get; set; } = new List<PlayerStatsType>();
}
