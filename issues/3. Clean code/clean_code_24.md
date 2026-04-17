### When should you add comments?
Aside from documentation comments, in-code comments should be used sparingly to explain the reasoning for complex logic, assumptions, and non-obvious decisions — anything that may not be so obvious to anyone reading the code for the first time.

### When should you avoid comments and instead improve the code?
You should avoid adding a comment when what you're about to write either states the obvious (don't write the comment) or is trying to explain poorly written/named code (refactor the code).

## Code
**Poorly commented code:**
```
public int Calc(int a, int b, string operation) {
    // a         : first value given
    // b         : second value given
    // operation : what operation (add, sub, mul)

    if (operation == "add") {
        return a + b;               // Addition
    }      
    else if (operation == "sub") {
        return a - b;               // Subtraction
    }
    else if (operation == "mul") {
        return a * b;               // Multiplication
    }   
    else {
        return 0;                   // We return 0 if Type given is invalid
    }                 
}
```
**Properly commented code:**
```
/*
   Function    : Calc()

   Performs calcuation (based on given operation) on two numeric values
   Throws exception if operation is invalid
*/ 
public int Calc(int a, int b, string operation) {
    if (operation == "add") {
        return a + b;
    }
    else if (operation == "sub") {
        return a - b;
    }
    else if (operation == "mul") {
        return a * b;
    }
    else {
        throw new ArgumentException($"Unsupported operation: '{operation}'. Supported operations are: add, subtract, multiply.", nameof(operation))
    }
}
```