Given an array of integers A, find and return whether the given array contains a non-empty subarray with a sum equal to 0.
If the given array contains a sub-array with sum zero return 1, else return 0.

Input 1: A = [1, 2, 3, 4, 5]
Input 2: A = [4, -1, 1]
Output 1: 0
Output 2: 1

//---------------------// O(n), O(n) --------------------------------//
class Solution {
    public int solve(List<int> A) {
        int n = A.Count;
        HashSet<long> sett = new HashSet<long>();
        List<long> pf = PrefixSum(A);
        
        foreach(long el in pf){
            if(el == 0){
                return 1;
            }
            if(!sett.Contains(el)){
                sett.Add(el);
            }  
        }

        if(n != sett.Count){
            return 1;
        }   
        return 0;
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
