using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Entries.Order;
using static System.Net.WebRequestMethods;

namespace Domain.Entries.Enums
{
    public enum Status
    {
        New,
        InProgress,
        Completed,
        Cancelled
    }
}
