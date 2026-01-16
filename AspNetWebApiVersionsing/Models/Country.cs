using System;
using System.Collections.Generic;

namespace AspNetWebApiVersionsing.Models;

public partial class Country
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? TwoLetterIsoCode { get; set; }

    public string? ThreeLetterIsoCode { get; set; }

    public string? FlagUrl { get; set; }

    public int? DisplayOrder { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Stadium> Stadia { get; set; } = new List<Stadium>();

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
