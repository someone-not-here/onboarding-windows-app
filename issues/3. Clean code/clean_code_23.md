### What was the issue with the original code?
The two example functions had different problems. The first one, a division function, did not account for the denominator being zero, potentially causing an error. The second one, a function that fills in a given array with numbers, did not account for the length of the given array, potentially causing an out of bounds error for smaller arrays, or failing to fill out all elements in larger ones.

### How does handling errors improve reliability?
Error handling prevents small errors from cascading into full-blown crashes or silent failures. Proper implementation helps in catching problems early before they corrupt data or state, allows the program to continue running without termination, and improves debugging and monitoring. These all help to make the code more robust and reliable.

## Code

*Code location: code/clean_code_23.cs*

```
// A division function with poor error handling
// - Does not account for a denominator of zero
public int Divide(int numerator, int denominator) {
    return numerator / denominator;
}

// A divison function with proper error handling
// - Has a guard clause that checks if denominator is zero
public int Divide(int numerator, int denominator) {
    if (denominator == 0) { 
        throw new ArgumentException("Denominator can't be zero.", nameof(denominator));
    }

    return numerator / denominator;
}

// --------------------------------------------------------------------------------------

// A function that fills an array with numbers with poor error handling
// - Does not account for smaller arrays, could possibly go out of bounds
// - Only fills in the first 10 elements of any larger array
public void FillNumberArray(int[] array) {
    for (int i = 0; i <= 10, i++) {
        array[i] = i;
    }
}

// The fixed version
// - Now checks for array length before filling, uses length to determine stopping point of for loop
public void FillNumberArray(int[] array) {
    int arrayLength = array.Length;

    for (int i = 0; i < array.Length, i++) {
        array[i] = i;
    }
}
```