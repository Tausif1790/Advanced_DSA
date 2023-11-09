Given an integer array A of N integers, find the pair of integers in the array which have minimum XOR value. Report the minimum XOR value.

Input 1: A = [0, 2, 5, 7]
Input 2: A = [0, 4, 7, 9]

Output 1: 2
Output 2: 3

Explanation 1: 0 xor 2 = 2

//---------------------//Time complexity: O(N * logN)--------------------------------//
class Solution {
    public int findMinXor(List<int> A) {
        int n = A.Count;
        A.Sort();
        int minXor = A[0] ^ A[1];

        // Iterate through the sorted array to find the minimum XOR.
        // The idea is that if we sort the elements, the minimum XOR value is likely to occur between adjacent elements.
        for(int i=2; i<n; i++){
            int xor = A[i-1] ^ A[i];

            if(xor < minXor){
                minXor = xor;
            }
        }
        return minXor;


        // Brute force //TC: O(n^2)

        // int n = A.Count;
        // int ans = int.MaxValue;
        // for(int i=0; i<n-1; i++){
        //     for(int j=i+1; j<n; j++){
        //         int temp = A[i] ^ A[j];
        //         ans = Math.Min(ans, temp);
        //     }
        // }

        // return ans;
    }
}

/*
The first step is to sort the array. The answer will be the minimum value of X[i] XOR X[i+1] for every i.

Proof:
Let’s suppose that the answer is not X[i] XOR X[i+1], but A XOR B and there exists C in the array such as A <= C <= B.

Next is the proof that either A XOR C or C XOR B is smaller than A XOR B.

Let A[i] = 0/1 be the i-th bit in the binary representation of A
Let B[i] = 0/1 be the i-th bit in the binary representation of B
Let C[i] = 0/1 be the i-th bit in the binary representation of C

This is with the assumption that all of A, B and C are padded with 0 on the left until they all have the same length

Example: A = 169, B = 187, C = 185

A = 101010012
B = 101110112
C = 101110012

Let i be the leftmost (biggest) index such that A[i] differs from B[i]. There are 2 cases now:
1) C[i] = A[i] = 0,
then (A XOR C)[i] = 0 and (A XOR B)[i] = 1
This implies (A XOR C) < (A XOR B)
2) C[i] = B[i] = 1,
then (B XOR C)[i] = 0 and (A XOR B)[i] = 1
This implies (B XOR C) < (A XOR B)

Time complexity: O(N * logN) to sort the array and O(N) to find the smallest XOR
Space complexity: O(N)
*/