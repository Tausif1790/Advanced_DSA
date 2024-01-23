Given an array of integers A and an integer B.
Find the total number of subarrays having sum equals to B.
Input 1:
A = [1, 0, 1]
B = 1
Input 2:
A = [0, 0, 0]
B = 0
Output 1: 4
Output 2: 6

//----------------------------// O(n),O(n) //---------------//
class Solution {
    public int solve(List<int> A, int B) {
        int n = A.Count;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int count = 0;
        int prefixSum = 0;

        for (int i = 0; i < n; i++) {
            prefixSum += A[i];

            // Check if the current prefix sum equals the target B
            if (prefixSum == B) {
                count++;
            }

            // Check if there is a previous prefix sum that makes the current prefix sum - B equal to B
            int target = prefixSum - B;
            if (dict.ContainsKey(target)) {
                count += dict[target];
            }

            // Update the dictionary with the current prefix sum
            if (dict.ContainsKey(prefixSum)) {
                dict[prefixSum]++;
            } else {
                dict.Add(prefixSum, 1);
            }
        }

        return count;
    }
}

