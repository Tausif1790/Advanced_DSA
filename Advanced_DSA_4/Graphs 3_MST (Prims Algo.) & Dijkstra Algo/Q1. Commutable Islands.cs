Problem Description
There are A islands and there are M bridges connecting them. Each bridge has some cost attached to it.
We need to find bridges with minimal cost such that all islands are connected.
It is guaranteed that input data will contain at least one possible scenario in which all islands are connected with each other.

Input 1:
 A = 4
 B = [  [1, 2, 1]
        [2, 3, 4]
        [1, 4, 3]
        [4, 3, 2]
        [1, 3, 10]  ]
Output 1: 6
//-------------------------------------------------------//
public class Solution {
    public int solve(int A, int[][] B) {
        // Graph initialization
        ArrayList<Pair>[] graph = new ArrayList[A + 1];
        for (int i = 0; i <= A; i++) {
            graph[i] = new ArrayList<>();
        }

        // Building the graph
        for (int i = 0; i < B.length; i++) {
            int src = B[i][0];
            int dest = B[i][1];
            int weight = B[i][2];
            graph[src].add(new Pair(dest, weight));
            graph[dest].add(new Pair(src, weight));
        }

        // Visited array initialization
        boolean[] visited = new boolean[A + 1];

        // Priority Queue initialization with a custom comparator
        PriorityQueue<Pair> pq = new PriorityQueue<>((a, b) -> a.weight - b.weight);
        pq.add(new Pair(1, 0)); // Adding any node to the priority queue

        int totalCost = 0; // Accumulator for the minimum cost

        // Prim's Algorithm
        while (!pq.isEmpty()) {
            Pair curr = pq.poll();
            int currNode = curr.dest;
            int currWeight = curr.weight;

            if (visited[currNode]) {
                continue;
            }

            totalCost += currWeight;
            visited[currNode] = true;

            // Exploring neighbors
            ArrayList<Pair> neighbors = graph[currNode];
            for (Pair neighbor : neighbors) {
                if (!visited[neighbor.dest]) {
                    pq.add(neighbor);
                }
            }
        }

        return totalCost;
    }

    static class Pair {
        public int dest;
        public int weight;

        public Pair(int dest, int weight) {
            this.dest = dest;
            this.weight = weight;
        }
    }
}

