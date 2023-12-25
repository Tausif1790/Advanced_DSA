You are given three positive integers, A, B, and C.
Any positive integer is magical if divisible by either B or C.
Return the Ath smallest magical number. Since the answer may be very large, return modulo 109 + 7.
Note: Ensure to prevent integer overflow while calculating.

Input 1:
 A = 1
 B = 2
 C = 3
Input 2:
 A = 4
 B = 2
 C = 3

Output 1: 2
Output 2: 

//-------------------------// O(logn) //-----------------------------//
class Solution {
    long mod = (long)Math.Pow(10, 9) + 7;

    public int solve(int A, int B, int C) {
        long start = Math.Min(B, C);
        long end = A * start;
        long ans = 0;

        while(start <= end){
            long mid = (start + end) / 2;
            long x = CountMagicalNumbers(mid, B, C);    // mid is the xth magical number (possible)

            if(x > A){
                end = mid - 1;
            }
            else if(x < A){
                start = mid + 1;
            }
            else{ // x == A
                ans = mid % mod;            // update ans and go left (check notes)
                end = mid - 1;
            }
        }

        return (int)ans;
    }

    // Function to count the number of magical numbers less than or equal to x
    public long CountMagicalNumbers(long x, long b, long c){
        return x/b + x/c - x/LCM(b, c);
    }

    // Function to calculate the least common multiple of a and b
    public long LCM(long a, long b){
        long ans = (a*b)/GCD(a, b);
        return ans;
    }

    // Function to calculate the greatest common divisor of a and b
    public long GCD(long a, long b){
        if(b == 0){
            return a;
        }
        return GCD(b, a%b);
    }
}
