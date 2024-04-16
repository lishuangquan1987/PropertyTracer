using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTracer.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var soure = new int[] { 1, 1, 1, 2, 1, 1, 1, 1 };

            SimplePropertyTracer<int> tracer = new SimplePropertyTracer<int>();
            tracer.OnNotify = e =>
            {
                Console.WriteLine($"value has changed:{e.OldValue}->{e.NewValue}");
            };

            foreach (var s in soure) tracer.Add(s);

            Console.ReadLine();
        }
    }
}
