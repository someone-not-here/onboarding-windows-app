### What makes a good variable or function name?
A good variable or function name is clear, descriptive, and consistent. It should instantly tell you what it is or does at a glance and without needing comments, and its style should be consistent with other variable/function names in the codebase.

### What issues can arise from poorly named variables?
Poorly named variables obfuscates the code, making it harder for other developers who are going through it to figure out what anything does or what it's used for.

### How did refactoring improve code readability?
It gretly improved readability by deobfuscating the code and making it easier to understand at a glance without comments.

## Code
**Discounting function in C#, before refactoring:**
```
public double disc(double a, double b, bool c) {
    if (c) {
        return a - (a * b / 100);
    }
    else {
        return a;
    }
}
```
**Discounting function in C#, after refactoring:**
```
public double calculateDiscountedPrice(double originalPrice, double discountPercentage,
                                       bool applyDiscount) {
    if (applyDiscount) {
        return originalPrice - (originalPrice * discountPercentage / 100.0);
    }
    else {
        return originalPrice;
    }
}
```