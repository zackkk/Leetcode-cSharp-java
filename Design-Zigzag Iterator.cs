Given two 1d vectors, implement an iterator to return their elements alternately.

For example, given two 1d vectors:

v1 = [1, 2]
v2 = [3, 4, 5, 6]
By calling next repeatedly until hasNext returns false, 
the order of elements returned by next should be: [1, 3, 2, 4, 5, 6].

Follow up: What if you are given k 1d vectors? How well can your code be extended to such cases?

Clarification for the follow up question - Update (2015-09-18):
The "Zigzag" order is not clearly defined and is ambiguous for k > 2 cases. 
If "Zigzag" does not look right to you, replace "Zigzag" with "Cyclic". 

For example, given the following input:

[1,2,3]
[4,5,6,7]
[8,9]
It should return [1,4,8,2,5,9,3,6,7].


public class ZigzagIterator {
    // extract the current list and then add it at the end
    IList<IList<int>> lists;

    public ZigzagIterator(IList<int> v1, IList<int> v2) {
        lists = new List<IList<int>>();
        if(v1.Count > 0) lists.Add(v1);
        if(v2.Count > 0) lists.Add(v2);
    }

    public bool HasNext() {
        return lists.Count > 0;
    }

    public int Next() {
        List<int> cur = new List<int>(lists[0]);
        lists.RemoveAt(0);
        int val = cur[0];
        cur.RemoveAt(0);
        if(cur.Count > 0) lists.Add(cur);
        return val;
    }
}

/**
 * Your ZigzagIterator will be called like this:
 * ZigzagIterator i = new ZigzagIterator(v1, v2);
 * while (i.HasNext()) v[f()] = i.Next();
 */