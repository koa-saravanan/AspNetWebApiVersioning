using System;
using System.Collections.Generic;

namespace AspNetWebApiVersionsing.Models;

public partial class PlayerStatsType
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? PlayerStatsCategoryId { get; set; }

    public int? DisplayOrder { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual PlayerStatsCategory? PlayerStatsCategory { get; set; }
}
