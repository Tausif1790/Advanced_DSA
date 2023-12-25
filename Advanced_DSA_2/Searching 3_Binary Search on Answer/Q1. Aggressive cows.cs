Farmer John has built a new long barn with N stalls.
 Given an array of integers A of size N where each element of the array
  represents the location of the stall and an integer B which represents the number of cows.

His cows don't like this barn layout and become aggressive towards each other once put into a stall.
 To prevent the cows from hurting each other, John wants to assign the cows to the stalls,
  such that the minimum distance between any two of them is as large as possible.
   What is the largest minimum distance?

Input 1:
A = [1, 2, 3, 4, 5]
B = 3
Input 2:
A = [1, 2]
B = 2

Output 1: 2
Output 2: 1

//--------------------------// O(nlogn) //-------------------------------//
class Solution {
    public int solve(List<int> A, int B) {
        // B => number of cows
        A.Sort();
        int ans = 0;
        int n = A.Count;
        
        // Initial range for binary search
        int start = minAdjacentDistance(A);  // Minimum distance between adjacent stalls
        int end = A[n - 1] - A[0];           // Maximum possible distance between stalls
        
        while (start <= end) {
            int midDistance = (start + end) / 2;  // At least this distance between two cows
            if (checkAreAllCowsPlacedForDistance(A, B, midDistance)) {
                ans = midDistance;  // Potential answer
                start = midDistance + 1;
            } else {
                end = midDistance - 1;
            }
        }

        return ans;
    }

    // Checks if all cows can be placed with at least the given distance between them
    public bool checkAreAllCowsPlacedForDistance(List<int> A, int cows, int mid) {
        int n = A.Count;
        int currCows = 1;  // Number of cows placed with at least mid distance
        int last = 0;

        for (int i = 0; i < n; i++) {
            if (A[i] - A[last] >= mid) {
                last = i;
                currCows++;
            }
            if (currCows >= cows) {
                return true;
            }
        }

        return false;
    }

    // Finds the minimum distance between adjacent stalls
    int minAdjacentDistance(List<int> A) {
        int ans = int.MaxValue;

        for (int i = 0; i < A.Count - 1; i++) {
            ans = Math.Min(ans, A[i + 1] - A[i]);
        }

        return ans;
    }

    /*  // previous incorrect method
     int minAdjacentDistance(List<int> A){
        int ans = 0;

        for(int i=0; i<A.Count - 1; i++){
            ans = Math.Max(ans, A[i+1] - A[i]);
        }

        return ans;
    }
    */
}
