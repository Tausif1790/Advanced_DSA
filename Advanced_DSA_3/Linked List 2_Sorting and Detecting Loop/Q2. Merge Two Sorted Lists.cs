Merge two sorted linked lists, A and B, and return it as a new list.
The new list should be made by splicing together the nodes of the first two lists and should also be sorted.
Input 1:
 A = 5 -> 8 -> 20
 B = 4 -> 11 -> 15
Input 2:
 A = 1 -> 2 -> 3
 B = Null

Output 1: 4 -> 5 -> 8 -> 11 -> 15 -> 20
Output 2: 1 -> 2 -> 3


//--------------------//  //-------------------------------//
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
class Solution {
    public ListNode mergeTwoLists(ListNode A, ListNode B) {
        if(A == null && B == null) return null;
        ListNode dummy = new ListNode(0);
        ListNode curr = dummy;

        while(A != null && B != null){
            if(A.val <= B.val){
                curr.next = A;
                A = A.next;
            }else{
                curr.next = B;
                B = B.next;
            }
            curr = curr.next;
        }

        // 
        if(A != null){
            curr.next = A;
        }
        if(B != null){
            curr.next = B;
        }
        return dummy.next;
    }
}

class Solution {
    public ListNode mergeTwoLists(ListNode A, ListNode B) {
        if(A == null && B == null) return null;

        ListNode h1 = A;          // Head of the first list
        ListNode h2 = B;          // Head of the second list
        ListNode head = null;  // Head of the merged list
        ListNode tail = null;  // Tail of the merged list

        // Setting head
        if(h1.val <= h2.val){     // Compare the values of the heads of the two lists
            head = h1;          // Head of the merged list is the head of the first list
            tail = h1;          // Tail of the merged list is also the head of the first list
            h1 = h1.next;        // Move to the next node in the first list
        }
        else{
            head = h2;  // Head of the merged list is the head of the second list
            tail = h2;  // Tail of the merged list is also the head of the second list
            h2 = h2.next;  // Move to the next node in the second list
        }

        // Merging nodes
        while(h1 != null && h2 != null){
            if(h1.val <= h2.val){
                tail.next = h1;  // Append the current node of the first list to the merged list
                h1 = h1.next;  // Move to the next node in the first list
            } else {
                tail.next = h2;  // Append the current node of the second list to the merged list
                h2 = h2.next;  // Move to the next node in the second list
            }
            tail = tail.next;  // Move the tail to the last node of the merged list
        }

        // Appending remaining nodes
        if(h1 != null){
            tail.next = h1;  // Append the remaining nodes of the first list to the merged list
        }
        if(h2 != null){
            tail.next = h2;  // Append the remaining nodes of the second list to the merged list
        }

        return head;  // Return the head of the merged list
    }
}
