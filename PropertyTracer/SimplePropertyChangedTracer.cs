using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyTracer
{
    public class SimplePropertyChangedTracer<T> : IPropertyTracer<object>, IDisposable where T : class
    {
        private T targe;
        private Func<T, object> propertyFunc;
        private BaseTriggerPolicy<object> policy = new EqualityTriggerPolicy<object>();
        private object lastPropertyValue;
        private System.Threading.Timer timer;

        public Action<ValueChangedEventArgs<object>> OnNotify { get; set; }

        public SimplePropertyChangedTracer(T targe, Func<T, object> propertyFunc, int refreshInterval = 1000)
        {
            this.targe = targe;
            this.propertyFunc = propertyFunc;

            timer = new Timer(Tick, null, 0, refreshInterval);
        }

        private void Tick(object state)
        {
            if (lastPropertyValue == null)
            {
                lastPropertyValue = propertyFunc(targe);
                return;
            }

            var value = propertyFunc(targe);
            if (policy.Trigger(new List<object>() { lastPropertyValue }, value))
            {
                OnNotify?.Invoke(new ValueChangedEventArgs<object>() { OldValue = lastPropertyValue, NewValue = value });
            }

            lastPropertyValue = value;
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
