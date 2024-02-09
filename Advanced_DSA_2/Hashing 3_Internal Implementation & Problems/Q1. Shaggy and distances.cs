Problem Description
Shaggy has an array A consisting of N elements. We call a pair of distinct indices in that array a special if elements at those indices in the array are equal.
Shaggy wants you to find a special pair such that the distance between that pair is minimum.
 Distance between two indices is defined as |i-j|. If there is no special pair in the array, then return -1.

 Input 1: A = [7, 1, 3, 4, 1, 7]
Input 2: A = [1, 1]

Output 1: 3
Output 2: 1

Explanation 1:
Here we have 2 options:
1. A[1] and A[4] are both 1 so (1,4) is a special pair and |1-4|=3.
2. A[0] and A[5] are both 7 so (0,5) is a special pair and |0-5|=5.
Therefore the minimum possible distance is 3. 

//---------------------------------------//
class Solution {
    public int solve(List<int> A) {
        int n = A.Count();
        int ans = int.MaxValue;
        Dictionary<int, int> dict = new Dictionary<int, int>();         // key => el, val => idx

        for(int i=0; i<n; i++){
            if(dict.ContainsKey(A[i])){
                // Calculate the distance between current index and the previous index of the same element
                int distance = Math.Abs(i - dict[A[i]]);
                ans = Math.Min(ans, distance);

                dict[A[i]] = i;             // Update the index of the last occurrence of the element
            }
            else{
                dict.Add(A[i], i);          // Add the element to the dictionary with its current index
            }
        }

        if(dict.Count != n){            // If there are duplicate elements in the list, return the minimum distance
            return ans;
        }
        
        return -1;                      // If all elements are distinct, return -1
    }
}
