Problem Description
Given a vector A of non-negative integers representing an elevation map where
 the width of each bar is 1, compute how much water it is able to trap after raining.

Input 1: A = [0, 1, 0, 2]
Output 1: 1

//--------------------------Optimise------------------------------------//
class Solution {
    public int trap(List<int> A) {
        int n = A.Count;
        int ans = 0;
        List<int> pf = prefixLeftMax(A);
        List<int> sf = suffixRightMax(A);

        for(int i=1; i<n-1; i++){
            int watrT = Math.Min(pf[i], sf[i]) - A[i];

            if(watrT > 0){
                ans = ans + watrT;
            }
        }
        return ans;
    }

    List<int> prefixLeftMax(List<int> A){
        List<int> pf = new List<int>(new int[A.Count]);
        pf[0] = 0;
        for(int i=1; i<A.Count; i++){
            pf[i] = Math.Max(pf[i-1], A[i-1]);
        }
        return pf; 
    }

    List<int> suffixRightMax(List<int> A){
        List<int> sf = new List<int>(new int[A.Count]);
        int n = sf.Count;
        sf[n-1] = 0;
        for(int i=n-2; i>=0; i--){
            sf[i] = Math.Max(sf[i+1], A[i+1]);
        }
        return sf; 
    }
}

// TC: O(n)
// SC: O(n)
//-------------------------------// same //---------------------------------------------------//

class Solution {
    public int trap(List<int> A) {
        int n = A.Count;
        int ans = 0;
        List<int> pLM = PrefixLeftMax(A);
        List<int> sRM = suffixRightMax(A);
        sRM.Reverse();

        for(int i=1; i<n-1; i++){
            int waterTrapped = Math.Min(pLM[i], sRM[i]) - A[i];
            
            if(waterTrapped > 0){
                ans = ans + waterTrapped;
            }
        }
        return ans;
    }

    // method to compute left maximums
    List<int> PrefixLeftMax(List<int> A){
        int n = A.Count;
        int max = 0;
        List<int> ans = new List<int>();
        ans.Add(0);
        for(int i=1; i<n; i++){
            int leftEl = A[i-1];
            max = Math.Max(leftEl, max);
            ans.Add(max);
        }
        return ans;
    }

    // method to compute right maximums (reversed)
    List<int> suffixRightMax(List<int> A){
        int n = A.Count;
        int max = 0;
        List<int> ans = new List<int>();
        ans.Add(0);
        for(int i=n-2; i>=0; i--){
            int rightEl = A[i+1];
            max = Math.Max(rightEl, max);
            ans.Add(max);
        }
        return ans;
    }
}
// TC: O(n)
// SC: O(n)

//--------------------------------------------------------------//
class Solution {
    // Brute force approach to calculate trapped water
    public int trap(List<int> A) {
        int n = A.Count;
        int ans = 0;

        for (int i = 0; i < n; i++) {           //--> O(n)
            int maxL = Max(A, 0, i - 1);        //--> O(n) // Find the max height to the left of the current position.
            int maxR = Max(A, i + 1, n - 1);    //--> O(n) // Find the max height to the right of the current position.
            int waterTrapped = 0;

            if (i != 0 && i != n - 1) {
                waterTrapped = Math.Min(maxL, maxR) - A[i];     // Calculate the water trapped at the current position.
            }

            if (waterTrapped > 0) {
                ans = ans + waterTrapped;   // Accumulate the trapped water if it's positive.
            }
        }

        return ans;    // Return the total trapped water.
    }

    // Helper method to find the maximum height in a range
    int Max(List<int> A, int s, int e) {
        int max = 0;

        if (e == -1 || s == A.Count) {
            return 0;
        }

        for (int i = s; i <= e; i++) {
            max = Math.Max(max, A[i]);  // Find the maximum height in the specified range.
        }

        return max;
    }
// TC: O(n^2)
// SC: O(1)
}

