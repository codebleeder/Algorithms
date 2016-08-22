package algo.bst_ch12;

/**
 * Created by sharads on 8/20/2016.
 */
public class Tree {
    public Node root;

    public Tree(Node root) {
        this.root = root;
    }

    public Tree(int rootKey) {
        root = new Node(rootKey);
    }

    public void treeInsert(int value){
        Node y = null;
        Node x = this.root;
        while (x != null){
            y = x;
            if (value < x.key) {
                x = x.left;
            }
            else x = x.right;
        }
        Node z = new Node(value);
        z.parent = y;
        if (y == null) this.root = z;
        else if (z.key < y.key) y.left = z;
        else y.right = z;
    }

    public void inorderTreeWalk(Node x){
        if (x != null) {
            inorderTreeWalk(x.left);
            System.out.println(x.key);
            inorderTreeWalk(x.right);
        }
    }

    public Node iterativeTreeSearch(Node x, int k){
        while (x != null && k != x.key){
            if (x.key < k) x = x.right;
            else x = x.left;
        }
        return x;
    }

    public Node treeMin(Node x){
        while (x.left != null) x = x.left;
        return x;
    }

    public Node treeMax(Node x){
        while (x.right != null) x = x.right;
        return x;
    }

    public void transplant(Node u, Node v){
        if (u.parent == null) this.root = v;
        else if (u.parent.left == u) u.parent.left = v;
        else u.parent.right = v;
        if (v != null) v.parent = u.parent;
    }

    public void delete(Node z){
        if (z.left == null) transplant(z, z.right);
        else if (z.right == null) transplant(z, z.left);
        else {
            Node y = treeMin(z.right);
            if (y.parent != z) {
                transplant(y, y.right);
                y.right = z.right;
                y.right.parent = y;
            }
            transplant(z, y);
            y.left = z.left;
            y.left.parent = y;
        }
    }
}
