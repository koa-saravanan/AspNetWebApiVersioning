using System;
using System.Collections.Generic;

namespace AspNetWebApiVersionsing.Models;

public partial class State
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? IsoCode { get; set; }

    public Guid? CountryId { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Country? Country { get; set; }
}
