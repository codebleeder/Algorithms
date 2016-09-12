package algo.graphs;

/**
 * Created by Sharad on 9/12/2016.
 */
public class DepthFirstSearch {
    private int count;

    public  void dfs(Graph G, Node u){
        this.count++;
        u.marked = true;
        for (int indexV: u.adjacent){
            Node v = G.nodes[indexV];
            if (v.marked == false){
                dfs(G, v);
            }
        }
    }
}
