### How do unit tests help keep code clean?
Unit tests encourage developers to make functions small, focused, and loosely coupled, as messy and tangled code make testing them hard. The easier they are to test, the more readable, modular, and simpler they are.

### What issues did you find while testing?
Tests for IsEven() identified a possible problem when inputting numbers below zero (will always throw a false).

## Code

*Unit test used was XUnit.*

*Code locations:* 
- *code/onboarding_unit_test_2/onboarding_unit_test_2/Program.cs*
- *code/onboarding_unit_test_2/onboarding_unit_test_2.Tests/ProgramTests.cs*

**Program.cs:**
```
using System;

namespace onboarding_unit_test_2;

static public class Program
{
    static void Main() {
        Console.WriteLine(Add(5, 5));
        Console.WriteLine(Sub(8, 3));
        Console.WriteLine(IsEven(4));
    }

    public static int Add(int x, int y) {
        return x + y;
    }

    public static int Sub(int x, int y) {
        return x - y;
    }

    public static bool IsEven(int x) {
        return x % 2 == 0;
    }
}
```

**ProgramTests.cs:**
```
using System;
using System.Reflection;
using onboarding_unit_test_2;
using Xunit;

namespace onboarding_unit_test_2.Tests;

public class ProgramTests
{
    [Fact]
    public void Add_Should_Equal_2() {
        Assert.Equal(2, Program.Add(1, 1));
    }

    [Fact]
    public void Add_Should_Not_Equal_5() {
        Assert.NotEqual(5, Program.Add(3, 3));
    }

    [Theory]
    [InlineData(4, 4)]
    [InlineData(3, 5)]
    [InlineData(7, 1)]
    public void Add_Should_Equal_8(int x, int y) {
        Assert.Equal(8, Program.Add(x, y));
    }

    [Fact]
    public void Sub_Should_Equal_3() {
        Assert.Equal(2, Program.Sub(6, 4));
    }

    [Fact]
    public void Sub_Should_Not_Equal_8() {
        Assert.NotEqual(8, (Program.Sub(10, 1)));
    }

    [Theory]
    [InlineData(2, 5)]
    [InlineData(4, 7)]
    [InlineData(13, 16)]
    public void Sub_Should_Equal_Neg3(int x, int y) {
        Assert.Equal(-3, Program.Sub(x, y));
    }

    [Fact]
    public void IsEven_3_Should_Be_False() {
        Assert.False(Program.IsEven(3));
    }

    [Fact]
    public void IsEven_6_Should_Be_True() {
        Assert.True(Program.IsEven(6));
    }

    [Theory]
    [InlineData(4)]
    [InlineData(22)]
    [InlineData(12)]
    [InlineData(106)]
    public void IsEven_All_True(int value) {
        Assert.True(Program.IsEven(value));
    }
}
```