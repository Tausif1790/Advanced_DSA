Given a number A, we need to find the sum of its digits using recursion.

Input 1:A = 46
Output 1: 10

//---------------------------------------------------//
class Solution {
    public int solve(int A) {
        if(A / 10 == 0){
            return A;
        }

        int sa = solve(A/10);          // Recursively call the function with A/10 (smaller input).
        return sa + A % 10;            // Add the last digit of A to the result from the smaller input.
    }
}

/*
Step by step process for better understanding of how the algorithm works.
Let the number be 12345.
Step 1-> 12345 % 10 which is equal-too 5 + ( send 12345/10 to next step ),
Step 2-> 1234 % 10 which is equal-too 4 + ( send 1234/10 to next step ),
Step 3-> 123 % 10 which is equal-too 3 + ( send 123/10 to next step ),
Step 4-> 12 % 10 which is equal-too 2 + ( send 12/10 to next step ),
Step 5-> 1 % 10 which is equal-too 1 + ( send 1/10 to next step ),
Step 6-> 0 algorithm stops.
Following diagram will illustrate the process of recursion.
*/


