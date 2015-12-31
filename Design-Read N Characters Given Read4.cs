The API: int read4(char *buf) reads 4 characters at a time from a file.

The return value is the actual number of characters read. For example, 
it returns 3 if there is only 3 characters left in the file.

By using the read4 API, implement the function int read(char *buf, int n) that reads n characters from the file.

Note:
The read function will only be called once for each test case.


/* The Read4 API is defined in the parent class Reader4.
      int Read4(char[] buf); */

public class Solution : Reader4 {
    /**
     * @param buf Destination buffer
     * @param n   Maximum number of characters to read
     * @return    The number of characters read
     */
    // compare data available & data wanted
    public int Read(char[] buf, int n) {
        char[] buf4 = new char[4];
        int hasRead = 0;
        while(hasRead < n){
            int a = Read4(buf4);   // data available
            int b = n - hasRead;   // data wanted
            for(int i = 0; i < Math.Min(a, b); i++){
                buf[hasRead+i] = buf4[i];
            }
            hasRead += Math.Min(a, b);
            if(a < 4) return hasRead; // file doesn't have enough data;
        }
        return n;
    }
}