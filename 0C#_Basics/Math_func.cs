using System;

class MathFunctions
{
    static void Main()
    {
        // Max
        double maxResult = Math.Max(10, 20); // Maximum between 10 and 20 is 20

        double minResult = Math.Min(10, 20); // Minimum between 10 and 20 is 10

        // Absolute value
        double absoluteValue = Math.Abs(-5.5); // Absolute value of -5.5 is 5.5

        // Power
        double powerResult = Math.Pow(2, 3); // 2^3 = 8

        // Square root
        double squareRoot = Math.Sqrt(25); // Square root of 25 is 5

        // Exponential (e^x)
        double exponential = Math.Exp(1); // e^1 = 2.71828...

        // int max value
        int max = int.MinValue;

        // Rounding
        double roundedValue = Math.Round(3.75); // Round 3.75 to the nearest integer: 4
        double floorValue = Math.Floor(3.75);   // Floor of 3.75 is 3 (largest integer less than or equal to 3.75)
        double ceilingValue = Math.Ceiling(3.25); // Ceiling of 3.25 is 4 (smallest integer greater than or equal to 3.25)

        // Output with comments
        Console.WriteLine("Absolute Value: " + absoluteValue);
        Console.WriteLine("Power: " + powerResult);
        Console.WriteLine("Square Root: " + squareRoot);
        Console.WriteLine("Exponential: " + exponential);
        Console.WriteLine("Maximum: " + maxResult);
    }
}
