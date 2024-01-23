Problem Description
Given an array A of N integers.
Find the count of the subarrays in the array which sums to zero.
 Since the answer can be very large, return the remainder on dividing the result with 109+7

Input 1: A = [1, -1, -2, 2]
Input 2: A = [-1, 2, -1]
Output 1: 3
Output 2: 1

//------------------------// O(n),O(n) ----------------------------------//

class Solution {
    long mod = (long)Math.Pow(10, 9) + 7;
    public int solve(List<int> A) {
        long count = 0;
        Dictionary<long, long> dict = new Dictionary<long, long>();
        List<long> pf = PrefixSum(A);
        
        foreach(long el in pf){
            if(el == 0){
                count++;                 // Increment count for zero prefix sum
            }

            if(dict.ContainsKey(el)){
                count += dict[el];       // Increment count by the frequency of the current prefix sum (like Count AG pair sum)
                long freq = dict[el];
                dict[el] = freq + 1;         // Update the frequency of the current prefix sum
            } else {
                dict.Add(el, 1);             // Add the current prefix sum to the dictionary
            }
        }

        return (int)(count % mod);
    }

    public List<long> PrefixSum(List<int> A) {
        int n = A.Count;
        List<long> pf = new List<long>();
        pf.Add(A[0]);

        for(int i = 1; i < n; i++) {
            pf.Add(pf[i - 1] + A[i]);
        }
        return pf;
    }
}

//------------------------// O(n),O(n) ----------------------------------//
class Solution {
    public int solve(List<int> A) {
        long mod = (long)Math.Pow(10, 9) + 7;
        long count = 0;
        Dictionary<long, long> dict = new Dictionary<long, long>();
        List<long> pf = PrefixSum(A);
        
        // Count occurrences and calculate prefix sum
        foreach(long el in pf){
            if(el == 0){
               count++;                     // Increment count for prefix sum equal to 0
            }

            if(dict.ContainsKey(el)){
                long freq = dict[el];
                dict[el] = freq + 1;
            } else {
                dict.Add(el, 1);          // Add prefix sum el to dictionary
            }
        }

        // Calculate combinations for repeated prefix sums
        foreach(long el in dict.Keys){
            if(dict[el] > 1){
                //long temp = CalculateFactorial(dict[el])/(CalculateFactorial(2) * (CalculateFactorial(dict[el]) - 2));
                long temp = CalculateCombination(dict[el], 2);
                count = (count % mod + temp % mod) % mod;
            }
        }

        return (int)(count % mod);
    }

    // Calculate the prefix sum of the given list
    public List<long> PrefixSum(List<int> A){
        int n = A.Count;
        List<long> pf = new List<long>();
        pf.Add(A[0]);

        for(int i=1; i<n; i++){
            pf.Add(pf[i-1] + A[i]);  // Compute prefix sum
        }

        return pf;
    }

    // Calculate combination (n choose r)
    static long CalculateCombination(long n, long r) {
        long result = 1;

        // Changed loop range to 'n-r+1' to 'n'
        for(long i = n - r + 1; i <= n; i++) {
            result *= i;
        }

        // Divided by factorial of 'r'
        for(long i = 1; i <= r; i++) {
            result /= i;
        }

        return result;
    }
}


//-------------------------------------------------//
// Calculate the numerator part: n * (n-1) * ... * (n-r+1)
for (long i = n - r + 1; i <= n; i++) {
    result *= i;
}
