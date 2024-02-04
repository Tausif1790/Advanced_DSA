Input 1:
A = [1, 4, 3, 2, 5, 2]
B = 3
Input 2:
A = [1, 2, 3, 1, 3]
B = 2

Output 1:[1, 2, 2, 4, 3, 5]
Output 2:[1, 1, 2, 3, 3]

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
    public ListNode partition(ListNode A, int B) {
        if(A == null || A.next == null){
            return A;
        }
        ListNode curr = A;
        ListNode h1 = new ListNode(0);
        ListNode h2 = new ListNode(0);
        ListNode h1Curr = h1;
        ListNode h2Curr = h2;
        while(curr != null){
            ListNode newNode = new ListNode(curr.val);
            if(newNode.val < B){
                h1Curr.next = newNode;
                h1Curr = h1Curr.next;
            }else{
                h2Curr.next = newNode;
                h2Curr = h2Curr.next;
            }
            curr = curr.next;
        }

        h1Curr.next = h2.next;
        return h1.next;
    }
}
