# PropertyTracer
To trace the item in list or the property of Object,
it will notify when trigger the condition

## Useage
``` csharp
var soure = new int[] { 1, 1, 1, 2, 1, 1, 1, 1 };

SimplePropertyTracer<int> tracer = new SimplePropertyTracer<int>();
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

## TODO
- trace the property of a object
- trace the different rate of list
- ...