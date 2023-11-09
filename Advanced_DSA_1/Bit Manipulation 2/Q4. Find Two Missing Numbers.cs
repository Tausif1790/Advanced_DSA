Given an array A of length N where all the elements are distinct and are in the range [1, N+2].
Two numbers from the range [1, N+2] are missing from the array A. Find the two missing numbers.

Input 1: A = [3, 2, 4]
Input 2: A = [5, 1, 3, 6]

Output 1: [1, 5]
Output 2: [2, 4]

// Similer to 

//------------------------//TC: O(n), SC: O(1)---------------------------//
class Solution {
    public List<int> solve(List<int> A) {
        int n = A.Count;
        int xor = 0;
        List<int> ans = new List<int>();

        // Xor of all el in range [1, N+2] and Actual Array
        for(int i=1; i<=n+2; i++){
            xor = xor ^ i;              
        }
        foreach(int el in A){
            xor = xor ^ el;
        }

        // now we convert this question to Q3. Single Number III
        int rmsb = xor & twosCompliment(xor);      //Right most significant bit // example:- 000010
        int x = 0;                                 // XOR of all el whose 1st bit is 0 (from above example)
        int y = 0;                                 // XOR of all el whose 1st bit is 1 (from above example)

        for(int i=1; i<=n+2; i++){
           if((i & rmsb) == 0){
               x = x ^ i;
           }else{
               y = y ^ i;
           }
        }

        foreach(int el in A){
           if((el & rmsb) == 0){
               x = x ^ el;
           }else{
               y = y ^ el;
           }
        }
        
        ans.Add(Math.Min(x, y));
        ans.Add(Math.Max(x, y));

        return ans;
    }

    int twosCompliment(int a){
        int num = ~a;
        num = num + 1;
        return num;
    }
}

// We will calculate the xor of all the elements of the array and
// xor this value will all integers from 1 to N+2.
// Finally, we will have the xor of the two missing numbers.

// Let the missing numbers be X and Y
// A bit is set in xor only if corresponding bits in X and Y are different.

// So, we find one of the set bits of X^Y and then divide all the element with
// that bit set in one group and those with that bit unset in another group.

// Here, both X and Y will belong to different group. We can easily find the 
// missing number in each group.


// Time Complexity : O(N)
// Space Complexity : O(1)
