Given an Array of integers B, and a target sum A.
Check if there exists a pair (i,j) such that Bi + Bj = A and i!=j.

Input 1:
A = 8   
B = [3, 5, 1, 2, 1, 2]

Input 2:
A = 21   
B = [9, 10, 7, 10, 9, 1, 5, 1, 5]

Output 1: 1
Output 2: 0

//-------------------------------------------------------------//
// Target -> required el at B[i], which sum with current el(B[i]) = A (required sum)
// A[i] + A[j] = B
// (Target) A[j] = B - A[i]

class Solution {
    public int solve(int A, List<int> B) {
        int n = B.Count;
        HashSet<int> sett = new HashSet<int>();

        for(int i=0; i<n; i++){
            int target = A - B[i];

            if(sett.Contains(target)){
                return 1;
            }
            sett.Add(B[i]);
        }

        return 0;
    }
}

//TC: O(n)
//SC: O(n)