package algo.ctci.ch2;


import java.util.Arrays;

/**
 * Created by Sharad on 10/23/2016.
 */
public class TestCh2 {
    private Ch2 ch2 = new Ch2();
    private Util u = new Util();

    public void testRemoveDups1(){
        Integer[] inputArr = {10, 1, 2, 3, 10, 3, 2, 10};
        Integer[] expectedArr = {10, 1, 2, 3};

        LinkedList l = u.buildLinkedList(inputArr);
        ch2.removeDups1(l.head);
        System.out.println("expected arr: " + Arrays.toString(expectedArr));
        System.out.println("output linked list:");
        u.printLinkedList(l);

    }

    public void testRemoveDups1b() {
        Integer[] inputArr = {10, 1, 2, 3, 10, 3, 2, 10};
        Integer[] expectedArr = {10, 1, 2, 3};

        LinkedList l = u.buildLinkedList(inputArr);
        ch2.removeDups1b(l.head);
        System.out.println("expected arr: " + Arrays.toString(expectedArr));
        System.out.println("output linked list:");
        u.printLinkedList(l);
    }

    public boolean testReturnKthToLast2() {
        Integer[] inputArr = {10, 1, 2, 3, 10, 3, 2, 10};
        LinkedList l = u.buildLinkedList(inputArr);
        Node nOut = ch2.returnKthToLast2(l.head, 2);
        return nOut.data == 2;
    }


    public boolean testDeleteMiddleNode3(){
        Integer[] inputArr = {1, 2, 3, 2, 10};
        LinkedList l = u.buildLinkedList(inputArr);
        Node n = l.head;
        while (n.data != 3) n = n.next;
        boolean f1 = ch2.deleteMiddleNode3(n);
        while (n.data != 10) n = n.next;
        boolean f2 = ch2.deleteMiddleNode3(n);
        return f1 && !f2;
    }

    public void testPartition4(){
        Integer[] inputArr = {3, 5, 8, 5, 10, 2, 1};
        LinkedList l = u.buildLinkedList(inputArr);
        LinkedList lOut = ch2.partition4(5, l.head);
        u.printLinkedList(lOut);
    }

    public void testSumLists5(){
        Integer[] oArr1 = {7, 1, 6};
        LinkedList oList1 = u.buildLinkedList(oArr1);
        Integer[] oArr2 = {5, 9, 2};
        LinkedList oList2 = u.buildLinkedList(oArr2);
        u.printLinkedList(oList1);
        u.printLinkedList(oList2);
        LinkedList oListOut = ch2.sumLists5(oList1, oList2);
        u.printLinkedList(oListOut);
        Integer[] oArrExp = {9, 1, 2};
        Node oNode = oListOut.head;

    }

    public void testSumLists5b(){
        Integer[] oArr1 = {6, 1, 7};
        LinkedList oList1 = u.buildLinkedList(oArr1);
        Integer[] oArr2 = {2, 9, 5};
        LinkedList oList2 = u.buildLinkedList(oArr2);
        u.printLinkedList(oList1);
        u.printLinkedList(oList2);
        LinkedList oListOut = ch2.sumLists5(oList1, oList2);
        u.printLinkedList(oListOut);
        Integer[] oArrExp = {9, 1, 2};
        Node oNode = oListOut.head;

    }
}
