Given an array A. For every pair of indices i and j (i != j), find the maximum A[i] & A[j].

Input 1:- A = [53, 39, 88]
Input 2:- A = [38, 44, 84, 12] 

Output 1:- 37
Output 2:- 36

//---------------------------------------------------//
class Solution {
    public int solve(List<int> A) {
        int n = A.Count;
        int ans = 0;

        // 
        for(int i=31; i>=0; i--){
            int count = 0;

            // Count the number of elements with the i-th bit set.
            foreach(int el in A){
                if((el & 1<<i) != 0){
                    count++;
                }
            }

            // If there are at least 2 elements with the i-th bit set, update the answer.
            if(count >= 2){
                ans = ans + (int)Math.Pow(2, i);       // or ans += (1 << i);

                // ignorance part if count >= 2     // Ignore elements without the i-th bit set when updating A.
                for(int j=0; j<n; j++){
                    if((A[j] & 1<<i) == 0){
                        A[j] = 0;
                    }
                }
            }
        }

        return ans;
    }
}
