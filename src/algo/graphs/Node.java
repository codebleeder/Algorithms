package algo.graphs;

/**
 * Created by sharads on 8/25/2016.
 */
public class Node {
    public int key;
    public boolean marked;
    public int dist;
    public Node parent;
    public int[] adjacent;

    public Node(){}

    public Node(int key){
        this.key = key;
        this.marked = false;
        this.dist = -1;
        this.parent = null;

    }
}
