Input 1:
 A = [1, 2, 3, 4, 5, 6]
 B = 2
Input 2:
 A = [1, 2, 3, 4, 5, 6]
 B = 3
Example Output
Output 1: [2, 1, 4, 3, 6, 5]
Output 2: [3, 2, 1, 6, 5, 4]

//-------------------------// O(n),O(1) //----------------------------//
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
class Solution {
    public ListNode reverseList(ListNode A, int B) {
        if(A == null || A.next == null || B == 1){
            return A;
        }

        ListNode dummy = new ListNode(0);
        dummy.next = A;
        ListNode prev = dummy;

        // Iterate through the list in groups of size B
        while(prev != null){                   // previously using (&& prev.next != null) aslo getting runtime exception
            prev.next = reverseListOfCount(prev.next, B);
            // Move forward B steps
            for(int i=0; i<B && prev != null; i++){
                prev = prev.next;
            }
        }
        return dummy.next;
    }

    // Helper method to reverse a sublist of length 'count'
    public ListNode reverseListOfCount(ListNode head, int count) {
        if(head == null || head.next == null){
            return head;
        }

        ListNode prev = null;
        ListNode curr = head;
        int i = 0;
        // Reverse the sublist of length 'count'
        while(curr != null && i < count){
            ListNode nextNode = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextNode;
            i++;
        }
        
        // Connect the reversed sublist to the remaining part of the list
        head.next = curr;
        return prev;
    }
}
