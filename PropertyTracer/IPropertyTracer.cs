using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTracer
{
    internal interface IPropertyTracer<T>
    {
        Action<ValueChangedEventArgs<T>> OnNotify { get; set; }
    }
}
