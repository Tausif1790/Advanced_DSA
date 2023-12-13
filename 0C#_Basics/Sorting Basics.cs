using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Array Initialization
        int[] array = new int[] { 5, 2, 8, 1, 9, 3 };

        // 2. List Initialization
        List<int> list = new List<int> { 5, 2, 8, 1, 9, 3 };

        // 3. Sorting Arrays
        Array.Sort(array); // Sort the array in ascending order
        Array.Reverse(array); // Reverse the array

        // 4. Sorting Lists
        list.Sort(); // Sort the list in ascending order
        list.Reverse(); // Reverse the list

        // 5. Custom Sorting Lists (Descending Order)
        list.Sort((a, b) => b.CompareTo(a));

        var newA = A.OrderByDescending(c => c).ToArray();       // Sort the list in descending order

        // Print Results
        Console.WriteLine("Array: " + string.Join(", ", array));
        Console.WriteLine("List: " + string.Join(", ", list));
    }
}
