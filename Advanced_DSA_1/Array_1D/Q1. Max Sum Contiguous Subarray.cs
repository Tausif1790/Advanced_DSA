Find the maximum sum of contiguous non-empty subarray within an array A of length N.

Input 1: A = [1, 2, 3, 4, -10] 
Input 2: A = [-2, 1, -3, 4, -1, 2, 1, -5, 4] 
Output 1: 10 
Output 2: 6 

//------------------------------//TC: O(n), SC: O(1) //Kadane's algo---------------------------------------------//
class Solution {
    public int maxSubArray(List<int> A) {
        int ans = int.MinValue;
        int sum = 0;

        foreach(int el in A){
            sum = sum + el;
            ans = Math.Max(ans, sum);
            if(sum < 0){
                sum = 0;
            }
        }
        return ans;
    }
}


//------------------------------------------------------------------------------------------//
// Approach 1: Using 3 nested loops (TC: O(n^3), SC: O(1)
class Solution
{
    public int maxSubArray(List<int> A)
    {
        int n = A.Count;
        int ans = int.MinValue;

        // Outer loop to start subarray
        for (int i = 0; i < n; i++)
        {
            // Middle loop to end subarray
            for (int j = i; j < n; j++)
            {
                int sum = 0;

                // Inner loop to calculate subarray sum
                for (int k = i; k <= j; k++)
                {
                    sum += A[k];
                }
                ans = Math.Max(ans, sum); // Update the maximum subarray sum
            }
        }

        return ans;
    }
}

//------------------------------------------------------------------------------------------//
// Approach 2: Using prefix sum method for sum of individual subarrays (TC: O(n^2), SC: O(n))
class Solution
{
    public int maxSubArray(List<int> A)
    {
        int n = A.Count;
        int ans = int.MinValue;
        List<int> pf = prefixSum(A); // Calculate prefix sum

        // Outer loop to start subarray
        for (int i = 0; i < n; i++)
        {
            // Middle loop to end subarray
            for (int j = i; j < n; j++)
            {
                int sum = 0;

                if (i == 0)
                {
                    sum = pf[j];                // If i is 0, use full prefix sum from 0 to j
                }
                else
                {
                    sum = pf[j] - pf[i - 1];    // Otherwise, subtract prefix sum from i-1
                }
                ans = Math.Max(ans, sum);        // Update the maximum subarray sum
            }
        }

        return ans;
    }

    // Helper function to calculate prefix sum
    List<int> prefixSum(List<int> A)
    {
        List<int> pf = new List<int>();
        pf.Add(A[0]);
        for (int i = 1; i < A.Count; i++)
        {
            pf.Add(pf[i - 1] + A[i]);
        }

        return pf;                  
    }
}

//------------------------------------------------------------------------------------------//
// Approach 3: Using Contibution technique (TC: O(n^2), SC: O(n))
