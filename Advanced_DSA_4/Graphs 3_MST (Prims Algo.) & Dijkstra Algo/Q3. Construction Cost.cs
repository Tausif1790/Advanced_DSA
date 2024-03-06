Given a graph with A nodes and C weighted edges. Cost of constructing the graph is the sum of weights of all the edges in the graph.
Find the minimum cost of constructing the graph by selecting some given edges such that we can reach every other node from the 1st node.
NOTE: Return the answer modulo 109+7 as the answer can be large.

Input 1:
A = 3
B = [   [1, 2, 14]
        [2, 3, 7]
        [3, 1, 2]   ]
Output 1: 9
//-------------------------------------------------//
public class Solution {
    int mod = (int) Math.pow(10, 9) + 7; // O(1) space

    public int solve(int A, int[][] B) {
        int n = B.length;

        // Boolean array to track visited nodes
        boolean[] visited = new boolean[A + 1]; // O(A) space

        // Min heap (PriorityQueue) for Dijkstra's Algorithm
        PriorityQueue<Pair> pq = new PriorityQueue<>((a, b) -> a.weight - b.weight); // O(logA) space

        // Build graph
        ArrayList<Pair>[] graph = new ArrayList[A + 1]; // Adjacency list representation of the graph
        for (int i = 0; i <= A; i++) {
            graph[i] = new ArrayList<>();
        }
        for (int i = 0; i < n; i++) {
            int src = B[i][0];
            int dest = B[i][1];
            int weight = B[i][2];
            graph[src].add(new Pair(dest, weight));
            graph[dest].add(new Pair(src, weight));
        }

        // Put the 1st node into the minHeap
        pq.add(new Pair(1, 0)); // O(logA) time
        int cost = 0; // Accumulator for the total cost

        // Dijkstra's Algorithm
        while (!pq.isEmpty()) {
            Pair curr = pq.poll(); // O(logA) time
            int currNode = curr.dest; // Current node being processed
            int currWeight = curr.weight; // Weight of the current edge

            if (visited[currNode]) {
                continue; // If the node is already visited, skip
            }

            visited[currNode] = true; // Mark the current node as visited
            cost = (cost % mod + currWeight % mod) % mod; // Accumulate the total cost

            // Put all children of currNode in minHeap
            ArrayList<Pair> children = graph[currNode];
            for (Pair child : children) {
                if (!visited[child.dest]) {
                    pq.add(child); // Add the child to the priority queue
                }
            }
        }
        return cost % mod; // Return the minimum cost modulo 10^9 + 7
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
