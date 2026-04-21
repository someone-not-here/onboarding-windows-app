## Research and Learn

### What are the best practices for exception handling in C#?
- Use exceptions for exceptional cases only. Don't use them for normal control flow.
- Unless at the top level, catch specific exceptions instead of generic ones.
- Most specific exceptions first, base classes last.
- Avoid empty catch blocks that swallow errors silently.
- Fail fast. Throw early with clear and meaningful messages.

### How do try-catch-finally blocks work, and when should you use them?
In C#, these blocks work and are laid out like so:

```
try
{
    // Code that may throw exceptions
}
catch (SpecificException ex) // Looks out for specific, known exceptions
{
    // Code to handle exception
}
catch (Exception ex) // Looks out for unexpected exceptions
{
    // Code to handle exception
}
finally
{
    // Code that always runs after (usually clean-up code)
}
```

These blocks are used when working with files, databases, APIs, and user input — anything that can't be totally controlled by the program. It's also used when clean-up is required, regardless of succes or failure, as well logging for debugging purposes.

### What debugging tools in Visual Studio help diagnose runtime issues?
Visual Studio's debugger includes the following tools to help wtih debugging:
- **Breakpoints and stepping tools:** able to pause execution on specified breakpoints, step through the code line-by-line or into called functions, and shows the call stack.
- **Inspection and state analysis tools:** Shows variable values in real time to diagnose incorrect state or logic errors.
- **Exception handling tools:** Pauses the debugger when an exception is thrown and shows details.
- **Diagnostic tools:** Shows CPU and memory usage and metrics such as garbage collections, exceptions per second, and thread activity.

## Reflection

### Reflect on a time when proper exception handling prevented a major issue.
In my written code, proper exception handling prevented the app from crashing upon input of a non-number or 0 for the denominator. It also reported the type of error that occured.

### What debugging techniques did you find most effective?
- Use breakpoints and steps to go through the code line-by-line.
- See how variables change as you step through the code.

### How can you improve error logging and reporting in your code?
- Use a logging framework.
- Bundle stack traces with log exception messages.

## Task

**Code:**
```
using System;

namespace onboarding_exceptions;

static class MainClass
{
    public static void Main() {
        Console.WriteLine("Write a numerator: ");
        int numerator = int.Parse(Console.ReadLine());

        Console.WriteLine("Write a denominator: ");
        int denominator = int.Parse(Console.ReadLine());

        try
        {
            int result = numerator / denominator;
            Console.WriteLine($"Result: {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: You cannot divide by zero.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: You can only input in numbers.");
        }
        catch (Exception)
        {
            Console.WriteLine("Unexpected error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Execution finished!");
        }
    }
}
```

*Steps on how to debug:*
1. Put a breakpoint on ```int result = numerator / denominator;```.
2. Run the program in debug mode.
3. Enter a non-number or 0 for the denominator.
4. Use step-over to observe exception flow.
5. Check the call stack and locals window when the exception occurs.