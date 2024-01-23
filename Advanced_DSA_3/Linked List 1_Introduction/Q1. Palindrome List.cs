Given a singly linked list A, determine if it's a palindrome. Return 1 or 0, denoting if it's a palindrome or not, respectively.
A = [1, 2, 2, 1]
A = [1, 3, 2]
Output 1: 1 
Output 2: 0 
//-------------------------// TC:O(n), O(1) //----------------------//
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
class Solution {
    public int lPalin(ListNode A) {
        int count = Count(A);                // Get the total number of nodes in the linked list
        int mid = (count + 1) / 2;           // If count is odd, the left part is larger
        ListNode curr = A;

        // Move to the middle of the linked list
        for (int i = 1; i < mid; i++) {
            curr = curr.next;
        }

        ListNode secondPart = curr.next;         // 2nd part of the linked list
        curr.next = null;                        // Separate the linked list into two parts
        curr = A;

        secondPart = Reverse(secondPart);        // Reverse the second part of the linked list

        // Compare the values of the first and reversed second parts
        while (curr != null && secondPart != null) {
            if (curr.val != secondPart.val) {
                return 0;                        // Not a palindrome
            }
            curr = curr.next;
            secondPart = secondPart.next;
        }
        return 1;                                // Palindrome
    }

    public ListNode reversed(ListNode head){
        if(head == null || head.next == null){
            return head;
        }
        ListNode prev = null;
        ListNode curr = head;
        while(curr != null){
            ListNode nextNode = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextNode;
        }
        head = prev;
        return head;
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
