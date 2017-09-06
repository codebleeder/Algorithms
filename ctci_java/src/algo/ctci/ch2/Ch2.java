package algo.ctci.ch2;
import java.util.HashSet;
import java.util.ArrayList;

import static java.lang.Math.abs;

/**
 * Created by Sharad on 10/23/2016.
 */
public class Ch2 {
    public void removeDups1(Node head){
        HashSet<Integer> set = new HashSet<>();
        Node n = head;
        Node prev = null;

        while (n != null){
            if (set.contains(n.data)) {
                prev.next = n.next;

            }
            else {
                set.add(n.data);
                prev = n;
            }
            n = n.next;
        }
    }

    public void removeDups1b(Node n){
        while (n != null) {
            Node runner = n.next;
            Node prev = n;
            while (runner != null){
                if (runner.data == n.data) {
                    prev.next = runner.next;
                    runner = runner.next;
                    //runner = runner.next.next;
                }
                else {
                    prev = runner;
                    runner = runner.next;
                }
            }
            n = n.next;
        }
    }

    public Node returnKthToLast2(Node n, int k) {
        Node kth = null;
        Node x = n;
        int count = 1;
        while (x != null) {
            if (count == k) {
                kth = n;
            }
            else if (count > k) {
                kth = kth.next;
            }
            x = x.next;
            count++;
        }
        return kth;
    }

    public boolean deleteMiddleNode3(Node n) {
        if (n == null || n.next == null) return false;
        n.data = n.next.data;
        n.next = n.next.next;
        return true;
    }

    public LinkedList partition4(int x, Node head) {
        Node i = head;
        LinkedList oLesser = new LinkedList();
        LinkedList oHigher = new LinkedList();



        while (i != null) {
            if (i.data >= x) oHigher.insert(i.data);
            else oLesser.insert(i.data);
            i = i.next;
        }
        Node nLesserX = oLesser.head;
        Node nLesserY = new Node();

        while(nLesserX != null) {
            nLesserY = nLesserX;
            nLesserX = nLesserX.next;
        }

        nLesserY.next = oHigher.head;
        return oLesser;
    }

    public LinkedList sumLists5(LinkedList oList1, LinkedList oList2) {
        int carry = 0;
        int digit = 0;
        LinkedList oListOut = new LinkedList();

        Node oNode1 = oList1.head;
        Node oNode2 = oList2.head;
        while (oNode1 != null) {
            digit = oNode1.data + oNode2.data + carry;
            if (digit > 10) {
                carry = 1;
                digit = digit % 10;
            }
            else carry = 0;
            oListOut.insertNode(digit);
            oNode1 = oNode1.next;
            oNode2 = oNode2.next;
        }
        return oListOut;
    }

    public boolean palindrome6(LinkedList oList) {
        if (oList == null) return false;

        Node oNode1 = oList.head;
        Node oNodeTemp = oList.head;
        ArrayList<Integer> al = new ArrayList<Integer>();

        while (oNodeTemp != null) {
            oNode1 = oNodeTemp;
            oNodeTemp = oNodeTemp.next;
            al.add(oNode1.data);
        }

        Integer[] iArr = al.toArray(new Integer[0]);
        int iLength = iArr.length;
        for(int i=0; i<iLength; i++) {
            if (iArr[i] != iArr[iLength-i-1]) return false;
        }
        return true;

    }

    public boolean palindrome6b(LinkedList oList) {
        if (oList == null) return false;
        LinkedList oListTemp =  (LinkedList) oList.cloneL();
        LinkedList oReversedList = new LinkedList(reverseLinkedList(oListTemp.head));
        return isEqualLinkedLists(oList, oReversedList);
    }

    private Node reverseLinkedList(Node oNode) {
        if (oNode.next == null) return oNode;
        Node oNode2 = reverseLinkedList(oNode.next);
        oNode.next.next = oNode;
        oNode.next = null;
        return oNode2;
    }

    private boolean isEqualLinkedLists(LinkedList oList1, LinkedList oList2) {
        Node oNode1 = oList1.head;
        Node oNode2 = oList2.head;
        while (oNode1 != null) {
            if (oNode1.data != oNode2.data) return false;
            oNode1 = oNode1.next;
            oNode2 = oNode2.next;
        }
        return oNode1 == null && oNode2 == null;
    }



    public Node intersection7(LinkedList ll1, LinkedList ll2) {
        int iLength1 = getLength(ll1);
        int iLength2 = getLength(ll2);
        LinkedList llLong = new LinkedList();
        LinkedList llShort = new LinkedList();
        int iDiff = abs(iLength1-iLength2);

        if (iLength1 > iLength2) {
            llLong = ll1;
            llShort = ll2;
        }
        else if (iLength1 < iLength2) {
            llLong = ll2;
            llShort = ll1;
        }
        else {
            llLong = ll1;
            llShort = ll2;
        }

        Node n1 = llLong.head;
        Node n2 = llShort.head;
        while(iDiff != 0){
            n1 = n1.next;
            iDiff--;
        }

        while(n1 != null){
            if(n1.equals(n2)) return n1;
            n1 = n1.next;
            n2 = n2.next;
        }
        return null;
    }

    private int getLength(LinkedList ll){
        int iLength = 0;
        Node x = ll.head;
        Node y = new Node();
        while (x != null) {
            y = x;
            x = x.next;
            iLength++;
        }
        return iLength;
    }

    public Node loopDetection8(LinkedList x){
        Node slowRunner = new Node();
        Node fastRunner = new Node();
        slowRunner = x.head;
        fastRunner = x.head;
        while (slowRunner != null || fastRunner != null){
            slowRunner = slowRunner.next;
            fastRunner = fastRunner.next.next;
            if (slowRunner == fastRunner) break;
        }

        if (slowRunner == fastRunner){
            slowRunner = x.head;
            while (slowRunner != fastRunner){
                slowRunner = slowRunner.next;
                fastRunner = fastRunner.next;
            }
            return slowRunner;
        }
        else return null;
    }
}
