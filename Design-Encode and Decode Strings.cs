Design an algorithm to encode a list of strings to a string. 
The encoded string is then sent over the network and is decoded back to the original list of strings.

Machine 1 (sender) has the function:

string encode(vector<string> strs) {
  // ... your code
  return encoded_string;
}

Machine 2 (receiver) has the function:
vector<string> decode(string s) {
  //... your code
  return strs;
}

So Machine 1 does:
string encoded_string = encode(strs);
and Machine 2 does:
vector<string> strs2 = decode(encoded_string);

strs2 in Machine 2 should be the same as strs in Machine 1.

Implement the encode and decode methods.

Note:
The string may contain any possible characters out of 256 valid ascii characters. 
Your algorithm should be generalized enough to work on any possible characters.
Do not use class member/global/static variables to store states. Your encode and decode algorithms should be stateless.
Do not rely on any library method such as eval or serialize methods. You should implement your own encode/decode algorithm.


public class Codec {
    // encode length + splitter for decoding

    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs) {
        StringBuilder result = new StringBuilder();
        foreach(string str in strs){
            result.Append(str.Length).Append('#').Append(str);
        }
        return result.ToString();
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s) {
        IList<string> result = new List<string>();
        int start = 0;
        while(start < s.Length){
            // string.IndexOf would return first occurance as default, can't set indexFrom for locating the second "#"
            int splitterIndex = start;
            for( ; splitterIndex < s.Length; splitterIndex++) { 
                if(s[splitterIndex] == '#'){
                    break;
                }
            }
            int len = Int32.Parse(s.Substring(start, splitterIndex - start));
            result.Add(s.Substring(splitterIndex + 1, len));
            start = splitterIndex + len + 1;
        }
        return result;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));