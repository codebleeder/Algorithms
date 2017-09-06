package algo.ctci.ch2;

import algo.elementary_ds_ch10.*;

/**
 * Created by sharads on 12/28/2016.
 */
public class TestMisc {
    private Misc m = new Misc();
    private Util u = new Util();

    public void testPrintLinkedListReverse(){
        Integer[] inputArr = {10, 1, 3, 2};
        LinkedList oList = u.buildLinkedList(inputArr);
        m.printLinkedListReverse(u.buildLinkedList(inputArr).head);
    }

    public void testReverseLinkedList2(){
        Integer[] inputArr = {6, 1, 7};
        LinkedList oList = u.buildLinkedList(inputArr);
        u.printLinkedList(oList);
        Node oNewHead = m.reverseLinkedList2(oList.head);
        LinkedList oReversedList = new LinkedList(oNewHead);
        u.printLinkedList(oReversedList);
    }
}
