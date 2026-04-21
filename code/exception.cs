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