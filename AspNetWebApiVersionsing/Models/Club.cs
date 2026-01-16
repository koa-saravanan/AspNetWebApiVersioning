using System;
using System.Collections.Generic;

namespace AspNetWebApiVersionsing.Models;

public partial class Club
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? PhotoUrl { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? FacebookUrl { get; set; }

    public string? TwitterUrl { get; set; }

    public string? YoutubeUrl { get; set; }

    public string? InstagramUrl { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public Guid? StateId { get; set; }

    public Guid? CountryId { get; set; }

    public string? Zipcode { get; set; }

    public Guid? StadiumId { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
