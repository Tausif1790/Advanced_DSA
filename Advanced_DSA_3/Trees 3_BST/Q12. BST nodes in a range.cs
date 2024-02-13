Input 1:
            15
          /    \
        12      20
        / \    /  \
       10  14  16  27
      /
     8
     B = 12
     C = 20
Input 2:
            8
           / \
          6  21
         / \
        1   7

     B = 2
     C = 20
//-------------------------------------------//
class Solution {
    public int solve(TreeNode A, int B, int C) {
        if(A == null){
            return 0;                        // If the current node is null, return 0.
        }

        int left = solve(A.left, B, C);      // Recursively calculate the count in the left subtree.

        int right = solve(A.right, B, C);    // Recursively calculate the count in the right subtree.

        if(B <= A.val && A.val <= C){
            return (left + right + 1);       // If the current node value is within the range [B, C], include it in the count.
        }
        return (left + right);               // Otherwise, exclude the current node from the count.
    }
}