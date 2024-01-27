Given a linked list of integers, find and return the middle element of the linked list.
NOTE: If there are N nodes in the linked list and N is even then return the (N/2 + 1)th element.
Input 1: 1 -> 2 -> 3 -> 4 -> 5
Input 2: 1 -> 5 -> 6 -> 2 -> 3 -> 4

Output 1: 3
Output 2: 2

//----------------------// O(n),O(1) //-------------------------//
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
class Solution {
    public int solve(ListNode A) {
        ListNode s = A;               // Slow pointer
        ListNode f = A;           // Fast pointer

        while(f.next != null && f.next.next != null){             // Traverse the list with two pointers
            s = s.next;                                           // Move slow pointer one step
            f = f.next.next;                                      // Move fast pointer two steps
        }
        if(f.next != null){                                      // If the list length is even, adjust the slow pointer
            return s.next.val;                                    // Return the value of the next node of the slow pointer
        }
        return s.val;                                     // Return the value of the slow pointer (middle element for odd-length list)
    }
}


//---------------// Optimised furthyer //---------------//
public ListNode MiddleNode(ListNode head){
        if(head == null){
            return head;
        }
        ListNode s = head;
        ListNode f = head;
        while(f.next != null && f.next.next != null){
            s = s.next;
            f = f.next;
        }
        return s;
    }