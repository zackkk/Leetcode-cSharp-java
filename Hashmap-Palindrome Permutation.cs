Given a string, determine if a permutation of the string could form a palindrome.

For example,
"code" -> False, "aab" -> True, "carerac" -> True.


public class Solution {
    // Use hashset to "identify" pairs
    public bool CanPermutePalindrome(string s) {
        HashSet<char> hashset = new HashSet<char>();
        for(int i = 0; i < s.Length; i++) {
            if(hashset.Contains(s[i])) {
                hashset.Remove(s[i]);
            }
            else {
                hashset.Add(s[i]);
            }
        }
        return hashset.Count <= 1;
    }
}