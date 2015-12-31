Given a list of words and two words word1 and word2, 
return the shortest distance between these two words in the list.

For example,
Assume that words = ["practice", "makes", "perfect", "coding", "makes"].

Given word1 = “coding”, word2 = “practice”, return 3.
Given word1 = "makes", word2 = "coding", return 1.

Note:
You may assume that word1 does not equal to word2, and word1 and word2 are both in the list.


public class Solution {
    // Keep updating index of two words, the shortest distance would be captured for sure
    public int ShortestDistance(string[] words, string word1, string word2) {
        int index1 = -1, index2 = -1, minDist = int.MaxValue;
        for(int i = 0; i < words.Length; i++) {
            if(words[i] == word1) index1 = i;
            if(words[i] == word2) index2 = i;
            if(index1 != -1 && index2 != -1) minDist = Math.Min(minDist, Math.Abs(index1-index2));
        }
        return minDist; 
    }
}