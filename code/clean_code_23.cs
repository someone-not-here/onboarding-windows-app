// A division function with poor error handling
// - Does not account for a denominator of zero
public int Divide(int numerator, int denominator) {
    return numerator / denominator;
}

// A divison function with proper error handling
// - Has a guard clause that checks if denominator is zero
public int Divide(int numerator, int denominator) {
    if (denominator == 0) { 
        throw new ArgumentException("Denomaintor can't be zero.", nameof(denominator));
    }

    return numerator / denominator;
}

// ----------------------------------------------------------------------------------------------

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