using System;

class BitManipulationDemo
{
    static void Main()
    {
        // left shift operator
        a << n => a * 2^n;
        1 << n => 1 * 2^n;
        2 << 3 => 2 * 2^3 => 16;

        // Right shift operator
        a >> n => a / 2^n;
        16 >> 2 => 16 / 2^2 => 4

        // Set a specific bit (bit number 2) to 1
        int originalValue = 10; // Binary: 1010
        int position = 2;
        int updatedValue = originalValue | (1 << position); // Binary: 1110
        Console.WriteLine("Setting bit at position 2 to 1: " + updatedValue);

        // Clear a specific bit (bit number 1) to 0
        originalValue = 7; // Binary: 0111
        position = 1;
        updatedValue = originalValue & ~(1 << position); // Binary: 0101
        Console.WriteLine("Clearing bit at position 1 to 0: " + updatedValue);

        // Toggle a specific bit (bit number 3)
        originalValue = 12; // Binary: 1100
        position = 3;
        updatedValue = originalValue ^ (1 << position); // Binary: 1000
        Console.WriteLine("Toggling bit at position 3: " + updatedValue);

        // Check if a specific bit (bit number 2) is set
        originalValue = 6; // Binary: 0110
        position = 2;
        bool isSet = (originalValue & (1 << position)) != 0;
        Console.WriteLine("Bit at position 2 is set: " + isSet);

        // Set all bits from position 2 to 4 to 1
        originalValue = 2; // Binary: 0010
        int start = 2;
        int end = 4;
        int mask = (1 << (end - start + 1)) - 1;
        updatedValue = originalValue | (mask << start); // Binary: 1110
        Console.WriteLine("Setting bits from position 2 to 4 to 1: " + updatedValue);
    }
}
