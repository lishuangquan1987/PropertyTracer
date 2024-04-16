﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTracer
{
    public class ValueChangedEventArgs<T>:EventArgs
    {
        public T OldValue { get; set; }
        public T NewValue { get; set; }
    }
}
