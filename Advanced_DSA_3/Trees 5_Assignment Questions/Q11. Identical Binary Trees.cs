Input 1:
   1       1
  / \     / \
 2   3   2   3
Input 2:
   1       1
  / \     / \
 2   3   3   3
Example Output
Output 1: 1
Output 2: 0


class Solution {
    public int isSameTree(TreeNode A, TreeNode B) {
        bool check = inorderAB(A, B);
        return check ? 1 : 0;
    }

    bool inorderAB(TreeNode A, TreeNode B){
        if(A == null && B == null) return true;
        if(A == null && B != null) return false;
        if(A != null && B == null) return false;
        if(A.val != B.val) return false;

        bool left = inorderAB(A.left, B.left);
        if(!left) return false; 

        bool right = inorderAB(A.right, B.right);
        if(!right) return false; 

        return true;
    }
}
