You are given a string, s, and a list of words, words, that are all of the same length. 
Find all starting indices of substring(s) in s that is a concatenation of each word in words exactly once and 
without any intervening characters.

For example, given:
s: "barfoothefoobarman"
words: ["foo", "bar"]

You should return the indices: [0,9].
(order does not matter).


public class Solution {
    // straight forward implementation with hashing
    public IList<int> FindSubstring(string s, string[] words) {
        IList<int> result = new List<int>();
        if(s.Length == 0 || words.Length == 0) return result;
        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach(string word in words) dict[word] = (dict.ContainsKey(word) ? dict[word] + 1 : 1);
        
        for(int i = 0; i + words.Length * words[0].Length - 1 < s.Length; i++){
            Dictionary<string, int> tmp = new Dictionary<string, int>(dict);
            bool flag = true; // check at each index
            
            for(int j = 0; j < words.Length; j++){
                string str = s.Substring(i + j * words[0].Length, words[0].Length);
                if(tmp.ContainsKey(str) == false || --tmp[str] < 0) { flag = false; break; }
            }
            if(flag) result.Add(i);
        }
        
        return result;
    }
}