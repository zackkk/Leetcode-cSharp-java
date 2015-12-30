Design a data structure that supports the following two operations:

void addWord(word)
bool search(word)
search(word) can search a literal word or a regular expression string containing only letters a-z 
or .. A . means it can represent any one letter.

For example:

addWord("bad")
addWord("dad")
addWord("mad")
search("pad") -> false
search("bad") -> true
search(".ad") -> true
search("b..") -> true


class TrieNode {
    // list is not efficient for looking up a child with certain letter
    public string item = ""; // end at this node
    public TrieNode[] children = new TrieNode[26];
    public TrieNode() {}
}

// Same as question "Implement Trie (Prefix Tree)"
public class WordDictionary {
    
    TrieNode root;
    public WordDictionary() {
        root = new TrieNode();
    }

    // Adds a word into the data structure.
    public void AddWord(String word) {
        TrieNode cur = root;
        for(int i = 0; i < word.Length; i++){
            TrieNode child = cur.children[word[i] - 'a'];
            if(child == null){
                cur.children[word[i] - 'a'] = new TrieNode(); // bug happened: can't use "child" since "child" is null
            }
            cur = cur.children[word[i] - 'a'];
        }
        cur.item = word;
    }

    // Returns if the word is in the data structure. A word could
    // contain the dot character '.' to represent any one letter.
    public bool Search(string word) {
        return match(word.ToCharArray(), 0, root);
    }
    
    bool match(char[] chars, int cur, TrieNode root){
        if(cur == chars.Length) return root.item != ""; // it can't be a "intermediate" node
        if(chars[cur] != '.'){
            return (root.children[chars[cur] - 'a'] != null) && (match(chars, cur + 1, root.children[chars[cur] - 'a'])); 
        }
        else{
            for(int i = 0; i < 26; i++){
                if(root.children[i] != null){
                    if(match(chars, cur + 1, root.children[i])){
                        return true;
                    }
                }
            }
        }
        return false;
    }
}

// Your WordDictionary object will be instantiated and called as such:
// WordDictionary wordDictionary = new WordDictionary();
// wordDictionary.AddWord("word");
// wordDictionary.Search("pattern");