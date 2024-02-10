Input 1: A = 1 -> 2 -> 3 -> 4
Input 2: A = 7 -> 2 -> 1

Output 1: 2 -> 1 -> 4 -> 3
Output 2: 2 -> 7 -> 1
//--------------------------------------------//
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
class Solution {
    public ListNode swapPairs(ListNode A) {
        if (A == null || A.next == null) {
            return A;
        }

        ListNode dummy = new ListNode(0);
        dummy.next = A;
        ListNode prev = dummy;

        while (prev.next != null && prev.next.next != null) {
            ListNode first = prev.next;
            ListNode second = prev.next.next;

            // Swap the pairs
            first.next = second.next;
            second.next = first;
            prev.next = second;

            // Move to the next pair
            prev = first;               // Or prev.next.next
        }

        return dummy.next;
    }
}
