Given an integer A. Compute and return the square root of A.
If A is not a perfect square, return floor(sqrt(A)).

NOTE: 
   The value of A*A can cross the range of Integer.
   Do not use the sqrt function from the standard library. 
   Users are expected to solve this in O(log(A)) time.

Input 1: 11
Input 2: 9

Output 1: 3
Output 2: 3

//--------------------// O(log(A)) //---------------------------------//
class Solution {
    public int sqrt(int A) {
        // If A is 0 or 1, the square root is A itself
        if(A == 0 || A == 1){
            return A;
        }

        long ans = 0;
        long start = 1;
        long end = A;

        // Binary search to find the square root
        while(start <= end){
            long mid = (start + end) / 2;          // mid => midSqrt
            
            // If the square of mid is equal to A, mid is the square root
            if(mid * mid == A){
                return (int)mid;
            }
            // If the square of mid is less than A, update the answer and search in the right half
            else if(mid * mid < A){
                start = mid + 1;
                ans = mid;
            }
            // If the square of mid is greater than A, search in the left half
            else{                               // mid * mid > A
                end = mid - 1;
            }
        }

        // Return the floor value of the square root
        return (int)ans;
    }
}
