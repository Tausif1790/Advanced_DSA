Input :
     1
   /   \
  2     3
 / \   / \
4   5 6   7

Output:

 
     1
   /   \
  3     2
 / \   / \
7   6 5   4

//-----------------------------------------------------//
class Solution {
    public TreeNode invertTree(TreeNode A) {
        if(A == null){
            return null;
        }

        // Recursively invert the left subtree
        A.left = invertTree(A.left);
        // Recursively invert the right subtree
        A.right = invertTree(A.right);

        // Swap the left and right children of the current node
        TreeNode temp = A.left;
        A.left = A.right;
        A.right = temp;

        // Return the root of the inverted tree
        return A;
    }
}
