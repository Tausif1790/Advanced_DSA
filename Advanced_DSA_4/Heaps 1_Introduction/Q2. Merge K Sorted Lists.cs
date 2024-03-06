Input 1:
 1 -> 10 -> 20
 4 -> 11 -> 13
 3 -> 8 -> 9
Input 2:
 10 -> 12
 13
 5 -> 6

 1 -> 3 -> 4 -> 8 -> 9 -> 10 -> 11 -> 13 -> 20
Output 2: 5 -> 6 -> 10 -> 12 ->13

//-----------------------------------------------------//
import java.util.ArrayList;
import java.util.PriorityQueue;
import java.util.Comparator;

/**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     ListNode(int x) { val = x; next = null; }
 * }
 */

public class Solution {
   // Function to merge k sorted linked lists.
    public ListNode mergeKLists(ArrayList<ListNode> lists) {
        // Get the number of lists (k)
        int k = lists.size();
        // Create an array to store the head nodes of all lists
        ListNode[] listNodesArray = new ListNode[k];

        // Copy the head nodes of all the k lists into 'listNodesArray'
        for (int i = 0; i < k; i++) {
            listNodesArray[i] = lists.get(i);
        }

        // Call the merge method to merge k sorted linked lists
        return merge(listNodesArray, k);
    }

    // Function to merge k sorted linked lists using a PriorityQueue
    private ListNode merge(ListNode[] lists, int k) {
        // Initialize a min-heap priority queue of ListNode objects
        PriorityQueue<ListNode> pq = new PriorityQueue<>((node1, node2) -> node1.val - node2.val);

        // Push the head nodes of all the k lists into the PriorityQueue
        for (int i = 0; i < k; i++) {
            if (lists[i] != null) {
                pq.add(lists[i]);
            }
        }

        // Create a dummy node to simplify the code
        ListNode dummy = new ListNode(-1);
        // 'last' will be used to keep track of the last node in the merged list
        ListNode last = dummy;

        // Continue until the PriorityQueue is not empty
        while (!pq.isEmpty()) {
            // Get the node with the smallest value from the PriorityQueue
            ListNode current = pq.remove();

            // Add the current node to the merged list
            last.next = current;
            last = last.next;

            // Check if there is a next node in the current list and add it to the PriorityQueue
            if (current.next != null) {
                pq.add(current.next);
            }
        }

        // Return the next of the dummy node, which is the actual head of the merged list.
        return dummy.next;
    }

    // // Custom comparer to compare ListNode based on their values
    // private class ListNodeComparer : IComparer<ListNode> {
    //     public int Compare(ListNode x, ListNode y) {
    //         return x.val - y.val;
    //     }
    // }
}

// TC: O(x * n)
// x: total no. of els in all LL, n: no. of LL