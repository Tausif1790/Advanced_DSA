Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and set.

get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
set(key, value) - Set or insert the value if the key is not already present. When the cache reaches its capacity, it should invalidate the least recently used item before inserting the new item.
The LRUCache will be initialized with an integer corresponding to its capacity. Capacity indicates the maximum number of unique keys it can hold at a time.

Definition of "least recently used" : An access to an item is defined as a get or a set operation of the item. "Least recently used" item is the one with the oldest access time.

NOTE: If you are using any global variables, make sure to clear them in the constructor.

Example :

Input : 
         capacity = 2
         set(1, 10)
         set(5, 12)
         get(5)        returns 12
         get(1)        returns 10
         get(10)       returns -1
         set(6, 14)    this pushes out key = 5 as LRU is full. 
         get(5)        returns -1 


//-------------------------//   //---------------------------//
class Solution {
    int capacity;
    Dictionary<int, ListNode> dict = new Dictionary<int, ListNode>(); //key, ListNode (only address of node)
    ListNode head = null;
    ListNode tail = null;

    public Solution(int capacity) {
        this.capacity = capacity;               // Initialize the capacity of the LRUCache
    }

    public int get(int key) {
        if (dict.ContainsKey(key)) {
            ListNode node = dict[key];          // Retrieve the ListNode corresponding to the key
            MoveToTail(node);                    // Move the accessed node to the tail to mark it as recently used
            return node.val;                     // Return the value associated with the key
        }
        return -1;                               // The key is not present in the LRUCache
    }

    public void set(int key, int value) {
        if (dict.ContainsKey(key)) {
            // Update existing key
            ListNode node = dict[key];           // Retrieve the ListNode corresponding to the key
            node.val = value;                    // Update the value of the existing key
            MoveToTail(node);                    // Move the updated node to the tail to mark it as recently used
        } else {
            // Add new key
            if (dict.Count == capacity) {
                // Remove the least recently used item from the cache
                dict.Remove(head.key);           // Remove the head node from the LRUCache
                RemoveFromHead();                // Remove the head node from the doubly linked list
            }

            ListNode newNode = new ListNode(key, value);         // Create a new ListNode for the new key-value pair
            dict.Add(key, newNode);                             // Add the new key-value pair to the dictionary
          
            if (head == null) {                      // or tail == null
                // Cache is empty
                head = newNode;                      // Set the head to the new node
                tail = newNode;                      // Set the tail to the new node
            } else {
                // Add to the tail
                tail.next = newNode;                 // Set the next of the current tail to the new node
                newNode.prev = tail;                 // Set the prev of the new node to the current tail
                tail = newNode;                      // Update the tail to the new node
            }
        }
    }

    // Helper methods
    private void MoveToTail(ListNode node) {
        if (node == tail) {
            // Already at the tail, nothing to do
            return;
        }

        if (node == head) {
            // Move head to the next node
            head = head.next;                // Update the head to the next node
            head.prev = null;                // Set the prev of the new head to null
        } else {
            // Remove from the middle of the list
            node.prev.next = node.next;      // Update the next of the prev node to the next of the current node
            node.next.prev = node.prev;      // Update the prev of the next node to the prev of the current node
        }

        // Add to the tail
        tail.next = node;                // Set the next of the current tail to the node
        node.prev = tail;                // Set the prev of the node to the current tail
        node.next = null;                // Set the next of the node to null
        tail = node; // Update the tail to the node
    }

    private void RemoveFromHead() {
        if (head == null) {
            // Cache is empty
            return;
        }

        if (head == tail) {
            // Single node in the cache
            dict.Remove(head.key);       // Remove the head node from the dictionary
            head = null;                 // Set the head to null
            tail = null;                 // Set the tail to null
        } else {
            // Remove from the head
            dict.Remove(head.key);           // Remove the head node from the dictionary
            head = head.next;                // Update the head to the next node
            head.prev = null;                // Set the prev of the new head to null
        }
    }

    class ListNode {
        public int key;
        public int val;
        public ListNode next;
        public ListNode prev;

        public ListNode(int key, int val) {
            this.key = key;
            this.val = val;
            this.next = null;
            this.prev = null;
        }
    }
}
