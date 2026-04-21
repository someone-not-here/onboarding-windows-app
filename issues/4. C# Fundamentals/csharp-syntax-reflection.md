## Research and Learn

### What are the primary data types in C# (e.g., int, string, bool, etc.)?
- ```int```: stores whole numbers from -2,147,483,648 to 2,147,483,647
- ```float```: stores decimal numbers at a precision of 32 bits
- ```double```: stores decimal numbers at a precision of 64 bits
- ```decimal```: stores decimal numbers at a precision of 128 bits
- ```bool```: either true or false
- ```char```: stores a single character or letter
- ```string```: stores a sequence of characters

### How do variables, constants, and operators function in C#?
- **Variables** store data that can be modified
- **Constants** are variables whose data cannot be modified after initialization
- **Operators** perform actions on data, including but not limited to into: 
    - *arithmetic* (+, -, *, /), 
    - *relational* (==, !=, >, <, =>, <=)
    - *logical* (&&, ||, !)
    - *increment/decrement* (++, --)
    - *bitwise* (&, |, ^, ~, <<, >>)

### What are the common pitfalls with type conversions in C#?
- Loss of precision when converting floats/doubles/decimals to non-decimal data types
- Arithmetic overflows and wraparounds
- Incompatible casts, such as between ```int``` and ```string```
- Parsing exceptions when trying to incorrectly parse data, such as using ```int.Parse()``` on ```"hello"```

## Reflection

### Which aspects of C# syntax were new or surprising?
Parsing for ```int``` within a ```string``` variable is surprisingly easy. There's also the different ways for explicit conversion.

### How do data types influence performance and memory management in your code?
Choosing the right data types can help with memory usage and application performance. Using ```bool``` instead of ```int``` for a true/false flag is a much more efficient use of memory.

### What practices can help avoid common type-related errors?
- Explicitly declare variable types
- Use compile time type-checking to catch errors and mismatches
- Use ```is``` and ```as``` operators to safely check for type and cast validity
## Task

**Code:**

```
using System;

class MainClass
{
    public static void Main() {
        // Data types
        int number1 = 100;
        int number2 = 25;
        string helloString = "500";
        bool isFinished = true;

        // Arithmetic operator and implicit conversion to float
        float product = number1 * number2;
        Console.WriteLine($"Product: {product}");

        // Explicit conversion to double
        double number2Double = (double)number2;
        Console.WriteLine($"number2 converted: {number2Double}");

        // Relational operator and parsing of string to int
        if (isFinished == true) {
            int helloStringParsed = int.Parse(helloString);
            Console.WriteLine($"Parsed string: {helloStringParsed}");
        }
    }
}
```