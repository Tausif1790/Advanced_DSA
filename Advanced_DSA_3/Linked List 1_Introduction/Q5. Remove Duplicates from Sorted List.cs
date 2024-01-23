Given a sorted linked list, delete all duplicates such that each element appears only once.
Input 1: 1->1->2
Input 2: 1->1->2->3->3

Output 1: 1->2
Output 2: 1->2->3

//-----------------------// O(n),O(1) //-----------------------//
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
class Solution {
    public ListNode deleteDuplicates(ListNode A) {
        if (A == null || A.next == null) {
            return A;
        }
        ListNode curr = A;
        while (curr != null) {
            ListNode temp = curr.next;
            // Move temp to the next different value node
            while (temp != null && temp.val == curr.val) {
                temp = temp.next;
            }
            curr.next = temp;             // Update the next pointer to skip duplicates
            curr = temp;                  // Move the main pointer to the next distinct element
        }
        return A;
    }
}
