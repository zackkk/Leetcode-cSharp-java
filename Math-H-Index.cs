Given an array of citations (each citation is a non-negative integer) of a researcher, 
write a function to compute the researchers h-index.

According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers 
have at least h citations each, and the other N − h papers have no more than h citations each."

For example, given citations = [3, 0, 6, 1, 5], which means the researcher has 5 papers in total and each of them 
had received 3, 0, 6, 1, 5 citations respectively. Since the researcher has 3 papers with at least 3 citations each 
and the remaining two with no more than 3 citations each, his h-index is 3.

Note: If there are several possible values for h, the maximum one is taken as the h-index.


public class Solution {
    // h-index range: [0,n]
    
    // O(N)
    public int HIndex(int[] citations) {
        int n = citations.Length;
        int[] count = new int[n+1];
        foreach(int citation in citations){
            if(citation >= n) count[n]++;
            else count[citation]++;
        }
        int total = 0;
        for(int h = n; h >= 1; h--){
            total += count[h];
            if(total >= h) return h;
        }
        return 0;
    }
    
    // O(NlogN)
    public int HIndex2(int[] citations) {
        Array.Sort(citations);
        int n = citations.Length;
        for(int h = n; h >= 1; h--){
            if(citations[n - h] >= h){
                return h;
            }
        }
        
        return 0;
    }
}