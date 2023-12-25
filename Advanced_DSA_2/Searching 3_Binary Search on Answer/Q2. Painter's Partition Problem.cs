Problem Description
Given 2 integers A and B and an array of integers C of size N. Element C[i] represents the length of ith board.
You have to paint all N boards [C0, C1, C2, C3 … CN-1]. There are A painters available and each of them takes B units of time to paint 1 unit of the board.
Calculate and return the minimum time required to paint all boards under the constraints that any painter will only paint contiguous sections of the board.
NOT
1. 2 painters cannot share a board to paint. That is to say, a board cannot be painted partially by one painter, and partially by another.
2. A painter will only paint contiguous boards. This means a configuration where painter 1 paints boards 1 and 3 but not 2 is invalid.
Return the ans % 10000003.

Input 1:
 A = 2
 B = 5
 C = [1, 10]
Input 2:
 A = 10
 B = 1
 C = [1, 8, 11, 3]

Output 1: 50
Output 2: 11

//---------------------------// O(nlogn) //---------------------------------//
class Solution {
    long mod = 10000003;

    // Function to calculate the minimum time required to paint all boards
    public int paint(int A, int B, List<int> C) {
        long n = C.Count;

        // A => Number of painters
        // B => Time taken by one painter to paint 1 unit of the board

        long ans = 0;
        long start = Max(C);        // Function to find the maximum value in the array
        long end = Sum(C);          // Function to find the sum of all elements in the array

        // Binary search to find the minimum time required
        while (start <= end) {
            long midTimeReq = (start + end) / 2;

            // Check if it's possible to paint all boards within midTimeReq time
            if (IsPossible(C, A, midTimeReq)) {
                ans = (midTimeReq * B) % mod;     // Calculate the total time required
                end = midTimeReq - 1;
            } else {
                start = midTimeReq + 1;
            }
        }

        return (int)(ans % mod);
    }

    // Function to check if it is possible to paint all boards within the given time
    public bool IsPossible(List<int> C, long A, long mid) {
        long sum = 0;
        long painters = 1;

        foreach (long el in C) {
            sum = sum + el;
            if (sum > mid) {
                painters++;
                sum = el;
            }
        }

        // Check if the number of painters used is less than or equal to the available painters
        if (painters <= A) {
            return true;
        }
        return false;
    }

    // Function to find the maximum value in the array
    public long Max(List<int> C) {
        long ans = long.MinValue;
        foreach (long el in C) {
            if (ans < el) {
                ans = el;
            }
        }

        return ans;
    }

    // Function to find the sum of all elements in the array
    public long Sum(List<int> C) {
        long ans = 0;
        foreach (long el in C) {
            ans = ans + el;
        }

        return ans;
    }
}

/*
Certainly! The line ans = (midTimeReq * B) % mod;
 calculates the total time required to paint all boards by a single painter
  within a certain time limit (midTimeReq).
 It takes into account that each painter needs B units of time to paint 1 unit of the board.
  The result is then taken modulo mod to keep it within the specified range.
   The variable ans holds this total time, and it is used in the binary search
    to find the minimum time required to paint all boards with the given number of painters.
*/