Input 1:

   1
    \
     2
    /
   3
Input 2:

   1
  / \
 6   2
    /
   3


Example Output
Output 1:

 [1, 2, 3]
Output 2:

 [1, 6, 2, 3]
 //----------------------------------------------//
 /**
 * Definition for binary tree
 * class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) {this.val = x; this.left = this.right = null;}
 * }
 */
class Solution {
    List<int> ans = new List<int>();
    public List<int> preorderTraversal(TreeNode A) {
        //------------// recursion //----------------//
        if(A == null){
            return ans;
        }
        ans.Add(A.val);
        preorderTraversal(A.left);
        preorderTraversal(A.right);
        return ans;
        //----------------------------//
        List<int> result = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();

        TreeNode current = A;

        while (current != null || stack.Count != 0) {
            if (current != null) {
                result.Add(current.val);   // Process the node in the preorder fashion
                stack.Push(current.right); // Push the right child onto the stack
                current = current.left;     // Move to the left child
            } else {
                current = stack.Pop();     // Pop the right child from the stack
            }
        }
        return result;
    }
}
