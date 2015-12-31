Given numRows, generate the first numRows of Pascals triangle.

For example, given numRows = 5,
Return

[
     [1],
    [1,1],
   [1,2,1],
  [1,3,3,1],
 [1,4,6,4,1]
]


public class Solution {
    // insert a '1' at the beginning of a previous row : 1 1 3 3 1 -> 
    // add elements in the middle (except the first and the last), with its next element : 1 4 6 4 1
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> list = new List<int>();
        for (int i = 0; i < numRows; i++) {
            list.Insert(0, 1); // insert at the beginning
            for(int j = 1; j < list.Count - 1; j++){
                list[j] = list[j] + list[j+1];
            }
            result.Add(new List<int>(list));
        }
        return result;
    }
}