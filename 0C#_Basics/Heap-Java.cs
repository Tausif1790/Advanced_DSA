import java.util.PriorityQueue;
import java.util.Collections;

public class HeapOperationsExample {
    public static void main(String[] args) {
        // Initialize a MinHeap
        PriorityQueue<Integer> minHeap = new PriorityQueue<>();

        // Enqueue elements to MinHeap
        minHeap.add(5);
        minHeap.add(2);
        minHeap.add(8);
        minHeap.add(1);

        // Print elements in MinHeap
        System.out.println("Elements in MinHeap: " + minHeap);

        // Dequeue element from MinHeap
        int dequeuedMinElement = minHeap.poll();
        System.out.println("Dequeued element from MinHeap: " + dequeuedMinElement);

        // Peek at the front element in MinHeap
        int minFrontElement = minHeap.peek();
        System.out.println("Front element in MinHeap: " + minFrontElement);

        // Check if MinHeap is empty
        boolean isMinHeapEmpty = minHeap.isEmpty();
        System.out.println("Is MinHeap empty? " + isMinHeapEmpty);

        // Get the number of elements in MinHeap
        int minHeapSize = minHeap.size();
        System.out.println("Number of elements in MinHeap: " + minHeapSize);

        // Clear MinHeap
        minHeap.clear();

        // Check if MinHeap is empty after clearing
        isMinHeapEmpty = minHeap.isEmpty();
        System.out.println("Is MinHeap empty after clearing? " + isMinHeapEmpty);


        // Initialize a MaxHeap //----------------------------------------------------------//
        PriorityQueue<Integer> maxHeap = new PriorityQueue<>(Collections.reverseOrder());

        // Enqueue elements to MaxHeap
        maxHeap.add(5);
        maxHeap.add(2);
        maxHeap.add(8);
        maxHeap.add(1);

        // Print elements in MaxHeap
        System.out.println("\nElements in MaxHeap: " + maxHeap);

        // Dequeue element from MaxHeap
        int dequeuedMaxElement = maxHeap.poll();
        System.out.println("Dequeued element from MaxHeap: " + dequeuedMaxElement);

        // Peek at the front element in MaxHeap
        int maxFrontElement = maxHeap.peek();
        System.out.println("Front element in MaxHeap: " + maxFrontElement);

        // Check if MaxHeap is empty
        boolean isMaxHeapEmpty = maxHeap.isEmpty();
        System.out.println("Is MaxHeap empty? " + isMaxHeapEmpty);

        // Get the number of elements in MaxHeap
        int maxHeapSize = maxHeap.size();
        System.out.println("Number of elements in MaxHeap: " + maxHeapSize);

        // Clear MaxHeap
        maxHeap.clear();

        // Check if MaxHeap is empty after clearing
        isMaxHeapEmpty = maxHeap.isEmpty();
        System.out.println("Is MaxHeap empty after clearing? " + isMaxHeapEmpty);
    }
}
