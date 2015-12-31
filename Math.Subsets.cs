Given a set of distinct integers, nums, return all possible subsets.

Note:
Elements in a subset must be in non-descending order.
The solution set must not contain duplicate subsets.
For example,
If nums = [1,2,3], a solution is:

[
  [3],
  [1],
  [2],
  [1,2,3],
  [1,3],
  [2,3],
  [1,2],
  []
]


public class Solution {
    // 2^n possibilities: for each number, either take or not
    // mapping: [0,0,0] - []
    //          [0,0,1] - [3]
    //          [0,1,0] - [2]
    //          [1,1,1] - [1,2,3]
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(nums);
        for(int i = 0; i < Math.Pow(2, nums.Length); i++){
            List<int> oneset = new List<int>();
            for(int j = 0; j < nums.Length; j++){
                if(((i >> j) & 1) != 0){
                    oneset.Add(nums[j]);
                }
            }
            result.Add(oneset);
        }
        return result;
    }
}