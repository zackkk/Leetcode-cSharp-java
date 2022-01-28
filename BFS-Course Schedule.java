There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. 
    You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return true if you can finish all courses. Otherwise, return false.

 
Example 1:
Input: numCourses = 2, prerequisites = [[1,0]]
Output: true
Explanation: There are a total of 2 courses to take. 
To take course 1 you should have finished course 0. So it is possible.
    
Example 2:
Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
Output: false
Explanation: There are a total of 2 courses to take. 
To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.


class Solution {
    // 构建adjancency matrix和numPrereq array
    // numPrereq为0的表示可以take，没有前置条件；
    // BFS: queue中存储inumPrereq为0的元素；根据matrix依次访问并更新numPrereq
    public boolean canFinish(int numCourses, int[][] prerequisites) {
        // build up data structure
        int n = prerequisites.length;
        Map<Integer, List<Integer>> matrix = new HashMap<>();
        int[] numPrereq = new int[numCourses];
        for(int i = 0; i < n; i++) {
            int cur = prerequisites[i][0];
            int prev = prerequisites[i][1];
            if (!matrix.containsKey(prev)) {
                matrix.put(prev, new ArrayList<>());
            }
            List<Integer> l = matrix.get(prev);
            l.add(cur);
            matrix.put(prev, l);
            numPrereq[cur]++;
        }
        Queue<Integer> queue = new LinkedList<>();
        for(int i = 0; i < numCourses; i++) {
            if (numPrereq[i] == 0) {
                queue.add(i);
            }
        }

        // BFS: take course & update indegree
        int count = 0;
        while(!queue.isEmpty()) {
            int cur = queue.poll();
            count++;
            if (matrix.containsKey(cur)) {
                List<Integer> l = matrix.get(cur);
                for (Integer i : l) {
                    numPrereq[i]--;
                    if (numPrereq[i] == 0) {
                        queue.add(i);
                    }
                }
            }
        }
        return numCourses == count;
    }
}
