Sort a linked list, A in O(n log n) time.

//----------------// TA soln //------------------//
class Solution {
    public ListNode sortList(ListNode A) {
        if (A == null || A.next == null) {
            return A;
        }

        ListNode middleNode = MiddleNode(A);

        ListNode leftHalfHead = A;
        ListNode rightHalfHead = middleNode.next;
        middleNode.next = null;

        ListNode leftHalf = sortList(leftHalfHead);
        ListNode rightHalf = sortList(rightHalfHead);

        return mergeTwoSortedLL(leftHalf, rightHalf);
    }

    public ListNode MiddleNode(ListNode head) {
        if (head == null) {
            return head;
        }
        ListNode slow = head;
        ListNode fast = head.next;

        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }

    public ListNode mergeTwoSortedLL(ListNode h1, ListNode h2) {
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;

        while (h1 != null && h2 != null) {
            if (h1.val <= h2.val) {
                current.next = h1;
                h1 = h1.next;
            } else {
                current.next = h2;
                h2 = h2.next;
            }
            current = current.next;
        }

        if (h1 != null) {
            current.next = h1;
        }
        if (h2 != null) {
            current.next = h2;
        }

        return dummy.next;
    }
}
//O(nLogn),O(logn)=>stack space
//---------// Mine getting TLE for hardTest (problem is with MiddleNode method) //-----------------//
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
class Solution {
    public ListNode sortList(ListNode A) {
        if(A == null || A.next == null){
            return A;
        }

        // Find the middle node of the list
        ListNode middleNode = MiddleNode(A);

        // Divide the list into two halves
        ListNode leftHalfHead = A;
        ListNode rightHalfHead = middleNode.next;
        middleNode.next = null;

        // Recursively sort the left and right halves
        ListNode leftHalf = sortList(leftHalfHead);
        ListNode rightHalf = sortList(rightHalfHead);
        
        // Merge the sorted halves
        return mergeTwoSortedLL(leftHalf, rightHalf);
    }

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

    public ListNode mergeTwoSortedLL(ListNode h1, ListNode h2){
        if(h1 == null && h2 == null) return null;
        if(h1 == null) return h2;
        if(h2 == null) return h1;
        ListNode head = null;
        ListNode tail = null;

        if(h1.val <= h2.val){
            head = h1;
            tail = h1;
            h1 = h1.next;
        }else{
            head = h2;
            tail = h2;
            h2 = h2.next;
        }

        while(h1 != null && h2 != null){
            if(h1.val <= h2.val){
                tail.next = h1;
                h1 = h1.next;
            }else{
                tail.next = h2;
                h2 = h2.next;
            }
            tail = tail.next;
        }

        if(h1 != null){
            tail.next = h1;
        }
        if(h2 != null){
            tail.next = h2;
        }

        return head;
    }
}
