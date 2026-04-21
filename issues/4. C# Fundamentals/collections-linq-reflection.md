## Research and Learn

### What are the common collection types in C# (e.g., List, Dictionary, Array, etc.)?
- ```Array```: fixed size, fast access via index
- ```List```: array with dynamic size, able to remove and add elements
- ```Dictionary```: key-value pairs
- ```HashSet```: each element is unique, no duplicates allowed

### How does LINQ simplify data queries compared to traditional loops and conditional logic?
Language Integrated Query allows the querying of collections using a declarative syntax. Here is a comparison between a traditional loop and LINQ:

```
List<int> numbers = new List<int>;

// Traditional Loop
foreach (int n in numbers) {
    if (n % 2 == 0) {
        Console.WriteLine("Even!");
    }
}

// Using LINQ
numbers.Where(n => n % 2 == 0).ToList().ForEach(Console.WriteLine("Even!"))
```

With LINQ, there's less code, making it much easier to read. It also reduces boilerplate code.

### What are some performance considerations when choosing a collection type?
- Time complexity and operation efficiency for lookups and insertions
- Memory allocation and overhead caused by resizing
- Concurrency and the cost for sorting a collection

## Reflection

### Which collection type do you find most useful for different scenarios and why?
I find ```Lists``` to be generally useful for most data handling due to its flexibilty as opposed to an ```Array```. ```Dictionaries``` are also useful if I need a collection type that has a fast lookup speed.

### How does using LINQ improve code readability and efficiency?
LINQ allows developers to express how data is manipulated declaratively rather than imperatively. Instead of manually writing loops and conditionals and gumming up the codebase with boilerplate, developers can use expressive, natural-sound methods (```.Where()```, ```.Select()```, etc.) that get their intent across much quicker.

### Reflect on a situation where switching to a LINQ-based approach could simplify your code.
With LINQ, filtering, grouping, sorting, and transforming collections can greatly simplified simply due to its declarative nature. I don't have to use boilerplate code to do any of this.

## Task

**Code:**

```
using System;
using System.Globalization;
using System.Linq;

class MainClass 
{
    static void Main()
    {
        List<int> numbers = new List<int> {3, 1, 4, 1, 5, 9, 2, 6};

        Dictionary<string, bool> eventStates = new Dictionary<string, bool>
        {
            {"Event1", true},
            {"Event2", false},
            {"Event3", true}
        };

        Console.WriteLine("Numbers less than or equal to 2: ");
        numbers.Where(n => n <= 2).ToList().ForEach(Console.WriteLine);

        Console.WriteLine("Events flagged as true: ");
        eventStates.Where(pair => pair.Value == true).Select(pair => pair.Key).ToList().ForEach(Console.WriteLine);
    }
}
```