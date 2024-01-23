Given a linked list A, remove the B-th node from the end of the list and return its head.
For example, given linked list: 1->2->3->4->5, and B = 2.
After removing the second node from the end, the linked list becomes 1->2->3->5.
NOTE: If B is greater than the size of the list, remove the first node of the list.
Try doing it using constant additional space.
Input 1:
A = 1->2->3->4->5
B = 2
Input 2:
A = 1
B = 1

Output 1:
1->2->3->5
Output 2:

//-------------------------------// O(n), O(1) //----------------------------//
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
class Solution {
    public ListNode removeNthFromEnd(ListNode A, int B) {
        if (A == null) {
            return A;
        }
        int count = Count(A);

        // If removing A (head of the linked list)
        if (B >= count) {
            return A.next;
        }

        int leftIdx = count - B;
        ListNode curr = A;
        for (int i = 1; i < leftIdx; i++) {
            curr = curr.next;
        }

        curr.next = curr.next.next;     // Remove the Nth node from the end

        return A;
    }

    // Counts the number of nodes in the linked list.
    public int Count(ListNode A){
        int count = 0;
        ListNode curr = A;
        while (curr != null) {
            count++;
            curr = curr.next;
        }
        return count;
    }
}

// O(n), O(1)
  