﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Common
{
    public class ResponseMessage<T>
    {
        public T Data { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}
