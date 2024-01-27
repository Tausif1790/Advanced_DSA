 A = [2, 4, 3]
 B = [5, 6, 4]
Input 2:
 A = [9, 9]
 B = [1]

Output 1: [7, 0, 8]
Output 2: [0, 0, 1]

//----------------------------------------//
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
class Solution {
    public ListNode addTwoNumbers(ListNode A, ListNode B) {
        if (A == null || B == null) {
            return null;
        }

        ListNode dummy = new ListNode(0);
        ListNode curr = dummy;
        int carry = 0;

        while (A != null || B != null) {
            int aValue = (A != null) ? A.val : 0;
            int bValue = (B != null) ? B.val : 0;
            int x = aValue + bValue + carry;

            if (x >= 10) {
                int digit = x % 10;
                curr.next = new ListNode(digit);
                carry = 1;
            } else {
                curr.next = new ListNode(x);
                carry = 0;
            }

            curr = curr.next;

            if (A != null) A = A.next;
            if (B != null) B = B.next;
        }

        if (carry > 0) {
            curr.next = new ListNode(carry);
        }

        return dummy.next;
    }
}
