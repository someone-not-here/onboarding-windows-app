### Research and summarize the following clean code principles in clean_code.md:
- **Simplicity**: Keep code as simple as possible. Avoid unnecessary complexity, use clear logic, and prefer straightforward solutions over clever ones.
- **Readability**: Code should be easy to understand. Use meaningful names, proper formatting, comments only when needed, and logical structure.
- **Maintainability**: Future developers should be able to work with the code easily. Minimize dependencies, reduce duplication, and make changes low-risk.
- **Consistency**: Follow uniform style, naming conventions, and patterns throughout the codebase. Make the code predictable and easier for teams to work with.
- **Efficiency**: Write performant, optimized code without premature over-engineering. Optimize where it matters — write code that is resource-conscious without sacrificing clarity or correctness.

### Find an example of messy code online (or write one yourself) and describe why it's difficult to read.

The following is a simple add function written in C# coded messily:

```
int A(int a, int b) => 
    ~(~a - b) + 
    ((a & b) << 1) ^ 
    (a ^ b) - 
    (a | b) + 
    (a & ~b | ~a & b) + 
    0x0;
```

The function works, but it's difficult to read because:
- The function name is unclear. "A" doesn't describe what it does.
- How it does addition is unnecessarily complicated with its (over)use of bitwise operations and a lot of redudant operations — for example, ```+ 0x0;``` does nothing, and ```~(~a - b)``` is just ```a + b```.
- No comments or whitespace.
- The function is written as a single-line lambda with multiple operations chained together.

### Rewrite the code in a cleaner, more structured way.
Here is the function re-written to be much simpler and actually readable:
```
// Returns the sum of two integers.
public int Add(int a, int b)
{
    return a + b;
}
```