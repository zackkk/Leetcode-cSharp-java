Given a collection of intervals, merge all overlapping intervals.

For example,
Given [1,3],[2,6],[8,10],[15,18],
return [1,6],[8,10],[15,18].


/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution {
    public IList<Interval> Merge(IList<Interval> intervals) {
        List<Interval> myintervals = new List<Interval>(intervals);
        myintervals.Sort(new Comparison<Interval>((x, y) => x.start - y.start));
        IList<Interval> result = new List<Interval>();
        if (myintervals.Count == 0) return result;

        Interval cur = myintervals[0];
        for (int i = 1; i < myintervals.Count; i++) {
            if (myintervals[i].start <= cur.end) { // overlap
                cur.end = Math.Max(myintervals[i].end, cur.end);
            }
            else { // not-overlap
                result.Add(cur);
                cur = myintervals[i];
            }
        }
        result.Add(cur);
        return result;
    }
}