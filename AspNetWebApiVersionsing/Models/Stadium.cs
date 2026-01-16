using System;
using System.Collections.Generic;

namespace AspNetWebApiVersionsing.Models;

public partial class Stadium
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int? Capacity { get; set; }

    public int? BuiltYear { get; set; }

    public int? PitchLength { get; set; }

    public int? PitchWidth { get; set; }

    public string? PhotoUrl { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public Guid? StateId { get; set; }

    public Guid? CountryId { get; set; }

    public string? Zipcode { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Country? Country { get; set; }
}
