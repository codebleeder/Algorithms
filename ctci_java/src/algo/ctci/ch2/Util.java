package algo.ctci.ch2;


/**
 * Created by Sharad on 10/23/2016.
 */
public class Util {
    public LinkedList buildLinkedList(Integer[] arr){
        LinkedList l = new LinkedList();

        for (int i=0; i<arr.length; i++){
            l.insert(arr[i]);
        }
        return l;
    }

    public void printLinkedList(LinkedList l){
        Node n = l.head;
        while (n != null) {
            System.out.print(n.data + "->");
            n = n.next;
        }
        System.out.print("null");
        System.out.println("");
    }

    public Node getTailNode(LinkedList ll){
        Node x = ll.head;
        Node y = new Node();
        while (x != null){
            y = x;
            x = x.next;
        }
        return y;
    }

    public Node getNthNode(LinkedList ll, int n){
        try{
            Node x = ll.head;
            int i = 1;
            while (i < n){
                x = x.next;
                i++;
            }
            return x;
        }
        catch (Exception ex){
            System.out.println(ex.getMessage());
        }
        return null;
    }
}
