Given an array of integers A and an integer B, find and return the minimum
 number of swaps required to bring all the numbers less than or equal to B together.
Note: It is possible to swap any two elements, not necessarily consecutive.

Input 1:
 A = [1, 12, 10, 3, 14, 10, 5]
 B = 8
Input 2:
 A = [5, 17, 100, 11]
 B = 20

Output 1: 2
Output 2: 1

//-----------------------// TC: O(n), SC:O(1) //----------------------//
class Solution {
    public int solve(List<int> A, int B) {
        int n = A.Count;
        int count = 0;                   // Count of elements less than or equal to B
        int ans = 0;                     // Result variable to store the minimum number of swaps

        // Count the number of elements less than or equal to B
        foreach(int el in A){
            if(el <= B){
                count++;
            }
        }

        if(count <= 1){
            return 0;            // If there's at most one element less than or equal to B, no swaps are needed
        }

        int l = 0;
        int r = 0;
        int x = 0;               // Number of "bad" elements (elements greater than B) in the current window

        // Initialize the first window from 0 to count
        while(r < count){
            if(A[r] > B){
                x++;             // Increase the count of bad elements
            }
            r++;                 // Move to the next element in the window
        }
        ans = x;                 // The initial count of bad elements represents the number of swaps required

        // Slide the window through the array
        while(r < n){
            if(A[r] > B){
                x++;             // Increase the count of bad elements
            }
            if(A[l] > B){
                x--;             // Decrease the count of bad elements as the window moves forward
            }

            ans = Math.Min(ans, x);          // Update the result with the minimum number of swaps needed
            r++;                             // Move the right pointer of the window
            l++;                             // Move the left pointer of the window
        }
        return ans;                          // Return the minimum number of swaps required
    }
}

