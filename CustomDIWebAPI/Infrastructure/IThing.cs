﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomDIWebAPI.Infrastructure
{
    public interface IThing
    {
        IEnumerable<string> ProduceValues();
    }
}
