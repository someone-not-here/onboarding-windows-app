## Research and Learn

### What are the best practices for logging in C# applications (e.g., using frameworks like NLog or Serilog)?
- Prefer structured logging over string concatenation or interpolation. Structured logging treats logs as data, making them queryable, filterable, and analyzable.
- Use appropriate log levels. In regards to Microsoft's ```LogLevel``` enum, use ```Warning``` or ```Error``` in production to reduce noise and costs, and ```Information``` or lower for troubleshooting.
- Never log sensitive data. Log enough context for debugging purposes (e.g. user IDs, operation IDs, date and time, etc.) but anonymize where needed.

### How should exceptions be handled and logged to capture meaningful diagnostic information?
- Don't catch exceptions unless you can handle it. If a method catches an exception but can't do anything meaningful about it (like having empty catch blocks), you risk obfuscating bugs and swallowing errors. Allow exceptions to propogate up the call stack so higher-level methods can handle them appropriately.
- Include the appropriate details within the error message (message, stack trace, context).

### What are common patterns for error handling in production-level code?
- Centralized exception handling
- Result pattern / functional error handling
- Fail-fast / early failures

## Reflection

### How does effective logging contribute to faster troubleshooting and improved code quality?
Effective logging gives developers clues as to how, where, and/or when a bug occurred as well as any culprit methods, which speeds up the debugging process. It also allows the end-users to more effectively report bugs to the developers by attaching a log file with their report.

### Reflect on the impact of exception handling on application stability and user trust.
Users generally don't like their applications to be buggy messes, and they also don't trust developers whose applications are buggy messes. Proper exception handling creates a more stable and robust application, leading to a better reputation for the developers.

### What strategies would you adopt to enhance logging in a complex application?
- Use structured logging.
- Use correlation IDs to group together related logs and errors for easier debugging.
- Have a separation between technical logs and user messages.

## Task

I created very basic logging example using Serilog. The code intentionally tries to divide 40 by 0.

**Code:**

```
using System;
using Serilog;

namespace ExceptionHandling;

class Program
{
    static void Main()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        int x = 40;
        int y = 0;

        try
        {
            Log.Debug("Attempting division of {x} by {y}", x, y);

            int result = x / y;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error during division occurred.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
```

**Documentation:**

![Test1](/issues/_images/Logging_001.jpg)