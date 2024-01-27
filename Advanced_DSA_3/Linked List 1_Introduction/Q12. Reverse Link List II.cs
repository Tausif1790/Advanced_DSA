A = 1 -> 2 -> 3 -> 4 -> 5
 B = 2
 C = 4
Input 2:
 A = 1 -> 2 -> 3 -> 4 -> 5
 B = 1
 C = 5

Output 1:
 1 -> 4 -> 3 -> 2 -> 5
Output 2:
 5 -> 4 -> 3 -> 2 -> 1

//------------//  //---------------------------//
 /**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
class Solution {
    public ListNode reverseBetween(ListNode A, int B, int C) {
        if (A == null || A.next == null || B == C) {
            return A;
        }

        ListNode dummy = new ListNode(0);
        dummy.next = A;
        ListNode prev = dummy;

        // Move to the node before the reversed sublist
        for (int i = 1; i < B; i++) {
            prev = prev.next;
        }

        // Reverse the sublist from B to C
        prev.next = reverseList(prev.next, C - B + 1);

        return dummy.next;
    }

    // Helper method to reverse a sublist of length 'count'
    public ListNode reverseList(ListNode head, int count) {
        if (head == null || head.next == null) {
            return head;
        }

        // Initialize pointers for reversing the sublist
        ListNode prev = null;   // Previous node
        ListNode curr = head;   // Current node
        int i = 0;

        // Traverse the sublist and reverse the pointers
        while (curr != null && i < count) {
            ListNode nextNode = curr.next;  // Next node in the original sublist
            curr.next = prev;               // Reverse the pointer
            prev = curr;                    // Move the pointers one step forward
            curr = nextNode;                // Move the pointers one step forward
            i++;
        }

        // Update the head of the reversed sublist
        head.next = curr;
        return prev;
    }
}
