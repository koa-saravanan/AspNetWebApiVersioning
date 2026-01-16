using System;
using System.Collections.Generic;

namespace AspNetWebApiVersionsing.Models;

public partial class Player
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int? ShirtNo { get; set; }

    public Guid? ClubId { get; set; }

    public int? Position { get; set; }

    public string? PhotoUrl { get; set; }

    public Guid? CountryId { get; set; }

    public DateTime? BirthDate { get; set; }

    public int? HeightInCm { get; set; }

    public string? FacebookUrl { get; set; }

    public string? TwitterUrl { get; set; }

    public string? InstagramUrl { get; set; }

    public bool? IsDeleted { get; set; }

    public int? DisplayOrder { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Club? Club { get; set; }

    public virtual Country? Country { get; set; }
}
