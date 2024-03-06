There are a total of A courses you have to take, labeled from 1 to A.
Some courses may have prerequisites, for example to take course 2 you have to first take course 1, which is expressed as a pair: [1,2].
So you are given two integer array B and C of same size where for each i (B[i], C[i]) denotes a pair.
Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?
Return 1 if it is possible to finish all the courses, or 0 if it is not possible to finish all the courses.

Input 1:
 A = 3
 B = [1, 2]
 C = [2, 3]
Input 2:
 A = 2
 B = [1, 2]
 C = [2, 1]

Output 1: 1
Output 2: 0

Explanation 1:
It is possible to complete the courses in the following order:
    1 -> 2 -> 3
//-----------------------------------------------------------------//
class Solution {
    public int solve(int A, List<int> B, List<int> C) {
        List<int> result = new List<int>();          // Stores the topological order of courses
        Queue<int> q = new Queue<int>();             // Queue for BFS traversal
        List<int> indegree = new List<int>(new int[A + 1]); // Stores the indegree of each course
        List<int>[] graph = new List<int>[A + 1];    // Adjacency list representing the graph of courses

        // Initializing the adjacency list
        for (int i = 1; i <= A; i++) {
            graph[i] = new List<int>();
        }

        // Building the graph and calculating the indegree for each course
        for(int i = 0; i < B.Count; i++){
            int frm = B[i];
            int to = C[i];

            graph[frm].Add(to);
            indegree[to]++;
        }

        // Enqueue courses with indegree 0 (no prerequisites)
        for(int i = 1; i <= A; i++){
            if(indegree[i] == 0){
                q.Enqueue(i);
            }
        }

        // BFS traversal to find the topological order (like level order traversal in tree)
        while(q.Count != 0){
            int curr = q.Dequeue();
            result.Add(curr);

            List<int> neighbours = graph[curr];      // All neighbours of the current node
            foreach(int neighbour in neighbours){
                indegree[neighbour]--;
                if(indegree[neighbour] == 0){
                    q.Enqueue(neighbour);
                }
            }
        }

        // Check if all courses are taken by examining the indegree array
        foreach(int el in indegree){
            if(el != 0){
                return 0;            // Not all courses can be taken
            }
        }

        return 1;                    // All courses can be taken

        // Time complexity: O(A + B), where A is the number of courses and B is the number of prerequisites
        // Space complexity: O(A)
    }
}
