         1
       /   \
      2     3
     / \   / \
    4   5 6   7
   / \     \
  8   9    10
output:
[
  [1],
  [3, 2],
  [4, 5, 6, 7],
  [10, 9, 8]
]
//----------------// O(N),O(N) //------------------------//
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
    public List<List<int>> zigzagLevelOrder(TreeNode A) {
        List<List<int>> result = new List<List<int>>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        if(A == null) return result;

        q.Enqueue(A);
        int level = 0;
        while(q.Count != 0){
            int size = q.Count;
            List<int> levelArray = new List<int>();
            for(int i=1; i<=size; i++){
                TreeNode currNode = q.Dequeue();

                levelArray.Add(currNode.val);

                // Enqueue left child if exists
                if(currNode.left != null) q.Enqueue(currNode.left);
                
                // Enqueue right child if exists
                if(currNode.right != null) q.Enqueue(currNode.right);
            }
            
            // Reverse the list for odd levels (zigzag pattern)
            if(level % 2 != 0){
                levelArray.Reverse();
            }
            
            // Add the level array to the result
            result.Add(levelArray);
            level++;
        }
        return result;
    }
}
