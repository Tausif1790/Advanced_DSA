Example Input
Given list
   1 -> 2 -> 3
with random pointers going from
  1 -> 3
  2 -> 1
  3 -> 1

Example Output
   1 -> 2 -> 3
with random pointers going from
  1 -> 3
  2 -> 1
  3 -> 1

//--------------------// O(n), O(1) //-----------------------//
/**
 * Definition for singly-linked list with a random pointer.
 * class RandomListNode {
 *     int label;
 *     RandomListNode next, random;
 *     RandomListNode(int x) { this.label = x; }
 * };
 */
using System;
using System.Collections.Generic;

public class Solution {
    public RandomListNode copyRandomList(RandomListNode head) {

        // Step 1: Duplicate nodes and insert them between the original nodes
        duplicateNode(head);

        // Step 2: Copy random pointers
        RandomListNode x = head;
        while(x != null){
            RandomListNode y = x.next;          //==> imp // we put it here to avoid null pointer exeption 
            if(x.random != null){
                y.random = x.random.next;
            }
            else{
                y.random = null;
            }
            x = x.next.next;
        }

        // Step 3: Separate the original and duplicated lists
        RandomListNode temp = head.next;
        head = temp;
        while(temp != null && temp.next != null){
            temp.next = temp.next.next;
            temp = temp.next;
        }

        return head;
    }

    public void duplicateNode(RandomListNode head){
        if(head == null){
            return;
        }

        RandomListNode curr = head;
        while(curr != null){
            RandomListNode xn = new RandomListNode(curr.label);
            xn.next = curr.next;
            curr.next = xn;
            curr = curr.next.next;
        }
    }
}
