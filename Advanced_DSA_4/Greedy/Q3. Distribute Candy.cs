Problem Description
N children are standing in a line. Each child is assigned a rating value.
You are giving candies to these children subjected to the following requirements:
Each child must have at least one candy.
Children with a higher rating get more candies than their neighbors.
What is the minimum number of candies you must give?

Input 1: A = [1, 2]
Input 2: A = [1, 5, 2, 1]

Output 1: 3
Output 2: 7
//----------------//  //--------------------//
class Solution {
    public int candy(List<int> A) {
        int n = A.Count;
        int ans = 0;

        // Give all students 1 candy initially
        List<int> arr = new List<int>(new int[n]);
        for (int i = 0; i < n; i++)
        {
            arr[i] = 1;
        }

        // Compare to left neighbor 
        List<int> left = new List<int>(arr);
        for(int i=1; i<n; i++){
            if(A[i] > A[i-1]){
                left[i] = left[i - 1] + 1;  // Increment candy count if the current child has a higher rating than the left neighbor
            }
        }

        // Compare to right neighbor 
        List<int> right = new List<int>(arr);
        for(int i=n-2; i>=0; i--){
            if(A[i] > A[i+1]){
                right[i] = right[i + 1] + 1;  // Increment candy count if the current child has a higher rating than the right neighbor
            }
        }

        // Final distributed candies
        List<int> final = new List<int>(new int[n]);
        for (int i = 0; i < n; i++)
        {
            final[i] = Math.Max(left[i], right[i]);  // Choose the maximum count of candies between left and right comparisons
        }

        // Total candies distributed
        foreach(int el in final){
            ans += el;  // Accumulate the total number of candies distributed
        }
        return ans;  // Return the overall minimum number of candies required
    }
}
