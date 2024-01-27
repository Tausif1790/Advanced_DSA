You are given a linked list that contains a loop.
You need to find the node, which creates a loop and break it by making the node point to NULL.
Input 1;:
1 -> 2
^    |
| - - 
Input 2:
3 -> 2 -> 4 -> 5 -> 6
          ^         |
          |         |    
          - - - - - -

Output 1:

 1 -> 2 -> NULL
Output 2:

 3 -> 2 -> 4 -> 5 -> 6 -> NULL

 //---------------------// O(n), O(1) //---------------------//
 /**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {this.val = x; this.next = null;}
 * }
 */
class Solution {
    public ListNode solve(ListNode A) {
        if(A == null || A.next == null){
            return null;
        }

        // Initialize pointers for cycle detection
        ListNode slow = A;
        ListNode fast = A;
        bool hasCycle = false;

        // Detect cycle using Floyd's cycle-finding algorithm
        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
            if(slow == fast){
                hasCycle = true;
                break;
            }
        }

        // If no cycle is found, return null
        if(!hasCycle){
            return null;
        }

        // Move one pointer to the head and find the node where the cycle starts
        ListNode h1 = A;
        ListNode h2 = slow;
        while(h1.next != h2.next){
            h1 = h1.next;
            h2 = h2.next;
        }

        // Break the cycle by setting the next of the last node in the cycle to null
        h2.next = null;

        return A;
    }
}
