/**
 * Definition for singly-linked list.
 * class ListNode {
 *     public int val;
 *     public ListNode next;
 *     ListNode(int x) { val = x; next = null; }
 * }
 */
using System.Collections.Generic;
using System;

class PriorityQueue<T> {
    class Node {
        public int Priority { get; set; }
        public T Object { get; set; }
    }

    //object array
    List<Node> queue = new List<Node>();
    int heapSize = -1;
    bool _isMinPriorityQueue;
    public int Count { get { return queue.Count; } }
    /// <summary>
    /// If min queue or max queue
    /// </summary>
    /// <param name="isMinPriorityQueue"></param>
    public PriorityQueue(bool isMinPriorityQueue) {
        _isMinPriorityQueue = isMinPriorityQueue;
    }
    
    private void Swap(int i, int j) {
        var temp = queue[i];
        queue[i] = queue[j];
        queue[j] = temp;
    }

    private int ChildL(int i) {
        return i * 2 + 1;
    }

    private int ChildR(int i) {
        return i * 2 + 2;
    }
    
    private void MaxHeapify(int i) {
		int left = ChildL(i);
		int right = ChildR(i);

		int heighst = i;

		if (left <= heapSize && queue[heighst].Priority < queue[left].Priority)
		    heighst = left;
		if (right <= heapSize && queue[heighst].Priority < queue[right].Priority)
		    heighst = right;

		if (heighst != i) {
		    Swap(heighst, i);
		    MaxHeapify(heighst);
		}
	}
	private void MinHeapify(int i) {
		int left = ChildL(i);
		int right = ChildR(i);

		int lowest = i;

		if (left <= heapSize && queue[lowest].Priority > queue[left].Priority)
		    lowest = left;
		if (right <= heapSize && queue[lowest].Priority > queue[right].Priority)
		    lowest = right;

		if (lowest != i) {
		    Swap(lowest, i);
		    MinHeapify(lowest);
		}
	}
	

	/// <summary>
	/// Maintain max heap
	/// </summary>
	/// <param name="i"></param>
	private void BuildHeapMax(int i) {
		while (i >= 0 && queue[(i - 1) / 2].Priority < queue[i].Priority) {
		    Swap(i, (i - 1) / 2);
		    i = (i - 1) / 2;
		}
	}
	/// <summary>
	/// Maintain min heap
	/// </summary>
	/// <param name="i"></param>
	private void BuildHeapMin(int i) {
		while (i >= 0 && queue[(i - 1) / 2].Priority > queue[i].Priority) {
		    Swap(i, (i - 1) / 2);
		    i = (i - 1) / 2;
		}
	}
	
	/// <summary>
	/// Enqueue the object with priority
	/// </summary>
	/// <param name="priority"></param>
	/// <param name="obj"></param>
	public void Enqueue(int priority, T obj) {
		Node node = new Node() { Priority = priority, Object = obj };
		queue.Add(node);
		heapSize++;
		//Maintaining heap
		if (_isMinPriorityQueue)
		    BuildHeapMin(heapSize);
		else
		    BuildHeapMax(heapSize);
	}
	
	/// <summary>
	/// Dequeue the object
	/// </summary>
	/// <returns></returns>
	public T Dequeue() {
		if (heapSize > -1) {
		    var returnVal = queue[0].Object;
		    queue[0] = queue[heapSize];
		    queue.RemoveAt(heapSize);
		    heapSize--;
		    //Maintaining lowest or highest at root based on min or max queue
		    if (_isMinPriorityQueue)
		        MinHeapify(0);
		    else
		        MaxHeapify(0);
		    return returnVal;
		}
		else
		    throw new Exception("Queue is empty");
	}
	
	/// <summary>
	/// Updating the priority of specific object
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="priority"></param>
	public void UpdatePriority(T obj, int priority) {
		int i = 0;
		for (; i <= heapSize; i++) {
		    Node node = queue[i];
		    if (object.ReferenceEquals(node.Object, obj)) {
		        node.Priority = priority;
		        if (_isMinPriorityQueue) {
		            BuildHeapMin(i);
		            MinHeapify(i);
		        }
		        else {
		            BuildHeapMax(i);
		            MaxHeapify(i);
		        }
		    }
		}
	}
	/// <summary>
	/// Searching an object
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	public bool IsInQueue(T obj) {
		foreach (Node node in queue)
		    if (object.ReferenceEquals(node.Object, obj))
		        return true;
		return false;
	}
	
	public T Top() {
	    
	    if(heapSize > -1) {
	        var returnVal = queue[0].Object;
	        return returnVal;
	    }else
		    throw new Exception("Queue is empty");
	}
}


class Solution {
    
	public ListNode mergeKLists(List<ListNode> A) {
	    
	    Dictionary<int, List<ListNode>> map = new Dictionary<int, List<ListNode>>();
	    ListNode node;
	    List<ListNode> list;
	    int val;
	    
	    foreach(ListNode heads in A) {
	        node = heads	;
	        while (node != null) {
	            val = node.val;
	            
	            if (map.ContainsKey(val)) {
	                list = map[val];
	                list.Add(node);
	            } else {
	                list = new List<ListNode>();
	                list.Add(node);
	                map[val] = list;
	            }
	            
	            node = node.next;
	        }
	    }
	    PriorityQueue<List<ListNode>> pq = new PriorityQueue<List<ListNode>>(true);
	    
	    ListNode head = null;
	    node = null;
	    
	    foreach(KeyValuePair<int, List<ListNode>> entry in map) {
	        
	        list = entry.Value;
	        pq.Enqueue(entry.Key, entry.Value);
	        
	    }
	    while(pq.Count > 0){
	    	list = pq.Dequeue();
	    	foreach(ListNode n in list) {
		        if (head == null)
		            head = n;
		        if (node != null)
		            node.next = n;
		        node = n;
		    }
			
	    }
	    
	    return head;
	    
	}
}
