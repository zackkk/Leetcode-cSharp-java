Write a function to generate the generalized abbreviations of a word.

Example:
Given word = "word", return the following list (order does not matter):
["word", "1ord", "w1rd", "wo1d", "wor1", "2rd", "w2d", "wo2", "1o1d", "1or1", "w1r1", "1o2", "2r1", "3d", "w3", "4"]


public class Solution {
    // divide and conquer
    // word w1rd wo1d wor1 w1r1 w2d wo2 w3
    // 1ord 1o1d 1or1 1o2
    // ...
    public IList<string> GenerateAbbreviations(string word) {
        IList<string> result = new List<string>();
        int n = word.Length;
        result.Add(n == 0 ? "" : n.ToString());
        
        for(int i = 0; i < n; i++){
            string leftNum = i == 0 ? "" : i.ToString();
            IList<string> right = GenerateAbbreviations(word.Substring(i+1, n-1-i));
            foreach(string r in right){
                result.Add(leftNum + word[i] + r);
            }
        }
        return result;
    }
}