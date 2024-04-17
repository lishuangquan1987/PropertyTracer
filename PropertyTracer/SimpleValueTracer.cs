using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTracer
{
    public class SimpleValueTracer<T> : IPropertyTracer<T> where T : IComparable
    {
        private List<T> list = new List<T>();
        private int maxCapacity;
        private BaseTriggerPolicy<T> policy;
        public SimpleValueTracer(BaseTriggerPolicy<T> policy = null, int maxCapacity = 100)
        {
            this.maxCapacity = maxCapacity;
            this.policy = policy ?? new EqualityTriggerPolicy<T>();
        }

        public Action<ValueChangedEventArgs<T>> OnNotify { get; set; }

        public void Add(T item)
        {
            if (policy.Trigger(list, item))
            {
                OnNotify(new ValueChangedEventArgs<T>() { OldValue = list.LastOrDefault(), NewValue = item });
            }
            list.Add(item);
            if (list.Count > maxCapacity)
            {
                list.RemoveAt(0);
            }
        }


    }
}
