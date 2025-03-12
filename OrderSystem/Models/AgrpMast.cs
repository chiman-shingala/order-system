using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class AgrpMast
{
    public int Agrcode { get; set; }

    public string Agrname { get; set; } = null!;

    public string? Remark { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}
