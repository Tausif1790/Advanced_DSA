Given an array of positive integers A of size N, return the sum of all possible subarrays of A of length equal to maximum value of x such that x*x <= N.
Note: - a subarray is a contiguous subsequence of the array.

//---------------------------------------------//
class Solution {
    public long solve(List<int> A) {
        int wind = squareRoot(A.Count);
        List<int> pf = prefixSum(A);
        
        // first window sum
        long ansSum = pf[wind - 1];
        
        int l = 1;
        int r = l + wind - 1;
        while(r < A.Count){
            ansSum += pf[r] - pf[l-1];
            
            l++;
            r++;
        }
        
        return ansSum;
    }
    
    public int squareRoot(int A){
        int ans = 0;
        for(int i=1; i*i <= A; i++){
            ans = i;
        }
        return ans;
    }
    
    public List<int> prefixSum(List<int> A){
        List<int> pf = new List<int>();
        pf.Add(A[0]);
        
        for(int i=1; i<A.Count; i++){
            pf.Add(pf[i-1] + A[i]);
        }
        return pf;
    }
}
