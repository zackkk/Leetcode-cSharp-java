Design and implement a TwoSum class. It should support the following operations: add and find.

add - Add the number to an internal data structure.
find - Find if there exists any pair of numbers which sum is equal to the value.

For example,
add(1); add(3); add(5);
find(4) -> true
find(7) -> false


public class TwoSum {
    // may add multiple times
    Dictionary<int, int> dict = new Dictionary<int, int>();

    // Add the number to an internal data structure.
    public void Add(int number) {
        dict[number] = dict.ContainsKey(number) ? dict[number] + 1 : 1;
    }

    // Find if there exists any pair of numbers which sum is equal to the value.
    public bool Find(int value) {
        foreach(KeyValuePair<int, int> entry in dict) {
            int expected = value - entry.Key;
            if(entry.Key == expected && entry.Value > 1) return true; // special case
            if(entry.Key != expected && dict.ContainsKey(expected)) return true;
        }
        return false;
    }
}


// Your TwoSum object will be instantiated and called as such:
// TwoSum twoSum = new TwoSum();
// twoSum.Add(number);
// twoSum.Find(value);