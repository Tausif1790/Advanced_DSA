Given a weighted undirected graph having A nodes and M weighted edges, and a source node C.
You have to find an integer array D of size A such that:
D[i]: Shortest distance from the C node to node i.
If node i is not reachable from C then -1.
Input:
A = 5
B = [   [0, 3, 4]
        [2, 3, 3] 
        [0, 1, 9] 
        [3, 4, 10] 
        [1, 3, 8]  ] 
C = 4

Output :D = [14, 18, 13, 10, 0]
//------------------------------------------------------//
public class Solution {
    public int[] solve(int A, int[][] B, int C) {
        int n = B.length;
        boolean[] visited = new boolean[A];  // Visited array to track visited nodes
        //visited[C] = true;                 // not required with this solution  // Mark the source node as visited

        // Min heap (PriorityQueue)
        PriorityQueue<Pair> pq = new PriorityQueue<>((a, b) -> a.weight - b.weight);

        // Array for storing results; Initialize with infinity except source node C.
        int[] distance = new int[A];         // Distance array to store shortest distances
        for(int i = 0; i < A; i++){
            distance[i] = Integer.MAX_VALUE;
        }
        distance[C] = 0;                     // Set distance of source node to 0

        // Build graph
        ArrayList<Pair>[] graph = new ArrayList[A]; // Adjacency list representation of the graph
        for (int i = 0; i < A; i++) {
            graph[i] = new ArrayList<>();
        }
        for (int i = 0; i < n; i++) {
            int src = B[i][0];
            int dest = B[i][1];
            int weight = B[i][2];
            graph[src].add(new Pair(dest, weight));
            graph[dest].add(new Pair(src, weight));
        }

        // Put the source node in the minHeap
        pq.add(new Pair(C, 0)); // Add source node directly to the priority queue

        // Dijkstra's Algorithm
        while (!pq.isEmpty()) {
            Pair curr = pq.poll(); // Extract the minimum distance node from the priority queue
            int currNode = curr.dest; // Current node being processed
            int currWeight = curr.weight; // Weight of the current edge

            // If the node is already visited, skip
            if (visited[currNode]) {
                continue;
            }

            visited[currNode] = true; // Mark the current node as visited

            // Put all children of currNode in minHeap
            ArrayList<Pair> children = graph[currNode];
            for (Pair child : children) {
                int newDistance = distance[currNode] + child.weight; // Calculate new distance to the child
                if (newDistance < distance[child.dest]) {
                    distance[child.dest] = newDistance; // Update the distance if a shorter path is found
                    pq.add(new Pair(child.dest, newDistance)); // Add the child to the priority queue
                }
            }
        }

        // Convert unreachable nodes to -1
        for (int i = 0; i < A; i++) {
            if (distance[i] == Integer.MAX_VALUE) {
                distance[i] = -1;
            }
        }
        return distance;
    }

    public class Pair {
        public int dest;
        public int weight;

        public Pair(int dest, int weight) {
            this.dest = dest;
            this.weight = weight;
        }
    }
}
// Time Complexity: O((A + E) * logA), where E is the number of edges
// Space Complexity: O(A + E), where E is the number of edges