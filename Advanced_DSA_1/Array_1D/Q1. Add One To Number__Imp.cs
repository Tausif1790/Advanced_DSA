Given a non-negative number represented as an array of digits, add 1 to the number 
 ( increment the number represented by the digits ).
The digits are stored such that the most significant digit is at the head of the list.

Inputs:
1. [1, 2, 3]
2. [0,0,0,3,4]
3. [9]
Output:
1. [1, 2, 4]
2. [3, 5] 
3. [1,0]


//---------------------------//
class Solution {
    public List<int> plusOne(List<int> A) {
        int n = A.Count;
        int carry = 1; // Initialize carry to 1 to add it to the least significant digit.
        int num = 0;
        
        // Traverse the digits of the number in reverse order
        for (int i = n - 1; i >= 0; i--) {
            num = A[i];
            num += carry;
            carry = 0;
            if (num == 10) {
                num = 0;
                carry = 1; // Set carry if the current digit is 10 (needs to be carried over).
            }
            A[i] = num; // Update the current digit.
        }
        
        List<int> res = new List<int>();
        if (carry == 1)
            res.Add(1); // If there's still a carry, add a new most significant digit.
        
        for (int i = 0; i < n ; i++) {
            if (A[i] == 0 && res.Count() == 0)
                continue; // Skip leading zeros.

            res.Add(A[i]); // Add the digits to the result.
        }
        
        return res;
    }
}
