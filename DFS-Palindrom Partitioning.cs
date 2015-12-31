Given a string s, partition s such that every substring of the partition is a palindrome.

Return all possible palindrome partitioning of s.

For example, given s = "aab",
Return

  [
    ["aa","b"],
    ["a","a","b"]
  ]


public class Solution {
    // classic dfs
    public IList<IList<string>> Partition(string s) {
        IList<IList<string>> result = new List<IList<string>>();
        IList<string> list = new List<string>();
        dfs(result, list, s, 0);
        return result;
    }
    
    void dfs(IList<IList<string>> result, IList<string> list, string s, int cur){
        if(cur == s.Length){
            result.Add(new List<string>(list));
            return;
        }
        
        for(int i = cur; i < s.Length; i++){
            string substr = s.Substring(cur, i - cur + 1); // (index, length)
            if(IsPalindrome(substr)){
                list.Add(substr);
                dfs(result, list, s, i + 1);
                list.RemoveAt(list.Count - 1); // remove the last element
            }
        }
    }
    
    bool IsPalindrome(string s){
        int i = 0, j = s.Length - 1;
        for( ; i < j; i++, j--){
            if(s[i] != s[j]) return false;
        }
        return true;
    }
}