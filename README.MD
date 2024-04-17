# PropertyTracer
To trace the item in list or the property of Object,
it will notify when trigger the condition

## Useage
#### SimpleValueTracer
``` csharp
var soure = new int[] { 1, 1, 1, 2, 1, 1, 1, 1 };

SimpleValueTracer<int> tracer = new SimpleValueTracer<int>();
tracer.OnNotify = e =>
{
    Console.WriteLine($"value has changed:{e.OldValue}->{e.NewValue}");
};

foreach (var s in soure) tracer.Add(s);
```
this will output:
```
value has changed:1->2
value has changed:2->1
```
#### SimplePropertyChangedTracer
``` csharp
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
```
this will ouput:
```
value has changed:18->19
```

## TODO
- trace the property of a object
- trace the different rate of list
- ...