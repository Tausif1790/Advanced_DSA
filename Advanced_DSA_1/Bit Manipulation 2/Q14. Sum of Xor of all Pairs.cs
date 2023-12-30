Given an array A of N integers. Find the sum of bitwise XOR all pairs of numbers in the array.
Since the answer can be large, return the remainder after the dividing the answer by 109+7.

A = [1, 2, 3]
A = [3, 4, 2]

Output 1: 6
Output 2: 14
//--------------------------------------------------------------------//
// class Solution {
//     public int solve(List<int> A) {
//         int n = A.Count;
//         int mod = (int)Math.Pow(10, 9) + 7;

//         long ans = 0;

//         for(int i = 0; i<n; i++){
//             for(int j = i+1; j<n; j++){
//                 ans += (A[i] ^ A[j]) % mod;
//             }
//         }

//         return (int)(ans % mod);
//     }
// }

class Solution {
    public int solve(List<int> A) {
        long mod = (long)Math.Pow(10, 9) + 7;
        int n = A.Count;
        long finalAns = 0;

        for(int i=0; i<32; i++){
            long ones = 0;
            long zeros = 0;

            foreach(int el in A){
                // Find the number of set bits and the unset bits at the specific index.
                if((el & 1<<i) != 0){
                    ones++;
                }else{
                    zeros++;
                }
            }

            // The number of pairs of the digits which can make the final bit as 1 is the product of the
            // the number of 0s and the 1s at the specific index. Because in XOR both bits have to be different
            // for the bit to be set.
            long pairs = (ones * zeros) % mod;
            finalAns += (pairs % mod * (long)Math.Pow(2, i)%mod) % mod;
        }

        return (int)(finalAns % mod);
    }
}



// For every bit, we can find the number of elements in the array 
// with that bit set and the number of elements with that bit unset.

// Let the number of elements with i-th bit set and unset be 
// X and Y respectively.

// Now the number of xor pairs with the i-th bit set is X*Y. 
// So the total contribution by the i-th bit to the sum of xor
// of all pairs will be (X * Y) * (1 << i).


// Time Complexity : O(N*logX)
// Space Complexity : O(1)

// where X is maximum value from A

//-----------------------------------------------------------------------//
// Initial List: [3, 4, 2]

// Initialize variables
// mod = 1000000007
// n = 3
// finalAns = 0

// Loop over each bit position (0 to 31)
// Bit position 0:
//   ones = 1 (binary: 010, elements: 2)
//   zeros = 2 (binary: 101, elements: 3, 4)
//   pairs = 1 * 2 = 2
//   finalAns += 2 * 2^0 = 2
// Bit position 1:
//   ones = 2 (binary: 110, elements: 3, 4)
//   zeros = 1 (binary: 001, elements: 2)
//   pairs = 2 * 1 = 2
//   finalAns += 2 * 2^1 = 6
// Bit position 2:
//   ones = 2 (binary: 011, elements: 3, 2)
//   zeros = 1 (binary: 100, elements: 4)
//   pairs = 2 * 1 = 2
//   finalAns += 2 * 2^2 = 14

// After the loop, finalAns % mod = 14 % 1000000007 = 14

// Final Result: 14
