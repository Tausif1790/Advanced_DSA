Given preorder traversal of a binary tree, check if it is possible that it is also a preorder traversal of a Binary Search Tree (BST), where each internal node (non-leaf nodes) have exactly one child.
Input 1: A : [4, 10, 5, 8]
Input 2: A : [1, 5, 6, 4]

Output 1: "YES"
Output 2: "NO"

Explanation 1:
 The possible BST is:
            4
             \
             10
             /
             5
              \
              8
//----------------------------------------//
class Solution {
    public string solve(List<int> A) {
        int n = A.Count;
        int first = A[0];
        int min = int.MinValue;
        int max = int.MaxValue;

        for(int i=1; i<n; i++){
            if(A[i] > A[i-1]){
                min = A[i-1] + 1; // Update the minimum allowed value if the current element is greater than the previous one.
            }
            else{
                max = A[i-1] - 1; // Update the maximum allowed value if the current element is less than the previous one.
            }

            if(A[i] < min || A[i] > max){
                return "NO"; // If the current element is outside the allowed range, return "NO".
            }
        }
        return "YES"; // If all elements are within the allowed range, return "YES".
    }
}
