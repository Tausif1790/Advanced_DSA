You are given a singly linked list having head node A. You have to reverse the linked list and return the head node of that reversed list.
NOTE: You have to do it in-place and in one-pass.
Input 1: A = 1 -> 2 -> 3 -> 4 -> 5 -> NULL 
Input 2: A = 3 -> NULL 

Output 1: 5 -> 4 -> 3 -> 2 -> 1 -> NULL 
Output 2: 3 -> NULL 

//-------------------------// TC: O(n), SC: O(1) //--------------------------//
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
class Solution {
    public ListNode reverseList(ListNode A) {
        if (A == null || A.next == null) {
            return A;
        }

        // Initialize pointers for reversing the list
        ListNode prev = null;   // Previous node
        ListNode curr = A;      // Current node

        // Traverse the list and reverse the pointers
        while (curr != null) {
            ListNode nextNode = curr.next;  // Next node in the original list
            curr.next = prev;               // Reverse the pointer
            prev = curr;                    // Move the pointers one step forward
            curr = nextNode;                // Move the pointers one step forward
        }

        // Update the head of the reversed list
        A = prev;
        return A;
    }
}
// TC: O(n)
// SC: O(1)