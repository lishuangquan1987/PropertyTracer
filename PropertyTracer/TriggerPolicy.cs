using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTracer
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseTriggerPolicy<T>
    {
        public abstract bool Trigger(List<T> oldData, T newData);
    }
}
