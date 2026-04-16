### What made the original code complex?
The original code before refactoring was unnecessarily verbose, uses deeply nested ternary operators, and repeats the same logic multiple times. This makes this very hard to read and maintain.

### How did refactoring improve it?
The new code after refactoring condenses the repeating logic, uses built-in collection handling instead of manual string concatenation, and presents the function with a clearer flow. with these changes, it's now much more readable and easier to maintain.

## Code
**Before refactoring:**
```
public static string FormatName(string first, string last, string middle = null)
{
    return 
        string.IsNullOrWhiteSpace(first) && string.IsNullOrWhiteSpace(last) && string.IsNullOrWhiteSpace(middle) 
            ? string.Empty 
            : (string.IsNullOrWhiteSpace(first) 
                ? "" 
                : first.Trim() + (string.IsNullOrWhiteSpace(middle) && string.IsNullOrWhiteSpace(last) 
                    ? "" 
                    : " ")) 
            + (string.IsNullOrWhiteSpace(middle) 
                ? "" 
                : middle.Trim() + (string.IsNullOrWhiteSpace(last) 
                    ? "" 
                    : " ")) 
            + (string.IsNullOrWhiteSpace(last) 
                ? "" 
                : last.Trim());
}
```
**After refactoring:**
```
public static string FormatName(string first, string last, string middle = null)
{
    var parts = new List<string>();

    if (!string.IsNullOrWhiteSpace(first))
        parts.Add(first.Trim());

    if (!string.IsNullOrWhiteSpace(middle))
        parts.Add(middle.Trim());

    if (!string.IsNullOrWhiteSpace(last))
        parts.Add(last.Trim());

    return string.Join(" ", parts);
}

````