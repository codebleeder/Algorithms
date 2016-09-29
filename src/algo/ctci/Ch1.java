package algo.ctci;

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
}
