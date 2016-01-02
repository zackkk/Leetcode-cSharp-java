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
    // The solution of "Read N Characters Given Read4 II" works for this question as well  
    int buf4Count = 0;
    int buf4Ptr = 0;
    char[] buf4 = new char[4];
    
    public int Read(char[] buf, int n) {
        int hasRead = 0;
        while(hasRead < n){
            if(buf4Count == 0) {  // no data left in buf4
                buf4Count = Read4(buf4);
            }
            if(buf4Count == 0) break; // no data in the file
            
            while(buf4Ptr < buf4Count && hasRead < n){
                buf[hasRead++] = buf4[buf4Ptr++];
            }
            
            if(buf4Ptr >= buf4Count) { buf4Count = 0; buf4Ptr = 0; } // reset buf4
        }
        return hasRead;
    }
}