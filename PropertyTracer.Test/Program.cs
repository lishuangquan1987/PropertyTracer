using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyTracer.Test
{
    internal class Program
    {
        #region SimpleValueTracer
        //static void Main(string[] args)
        //{
        //    var soure = new int[] { 1, 1, 1, 2, 1, 1, 1, 1 };

        //    SimpleValueTracer<int> tracer = new SimpleValueTracer<int>();
        //    tracer.OnNotify = e =>
        //    {
        //        Console.WriteLine($"value has changed:{e.OldValue}->{e.NewValue}");
        //    };

        //    foreach (var s in soure) tracer.Add(s);

        //    Console.ReadLine();
        //}
        #endregion

        #region SimplePropertyTracer
        internal class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {
            Person p = new Person() { Name = "Tony", Age = 18 };
            SimplePropertyChangedTracer<Person> tracer = new SimplePropertyChangedTracer<Person>(p,x=>x.Age);
            tracer.OnNotify = e =>
            {
                Console.WriteLine($"value has changed:{e.OldValue}->{e.NewValue}");
            };

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                if (i == 5)
                {
                    p.Age++;
                }
            }
            Console.ReadLine();
        }
        #endregion
    }
}
