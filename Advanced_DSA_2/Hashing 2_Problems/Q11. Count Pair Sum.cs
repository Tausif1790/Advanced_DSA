You are given an array A of N integers and an integer B. Count the number of pairs (i,j) such that A[i] + A[j] = B and i ≠ j.
Since the answer can be very large, return the remainder after dividing the count with 109+7.
Note - The pair (i,j) is same as the pair (j,i) and we need to count it only once.
Input 1:
A = [3, 5, 1, 2]
B = 8
Input 2:
A = [1, 2, 1, 2]
B = 3

Output 1: 1
Output 2: 4

//--------------------------------------------------------------------//
// Target -> required el at A[i], which sum with current el(A[i]) = B (required sum)
// A[i] + A[j] = B
// (Target) A[j] = B - A[i]

class Solution {
    public int solve(List<int> A, int B) {
        int mod = (int)Math.Pow(10, 9) + 7;
        int n = A.Count;
        int count = 0;
        Dictionary<int, int> dict = new Dictionary<int, int>();

        for(int i=0; i<n; i++){
            // Calculate the target value needed for the sum to be B
            int target = B - A[i];
            // If the target value is in the dictionary, add its frequency to the count
            if(dict.ContainsKey(target)){
                count = count + dict[target];
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
