﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Wrappers
{
    public class ServiceDataResponse<T> : ServiceResponse
    {
        public T Paylod { get; set; }
    }
}
