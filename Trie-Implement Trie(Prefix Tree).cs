Implement a trie with insert, search, and startsWith methods.

Note:
You may assume that all inputs are consist of lowercase letters a-z.


class TrieNode {
    // Initialize your data structure here -> list is not efficient for looking up a child with certain letter
    public bool isWord; // end at this node
    public TrieNode[] children = new TrieNode[26];
    public TrieNode() {}
}

public class Trie {
    private TrieNode root;

    public Trie() {
        root = new TrieNode();
    }

    // Inserts a word into the trie.
    public void Insert(String word) {
        TrieNode cur = root;
        for(int i = 0; i < word.Length; i++){
            TrieNode child = cur.children[word[i] - 'a'];
            if(child == null){
                cur.children[word[i] - 'a'] = new TrieNode(); // bug happened: can't use child since child is null
            }
            cur = cur.children[word[i] - 'a'];
        }
        cur.isWord = true;
    }

    // Returns if the word is in the trie.
    public bool Search(string word) {
        TrieNode cur = root;
        for(int i = 0; i < word.Length; i++){
            TrieNode child = cur.children[word[i] - 'a'];
            if(child == null){
                return false;
            }
            cur = child;
        }
        return cur.isWord;
    }

    // Returns if there is any word in the trie
    // that starts with the given prefix.
    public bool StartsWith(string word) {
        TrieNode cur = root;
        for(int i = 0; i < word.Length; i++){
            TrieNode child = cur.children[word[i] - 'a'];
            if(child == null){
                return false;
            }
            cur = child;
        }
        return true;
    }
}

// Your Trie object will be instantiated and called as such:
// Trie trie = new Trie();
// trie.Insert("somestring");
// trie.Search("key");