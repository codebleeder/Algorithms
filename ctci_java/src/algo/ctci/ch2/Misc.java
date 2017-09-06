package algo.ctci.ch2;

import algo.elementary_ds_ch10.*;

/**
 * Created by sharads on 12/28/2016.
 * Some additional functions written for learning purposes
 */
public class Misc {
    public void printLinkedListReverse(Node oNode){
        if (oNode == null) return;
        printLinkedListReverse(oNode.next);
        System.out.println(oNode.data);
    }

    private Node oHead = new Node();
    public void reverseLinkedList(Node oNode){
        if (oNode.next == null) {
            oHead = oNode;
            return;
        }
        reverseLinkedList(oNode.next);
        Node x = oNode.next;
        x.next = oNode;
        oNode.next = null;
    }

    public Node reverseLinkedList2(Node oNode){
        if (oNode.next == null){
            return oNode;
        }
        Node oNode2 = reverseLinkedList2(oNode.next);
        oNode.next.next = oNode;
        oNode.next = null;
        return oNode2;
    }
}
