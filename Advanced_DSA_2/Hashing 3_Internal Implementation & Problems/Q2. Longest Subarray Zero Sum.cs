Given an array A of N integers.
Find the length of the longest subarray in the array which sums to zero.
If there is no subarray which sums to zero then return 0.

Input 1: A = [1, -2, 1, 2]
Input 2: A = [3, 2, -1]

Output 1:3
Output 2:0
//-----------------------------------------------//
class Solution {
    public int solve(List<int> A) {
        int n = A.Count;
        Dictionary<long, int> dict = new Dictionary<long, int>();
        List<long> pf = PrefixSum(A);
        int ans = int.MinValue;

        for(int i=0; i<n; i++){
            // Check if the current prefix sum is zero.
            if(pf[i] == 0){
                ans = Math.Max(ans, i + 1);
            }

            // Check if the current prefix sum has been encountered before.
            if(dict.ContainsKey(pf[i])){
                // Calculate the distance between the current index and the previous occurrence.
                int currDistance = i - dict[pf[i]];
                ans = Math.Max(ans, currDistance);
            }
            else{
                // If not encountered before, add the current prefix sum and its index to the dictionary.
                dict.Add(pf[i], i);
            }
        }

        // If no subarray with sum zero is found, return 0.
        if(ans == int.MinValue){
            return 0;
        }

        // Return the maximum subarray length with sum zero.
        return ans;
    }

    public List<long> PrefixSum(List<int> A){
        int n = A.Count;
        List<long> pf = new List<long>();
        pf.Add(A[0]);
        for(int i=1; i<n; i++){
            pf.Add(pf[i-1] + A[i]);
        }
        return pf;
    }
}
