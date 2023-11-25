Problem Description
You are given a binary string A(i.e., with characters 0 and 1) consisting of characters A1, A2, ..., AN.
    In a single operation, you can choose two indices, L and R, such that 1 ≤ L ≤ R ≤ N and flip the characters AL, AL+1, ..., AR.
    By flipping, we mean changing character 0 to 1 and vice-versa.
Your aim is to perform ATMOST one operation such that in the final string number of 1s is maximized.
If you don't want to perform the operation, return an empty array. Else, return an array consisting of two elements denoting L and R.
    If there are multiple solutions, return the lexicographically smallest pair of L and R.
NOTE: Pair (a, b) is lexicographically smaller than pair (c, d) if a < c or, if a == c and b < d.

Input 1: A = "010"
Input 2: A = "111"

Output 1: [1, 1]
Output 2: []

//--------------------------//See in notes----------------------------------//
class Solution {
    public List<int> flip(string A) {
        int l = 0, r = 0, currSum = 0, maxSum = 0, n = A.Length;
        int[] ans = new int[2];
        
        for(int i=0; i<n; i++){
            char ch = A[i];
            if(ch == '1'){
                currSum -= 1;            // Kadane's algo
            }else{
                currSum += 1;
            }

            if(currSum > maxSum){
                maxSum = currSum;
                ans[0] = l + 1;           // l + 1 => because 1-indexing // l and r will only update when currSum > maxSum
                ans[1] = r + 1;           // Update the starting and ending index of the optimal subarray.
            }

            if(currSum < 0){
                currSum = 0;
                l = i + 1;              // if currSum < 0 => reset l and r      
                r = i + 1;              // Reset the starting and ending index to the current position.
            }
            else{
                r += 1;                // if currSum is positive => shift r by 1              
            }
        }

        if(maxSum == 0){               // whole array only contains 1's => return empty array
            return new List<int>();
        }
        
        return new List<int>(ans);
    }
}

//TC: O(n)
//SC: O(1)