An abbreviation of a word follows the form <first letter><number><last letter>. 
Below are some examples of word abbreviations:

a) it                      --> it    (no abbreviation)

     1
b) d|o|g                   --> d1g

              1    1  1
     1---5----0----5--8
c) i|nternationalizatio|n  --> i18n

              1
     1---5----0
d) l|ocalizatio|n          --> l10n
Assume you have a dictionary and given a word, find whether its abbreviation is unique in the dictionary. 
A words abbreviation is unique if no other word from the dictionary has the same abbreviation.

Example: 
Given dictionary = [ "deer", "door", "cake", "card" ]

isUnique("dear") -> false
isUnique("cart") -> true
isUnique("cane") -> false
isUnique("make") -> true


public class ValidWordAbbr {
    Dictionary<string, string> dict;
    
    public ValidWordAbbr(string[] dictionary) {
        dict = new Dictionary<string, string>();
        foreach(string word in dictionary){
            string key = GetKey(word);
            if(dict.ContainsKey(key)){
                if(dict[key] != word){  // different word, same key
                    dict[key] = "NotUnique"; // set it as not unique
                }
            }
            else{
                dict[key] = word;
            }
        }
    }

    public bool IsUnique(string word) {
        string key = GetKey(word);
        return (dict.ContainsKey(key) == false) || (dict[key] == word);
    }
    
    string GetKey(string str){
        if(str.Length <= 2) return str;
        return str[0] + (str.Length - 2).ToString() + str[str.Length - 1];
    }
}


// Your ValidWordAbbr object will be instantiated and called as such:
// ValidWordAbbr vwa = new ValidWordAbbr(dictionary);
// vwa.IsUnique("word");
// vwa.IsUnique("anotherWord");