Implement an iterator to flatten a 2d vector.

For example,
Given 2d vector =

[
  [1,2],
  [3],
  [4,5,6]
]
By calling next repeatedly until hasNext returns false, the order of elements returned by next should be: [1,2,3,4,5,6].


public class Vector2D {

    IList<IList<int>> myvec;
    int row, col;

    public Vector2D(IList<IList<int>> vec2d) {
        myvec = vec2d;
        row = 0;
        col = 0;
    }

    public bool HasNext() {
        while (row < myvec.Count) {
            if(col >= myvec[row].Count) {
                row++;
                col = 0;
            }
            else{
                return true;
            }
        }
        return false;
    }

    public int Next() {
        return myvec[row][col++];
    }
}

/**
 * Your Vector2D will be called like this:
 * Vector2D i = new Vector2D(v1, v2);
 * while (i.HasNext()) v[f()] = i.Next();
 */