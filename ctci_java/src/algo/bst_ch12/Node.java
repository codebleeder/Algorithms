package algo.bst_ch12;

/**
 * Created by sharads on 8/20/2016.
 */
public class Node {
    public Node parent;
    public Node left;
    public Node right;
    public int key;

    public Node(int key) {
        this.parent = null;
        this.left = null;
        this.right = null;
        this.key = key;
    }

    public Node(Node parent, Node left, Node right, int key) {
        this.parent = parent;
        this.left = left;
        this.right = right;
        this.key = key;
    }
}
