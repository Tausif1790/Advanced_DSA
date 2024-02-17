Input:
        1
       /  \
      2    5
     / \  / \
    3  4  6  7
Output:
         1 -> NULL
       /  \
      2 -> 5 -> NULL
     / \  / \
    3->4->6->7 -> NULL

//------------------// TC:O(n), SC:(1) //------------------------//
using System.Collections.Generic;
using System;

/**
 * Definition for binary tree
 * class TreeLinkNode {
 *     public int val;
 *     public TreeLinkNode left;
 *     public TreeLinkNode right, next;
 *     public TreeLinkNode(int x) {this.val = x; this.left = this.right = null; this.next = null;}
 * }
 */
class Solution {
    // Connects each node to its next right node in the same level
    public void connect(TreeLinkNode root) {
        if(root == null) return;

        // Traverse each level of the tree
        while(root != null){
            // Start from the leftmost node of the current level
            TreeLinkNode head = root;
            
            // Traverse each node in the current level
            while(head != null){
                // Connect the left child to the right child if both exist
                if(head.left != null){
                    if(head.right != null){
                        head.left.next = head.right;
                    }else{
                        // Connect the left child to the next node in the same level if the right child is null
                        head.left.next = getNextBelowNode(head);
                    }
                }

                // Connect the right child to the next node in the same level if it exists
                if(head.right != null){
                    head.right.next = getNextBelowNode(head);
                }

                // Move to the next node in the current level
                head = head.next;
            }

            // Move to the next level
            if(root.left != null){
                root = root.left;
            }
            else if(root.right != null){
                root = root.right;
            }
            else{
                // If both left and right children are null, move to the next node in the same level
                root = getNextBelowNode(root);
            }
        }
    }

    // Returns the next non-null node in the same level
    public TreeLinkNode getNextBelowNode(TreeLinkNode root){
        TreeLinkNode temp = root.next;
        while(temp != null){
            if(temp.left != null){              // Return the left child if it exists
                return temp.left;
            }
            if(temp.right != null){             // Return the right child if it exists
                return temp.right;
            }
            temp = temp.next;                   // Move to the next node in the same level
        }
        return null;
    }
}
