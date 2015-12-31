Given an index k, return the kth row of the Pascals triangle.

For example, given k = 3,
Return [1,3,3,1].


public class Solution {
    public IList<int> GetRow(int rowIndex) {
        IList<int> list = new List<int>();
        for (int i = 0; i <= rowIndex; i++) {
            int size = list.Count;
            list.Insert(0, 1);  // insert a '1' at the beginning
            for (int j = 1; j < size; j++) {
                list[j] = list[j] + list[j+1];
            }
        }
        return list;
    }
}