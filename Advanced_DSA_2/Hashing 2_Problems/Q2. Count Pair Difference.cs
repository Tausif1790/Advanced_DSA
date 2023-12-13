You are given an array A of N integers and an integer B.
Count the number of pairs (i,j) such that A[i] - A[j] = B and i ≠ j.
Since the answer can be very large, return the remainder after dividing the count with 109+7.

Input 1:
A = [3, 5, 1, 2]
B = 4
Input 2:
A = [1, 2, 1, 2]
B = 1

Output 1: 1
Output 2: 4

//---------------------------------------------------------------------//
class Solution {
    public int solve(List<int> A, int B) {
        int mod = (int)Math.Pow(10, 9) + 7;
        int n = A.Count;
        int count = 0;
        Dictionary<int, int> dict = new Dictionary<int, int>();

        for(int i=0; i<n; i++){
            // Calculate target values for pairs (i, j)
            int target = A[i] + B;
            int target2 = A[i] - B;

            // If the target value is in the dictionary, add its frequency to the count
            if(dict.ContainsKey(target)){
                count = count + dict[target];
            }
            if(dict.ContainsKey(target2)){
                count = count + dict[target2];
            }

            if(dict.ContainsKey(A[i])){
                int freq = dict[A[i]];
                dict[A[i]] = freq + 1;
            }
            else{
                dict.Add(A[i], 1);
            }
        }
        return count % mod;
    }
}
//TC: O(n)
//SC: O(n)