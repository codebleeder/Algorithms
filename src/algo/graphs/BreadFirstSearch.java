package algo.graphs;
import algo.elementary_ds_ch10.Queue;

/**
 * Created by sharads on 8/26/2016.
 */
public class BreadFirstSearch {
    private static final int INFINITY = Integer.MAX_VALUE;

    public void bfs(Graph G, Node root){
        for(Node n: G.nodes){
            n.marked = false;
            n.parent = null;
            n.dist = INFINITY;
        }

        Queue queue = new Queue();
        root.marked = true;
        root.dist = 0;
        root.parent = null;
        queue.enqueue(root.key);
        while (!queue.isEmpty()){
            Node u = G.nodes[queue.dequeue()];
            for (int indexV: u.adjacent){
                Node v = G.nodes[indexV];
                if (v.marked == false){
                    v.marked = true;
                    v.parent = u;
                    v.dist = u.dist + 1;
                    queue.enqueue(v.key);
                }
            }

        }
    }
}
