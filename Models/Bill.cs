using System;
using System.Collections.Generic;

namespace Italian_Restaurant.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public decimal? Total { get; set; }
}
