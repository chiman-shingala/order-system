using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class EmailSetting
{
    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Smtpserver { get; set; }

    public int? Port { get; set; }
}
