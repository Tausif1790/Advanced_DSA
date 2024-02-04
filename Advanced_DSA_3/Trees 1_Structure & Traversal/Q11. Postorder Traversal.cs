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

 [3, 2, 1]
Output 2:

 [6, 3, 2, 1]

//------------------------------------------------------//
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
    public List<int> postorderTraversal(TreeNode A) {
        //-----------// //-------------------//
        // if(A == null){
        //     return ans;
        // }
        // postorderTraversal(A.left);
        // postorderTraversal(A.right);
        // ans.Add(A.val);
        // return ans;
        //---------------------------------------//
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode current = A;
        TreeNode lastVisited = null;

        while (current != null || stack.Count != 0) {
            if (current != null) {
                stack.Push(current);
                current = current.left;          // Move to the left child
            } else {
                TreeNode peekNode = stack.Peek();
                if (peekNode.right == null || peekNode.right == lastVisited) {
                    ans.Add(peekNode.val);         // Process the node in postorder fashion
                    lastVisited = stack.Pop();       // Mark the node as visited     
                } else {
                    current = peekNode.right;        // Move to the right child
                }
            }
        }
        return ans;
    }
}
