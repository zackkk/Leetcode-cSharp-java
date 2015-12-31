Follow up for H-Index: What if the citations array is sorted in ascending order? Could you optimize your algorithm?


public class Solution {
    // ignore this one, this is part of H-Index I
    public int HIndex(int[] citations) {
        int n = citations.Length;
        for(int h = n; h >= 1; h--){
            if(citations[n - h] >= h) return h;
        }
        return 0;
    }
}