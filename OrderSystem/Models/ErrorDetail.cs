using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class ErrorDetail
{
    public int Id { get; set; }

    public string? MethodName { get; set; }

    public string? Message { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDateTime { get; set; }
}
