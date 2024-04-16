using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTracer
{
    public class EqualityTriggerPolicy<T> : BaseTriggerPolicy<T>
    {
        public override bool Trigger(List<T> oldData, T newData)
        {
            //比较最后一个与新的值，不一样则触发
            if (oldData == null || oldData.Count == 0) return false;

            return !oldData.LastOrDefault().Equals(newData);
        }
    }
}
