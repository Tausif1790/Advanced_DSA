Given a number A, find if it is COLORFUL number or not.
If number A is a COLORFUL number return 1 else, return 0.

What is a COLORFUL Number:
A number can be broken into different consecutive sequence of digits. 
The number 3245 can be broken into sequences like 3, 2, 4, 5, 32, 24, 45, 324, 245 and 3245. 
This number is a COLORFUL number, since the product of every consecutive sequence of digits is different
//---------------------------------------------------------//
using System;
using System.Collections.Generic;

class Solution {
    public int colorful(int A) {
        // Convert the number to an array of digits.
        int[] digits = GetDigits(A);

        // Use a HashSet to store products of consecutive sequences of digits.
        HashSet<int> productSet = new HashSet<int>();

        // Iterate through all possible consecutive sequences of digits.
        for (int i = 0; i < digits.Length; i++) {
            int product = 1;
            for (int j = i; j < digits.Length; j++) {
                product *= digits[j];

                // If the product is already in the set, it's not a COLORFUL number.
                if (productSet.Contains(product)) {
                    return 0;
                }

                // Otherwise, add the product to the set.
                productSet.Add(product);
            }
        }

        // If no duplicates were found, it's a COLORFUL number.
        return 1;
    }

    // Helper method to convert a number to an array of digits.
    private int[] GetDigits(int number) {
        List<int> digitsList = new List<int>();

        while (number > 0) {
            int digit = number % 10;
            digitsList.Insert(0, digit); // Insert at the beginning to maintain order.
            number /= 10;
        }

        return digitsList.ToArray();
    }
}
