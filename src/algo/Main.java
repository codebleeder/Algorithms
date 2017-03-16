package algo;

import algo.ctci.ch2.TestCh2;
import algo.ctci.ch2.TestLinkedList;
import algo.ctci.ch2.TestMisc;
import algo.ctci.ch3.TestStack;
import algo.ctci.ch3.TestCh3;

public class Main {

    public static void main(String[] args) {
       TestCh3 t = new TestCh3();
        boolean b = t.testFixedMultiStack();
        if (b == true) System.out.println("pass!");
        else System.out.println("fail!");
    }
}
