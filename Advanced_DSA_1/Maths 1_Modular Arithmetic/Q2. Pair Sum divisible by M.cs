Given an array of integers A and an integer B, find and return the number of pairs in A whose sum is divisible by B.
Since the answer may be large, return the answer modulo (109 + 7).
Note: Ensure to handle integer overflow when performing the calculations.

Input 1:
 A = [1, 2, 3, 4, 5]
 B = 2
Input 2:
 A = [5, 17, 100, 11]
 B = 28

 Problem Constraints
1 <= length of the array <= 100000
1 <= A[i] <= 109
1 <= B <= 106

//-----------------------------------------------------------------------///
class Solution {
    public int solve(List<int> A, int B) {
        int mod = (int)Math.Pow(10, 9) + 7;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach(int el in A){
            int rem = el % B;

            if(dict.ContainsKey(rem)){
                int freq = dict[rem];
                dict[rem] = freq + 1;
            }
            else{
                dict.Add(rem, 1);
            }
        }

        // if rem = 0, handle it alone
        long freq0 = dict.ContainsKey(0) ? dict[0] : 0;
        long ans = ((freq0 * ( freq0 - 1))/2)%mod ;             // Modulo ensures the result is within the specified range

        int l = 1;
        int r = B-1;
        while(l<r){
            long freql = dict.ContainsKey(l) ? dict[l] : 0;
            long freqr = dict.ContainsKey(r) ? dict[r] : 0;

            ans = (ans + (freql * freqr)%mod)%mod;        // Modulo ensures the result is within the specified range
            
            l++;
            r--;
        }

        // Handle the case where l and r are equal (duplicate remainder)
        if(l == r){
        long freql = dict.ContainsKey(l) ? dict[l] : 0;
        ans = (ans + (freql * ( freql - 1))/2)%mod ;          // Modulo ensures the result is within the specified range
        }

        return (int)ans;
    }
}


// worst case
// rem = B = 10^6
// n = 10^5

