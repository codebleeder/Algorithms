package algo.graphs;

/**
 * Created by Sharad on 9/12/2016.
 */
public class DepthFirstSearch {
    private int time;

    public void dfs(DFSGraph G){

        for (DFSNode u: G.nodes){
            u.parent = null;
        }
        time = 0;

        for (DFSNode u: G.nodes){
           if (u.color == Color.White) {
               DFSVisit(G, u);
           }
        }
    }

    public void DFSVisit(DFSGraph G, DFSNode u){
        time++;
        u.discovered = time;
        u.color = Color.Grey;
        for (int i : u.adjacent){
            DFSNode v = G.nodes[i];
            if (v.color == Color.White){
                v.parent = u;
                DFSVisit(G, v);
            }
        }
        u.color = Color.Black;
        time++;
        u.finished = time;
    }
}
