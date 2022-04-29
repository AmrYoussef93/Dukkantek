using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Shared
{
    public enum OrderStatus
    {
        InProgress = 1,
        DerliverdToLogisticsCenter = 2,
        OutForDerliverToCustomer = 3,
        Deliverd = 4,
        Cancelled = 5
    }
}
