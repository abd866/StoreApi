﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities.OrderEntity
{
    public enum OrderStuates
    {
        Placed,
        Running,
        Delevring,
        Delivered,
        Cancaled
    }
}
