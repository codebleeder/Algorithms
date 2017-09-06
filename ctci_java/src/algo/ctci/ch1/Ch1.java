package algo.ctci.ch1;

/**
 * Created by Sharad on 9/27/2016.
 */
public class Ch1 {

    public boolean isUnique1(String s){
        // assuming that the character set is 36 (26 alphabet + 10 digits)
        // for practical testing purposes
        if (s.length() > 36) return false;

        boolean[] charSet = new boolean[128];

        for (int i = 0; i<s.length(); i++){
            int iChar = s.charAt(i);
            if (charSet[iChar] == true) return false;
            else charSet[iChar] = true;
        }
        return true;
    }

    private String sortString(String s){
        char[] cArr = s.toCharArray();
        java.util.Arrays.sort(cArr);
        return new String(cArr);
    }

    public boolean checkPermutation2(String s1, String s2){
        if (s1.length() != s2.length()) return false;
        return sortString(s1).equals(sortString(s2));
    }

    public boolean checkPermutation2b(String s1, String s2){
        if (s1.length() != s2.length()) return false;
        int[] counter = new int[128];
        for (char c: s1.toCharArray()){
            counter[c]++;
        }
        for (char c1: s2.toCharArray()){
            counter[c1]--;
            if (counter[c1] < 0) return false;
        }
        return true;
    }

    public String urlIfy3(char[] cArr, int iLength){
        for (int i=iLength-1, j=cArr.length-1; i>=0; i--){
            if (cArr[i] != ' ') {
                cArr[j] = cArr[i];
                j--;
            }
            else {
                cArr[j] = '0'; j--;
                cArr[j] = '2'; j--;
                cArr[j] = '%'; j--;
            }
        }
        return new String(cArr);
    }

    public boolean palindromePermutation4(String s){
        int[] counter = new int[128];
        int singlesCount = 0;

        for (char c: s.toCharArray()){
            if (c != ' ') {
                counter[c]++;

            }

        }

        for (char c1: s.toCharArray()){
            if (c1 != ' ' && counter[c1] == 1) singlesCount++;
            else if (c1 != ' ' && counter[c1] % 2 != 0) return false;
        }
        return singlesCount < 2;
    }

    public boolean oneAway5(String s1, String s2){
        String sShort, sLong;
        int iDiffCount = 0;

        if (Math.abs(s1.length() - s2.length()) > 1) return false;

        if (s1.length() > s2.length()) {
            sLong = s1;
            sShort = s2;
        }
        else {
            sLong = s2; sShort = s1;
        }

        for (char c: sShort.toCharArray()){
            if(sLong.indexOf(c) < 0) iDiffCount++;
        }

        return iDiffCount <= 1;
    }

    public String stringCompression6(String s){
        StringBuilder sb = new StringBuilder();
        int counter = 0;
        char[] cS = s.toCharArray();
        char current = ' ';

        for (int i=0; i<cS.length; i++){
            if (i == 0) {
                current = cS[i];
                //sb.append(current);
                counter++;
            }

            else if (current != cS[i]){
                sb.append(current);
                sb.append(counter);
                counter = 1;
                current = cS[i];
            }
            else {
                counter++;
            }
        }

        sb.append(current);
        sb.append(counter);

        if (sb.length() >= cS.length) return s;
        else return sb.toString();
    }

    public int[][] rotateMatrix7(int[][] m){
        int n = m[0].length;
        for (int layer = 0; layer < n/2; layer++)
        {
            int first = layer;
            int last = n - 1 - layer;
            for (int i = first; i < last; i++){
                int offset = i-first;
                int tmp = m[first][i];
                m[first][i] = m[last-offset][first];
                m[last-offset][first] = m[last][last-offset];
                m[last][last-offset] = m[i][last];
                m[i][last] = tmp;
            }
        }
        return m;
    }


    private void nullifyRow (int[][] m, int row){
        for (int i=0; i < m[0].length; i++)
            m[row][i] = 0;
    }

    private void nullifyCol (int[][] m, int col){
        for(int i=0; i<m.length; i++)
            m[i][col] = 0;
    }

    public int[][] zeroMatrix8(int[][] m){
        boolean[] row = new boolean[m.length];
        boolean[] col = new boolean[m[0].length];

        for (int i=0; i < m.length; i++){
            for (int j=0; j < m[0].length; j++){
                if (m[i][j] == 0) {
                    row[i] = true;
                    col[j] = true;
                }
            }
        }

        // nullify all rows
        for (int i=0; i < row.length; i++)
            if (row[i] == true) nullifyRow(m, i);

        // Nullify all columns
        for (int j=0; j < col.length; j++)
            if (col[j] == true) nullifyCol(m, j);


        return m;
    }

    public boolean stringRotation9(String s1, String s2){
        if (s1.length() != s2.length()) return false;

        if (s1.length() > 0){
            String s1s1 = s1 + s1;
            return s1s1.toLowerCase().contains(s1.toLowerCase());
        }

        return false;
    }
}
