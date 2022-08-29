﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car.Repository
{
    public interface IReservation
    {
        DateTime ReservedFrom { get; set; }
        DateTime ReservedTo { get; set; }
    }
}
