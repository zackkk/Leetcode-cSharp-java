Given an unsorted array of integers, find the length of the longest consecutive elements sequence.

For example,
Given [100, 4, 200, 1, 3, 2],
The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.

Your algorithm should run in O(n) complexity.

Show Tags
Show Similar Problems


public class Solution {
    // Dictionary<number, consecutive length>
    // why save it only in boundary items work ? when combining [a...n-1] [n] [n+1...b],  [n-1] & [n+1] were also boundary items
    // so we can locate new boundary [a] & [b], and every element has been traversed during combination.
    public int LongestConsecutive(int[] nums) {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int result = 0;
        foreach(int num in nums){
            if(dict.ContainsKey(num)) continue;
            dict[num] = 1;
            
            int leftMost = dict.ContainsKey(num-1) ? num - dict[num-1] : num;
            int rightMost = dict.ContainsKey(num+1) ? num + dict[num+1] : num;
            
            int newLen = rightMost - leftMost + 1;
            result = Math.Max(result, newLen);
            dict[leftMost] = newLen;  // update only boundaries.
            dict[rightMost] = newLen;
        }
        return result;
    }
}