package algo.ctci;

/**
 * Created by Sharad on 9/27/2016.
 */
public class TestCh1 {
    private Ch1 ch1;

    public TestCh1(){
        ch1 = new Ch1();
    }

    public boolean testIsUnique1(){
        // test 1: you have more than 128 characters in input.
        // Should return false

        // all unique chars
        String s1 = "1234567890abcdefghijklmnopqrstuvwxyz";
        // one repeating char
        String s2 = "1234567890abcdefghijklmnopqrstuvwxyza";


        boolean f1 = ch1.isUnique1(s1);
        boolean f2 = ch1.isUnique1(s2);
        return f1 && !f2;
    }

    public boolean testCheckPermutation2(){
        boolean f1 = ch1.checkPermutation2("amd", "dma");
        boolean f2 = ch1.checkPermutation2("amd", "abc");
        boolean f3 = ch1.checkPermutation2("amd", "dmaa");
        return f1 && !f2 && !f3;
    }

    public boolean testCheckPermutation2b(){
        boolean f1 = ch1.checkPermutation2b("amd", "dma");
        boolean f2 = ch1.checkPermutation2b("amd", "abc");
        boolean f3 = ch1.checkPermutation2b("amd", "dmaa");
        return f1 && !f2 && !f3;
    }

    public boolean testUrlIfy3(){
        boolean f1 = (ch1.urlIfy3("mr john smith    ".toCharArray(), 13)).equals("mr%20john%20smith");
        return f1;
    }

    public boolean testPalindromePermutation4(){
        boolean f1 = ch1.palindromePermutation4("tact coa");
        boolean f2 = ch1.palindromePermutation4("malayalam");
        boolean f3 = ch1.palindromePermutation4("abc");
        boolean f4 = ch1.palindromePermutation4("aaiiaallaa");
        return f1 && f2 && !f3 && f4;
    }

    public boolean testOneAway5(){
        boolean f1 = ch1.oneAway5("pale", "ple");
        boolean f2 = ch1.oneAway5("pales", "pale");
        boolean f3 = ch1.oneAway5("pale", "bale");
        boolean f4 = ch1.oneAway5("pale", "bake");
        return f1 && f2 && f3 && !f4;
    }

    public void TestAll(String sTestName){
        switch (sTestName){
            case "isUnique1":
                if (testIsUnique1()) System.out.println("isUnique: pass!");
                else System.out.println("isUnique: Fail!");
                break;

            case "checkPermutation2":
                if (testCheckPermutation2()) System.out.println("checkPermutation2: pass!");
                else System.out.println("checkPermutation2: Fail!");
                break;

            case "checkPermutation2b":
                if (testCheckPermutation2b()) System.out.println("checkPermutation2b: pass!");
                else System.out.println("checkPermutation2b: Fail!");
                break;

            case "urlIfy3":
                if (testUrlIfy3()) System.out.println("urlIfy3: pass!");
                else System.out.println("urlIfy3: Fail!");
                break;

            case "palindromePermutation4":
                if (testPalindromePermutation4()) System.out.println("palindromePermutation4: pass!");
                else System.out.println("palindromePermutation4: Fail!");
                break;

            case "oneAway5":
                if (testOneAway5()) System.out.println("oneAway5: pass!");
                else System.out.println("oneAway5: Fail!");
                break;
        }
    }
}