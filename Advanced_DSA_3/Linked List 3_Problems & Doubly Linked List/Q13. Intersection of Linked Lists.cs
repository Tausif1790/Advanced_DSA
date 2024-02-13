Write a program to find the node at which the intersection of two singly linked lists, A and B, begins. For example, the following two linked lists:
A:          a1 → a2
                   ↘
                     c1 → c2 → c3
                   ↗
B:     b1 → b2 → b3
NOTE:
If the two linked lists have no intersection at all, return null.
The linked lists must retain their original structure after the function returns.
You may assume there are no cycles anywhere in the entire linked structure.
Your code should preferably run in O(n) time and use only O(1) memory.
The custom input to be given is different than the one explained in the examples. Please be careful.

Input 1:

 A = [1, 2, 3, 4, 5]
 B = [6, 3, 4, 5]
Input 2:

 A = [1, 2, 3]
 B = [4, 5]
 //----------------------------------------------------//
 /**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
 using System.Collections.Generic;

 class Solution {
    public ListNode getIntersectionNode(ListNode A, ListNode B) {
        if (A == null || B == null) {
            return null;
        }

        // value can be repeated so storing node
        HashSet<ListNode> visitedNodes = new HashSet<ListNode>();

        // Traverse the first list and add each node to the set
        ListNode currA = A;
        while (currA != null) {
            visitedNodes.Add(currA);
            currA = currA.next;
        }

        // Traverse the second list and check if any node is already in the set
        ListNode currB = B;
        while (currB != null) {
            if (visitedNodes.Contains(currB)) {
                return currB; // Found the intersection node
            }
            currB = currB.next;
        }

        return null; // No intersection found
    }
}
 //---------------------// Brute force //---------------------------//
// class Solution {
//     public ListNode getIntersectionNode(ListNode A, ListNode B) {
//         if(A == null || B == null){
//             return null;
//         }

//         ListNode curr1 = A;
//         ListNode curr2 = B;

//         while(curr1 != null){
//             curr2 = B;
//             while(curr2 != null){
//                 // Instead of comparing values, compare the references of nodes
//                 if(curr1 == curr2){
//                     return curr1;  // Return the intersection node
//                 }
//                 curr2 = curr2.next;
//             }
//             curr1 = curr1.next;
//         }

//         return null; // No intersection found
//     }
// }
