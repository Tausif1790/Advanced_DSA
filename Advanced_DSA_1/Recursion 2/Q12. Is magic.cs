Input 1: A = 83557
Input 2: A = 1291

Output 1: 1
Output 2: 0

Explanation 1:

 Sum of digits of (83557) = 28
 Sum of digits of (28) = 10
 Sum of digits of (10) = 1. 
 Single digit is 1, so it's a magic number. Return 1.
//--------------------------------------------------------------//
class Solution {
    public int solve(int A) {
        // Base case: If A is a single-digit number and equals 1, return 1
        if (A / 10 == 0 && A == 1) {
            return 1;
        }
        // Base case: If A is a single-digit number and not equal to 1, return 0
        if (A / 10 == 0 && A != 1) {
            return 0;
        }

        int sum = sumOfDigits(A);         // Calculate the sum of digits of A
        return solve(sum);                // Recursively call solve with the sum of digits
    }

    public int sumOfDigits(int num){
        int sum = 0;
        while(num != 0){
            int x = num % 10;
            sum += x;
            num = num/10;
        }
        return sum;
    }
}
