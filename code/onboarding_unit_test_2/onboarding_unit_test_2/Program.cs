using System;

namespace onboarding_unit_test_2;

static public class Program
{
    static void Main()
    {
        Console.WriteLine(Add(5, 5));
        Console.WriteLine(Sub(8, 3));
        Console.WriteLine(IsEven(4));
    }

    public static int Add(int x, int y)
    {
        return x + y;
    }

    public static int Sub(int x, int y)
    {
        return x - y;
    }

    public static bool IsEven(int x)
    {
        return x % 2 == 0;
    }
}