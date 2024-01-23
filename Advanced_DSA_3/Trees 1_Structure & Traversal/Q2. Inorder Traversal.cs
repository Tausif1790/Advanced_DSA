Given a binary tree, return the inorder traversal of its nodes' values.
   1
  / \
 6   2
    /
   3
Output 2: [6, 1, 3, 2]

//--------------------// O(n), O(stack height) //----------------------//
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
    public List<int> inorderTraversal(TreeNode A) {
        if(A == null){
            return ans;
        }
        inorderTraversal(A.left);
        ans.Add(A.val);
        inorderTraversal(A.right);
        return ans;
    }
}

class Solution {
    public List<int> inorderTraversal(TreeNode A) {
        List<int> result = new List<int>();                   // List to store the inorder traversal result
        Stack<TreeNode> stack = new Stack<TreeNode>();        // Stack to simulate the recursive call stack

        TreeNode current = A;                                 // Start with the root node

        // Continue traversal until the current node is null and the stack is empty
        while (current != null || stack.Count != 0) {     
            if (current != null) {              // If the current node is not null, push it onto the stack and move to its left child (left subtree)
                stack.Push(current);
                current = current.left;         // Traverse to the left
            } 
            else {                              // If the current node is null, pop a node from the stack, process it, and move to its right child (right subtree)
                current = stack.Pop();
                result.Add(current.val);        // Process the node
                current = current.right;        // Traverse to the right
            }
        }
        return result;  // Return the inorder traversal result
    }
}
