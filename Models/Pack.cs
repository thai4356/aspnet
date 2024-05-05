using System;
using System.Collections.Generic;

namespace Italian_Restaurant.Models;

public partial class Pack
{
    public int PackId { get; set; }

    public string? PackName { get; set; }

    public int? PackLenght { get; set; }
}
