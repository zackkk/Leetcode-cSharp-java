Find the total area covered by two rectilinear rectangles in a 2D plane.

Each rectangle is defined by its bottom left corner and top right corner as shown in the figure.

Rectangle Area
Assume that the total area is never beyond the maximum possible value of int.


public class Solution {
    // key: how to calculate overlap area
    public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
        int areaABCD = (C - A) * (D - B);
        int areaEFGH = (G - E) * (H - F);
        
        // four sides of the overlap area
        int left = Math.Max(A, E);
        int right = Math.Min(C, G);
        int top = Math.Min(D, H);
        int bottom = Math.Max(B, F);
        
        int areaOverlap = 0;
        if(left < right && bottom < top) {
            areaOverlap = (right - left) * (top - bottom);
        }
        return areaABCD + areaEFGH - areaOverlap;
    }
}