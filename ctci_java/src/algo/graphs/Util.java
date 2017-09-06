package algo.graphs;

import java.util.Arrays;

/**
 * Created by sharads on 8/26/2016.
 */
public class Util {
    public static void printGraph(Graph G){
        for(int i=0; i<G.nodes.length; i++){
            String sAdjacent = Arrays.toString(G.nodes[i].adjacent);
            Node parent = G.nodes[i].parent;
            String p;
            if (parent == null) p = "null";
            else p = Integer.toString(parent.key);
            System.out.println(i + "(p: " + p  + ", d: " + G.nodes[i].dist + ")" + ": " + sAdjacent);

        }
    }

    public static void printPath(Graph g, Node s, Node v){
        if (s.key == v.key) System.out.println(s.key);
        else if (v.parent == null) System.out.println("no path from " + s.key + " to " + v.key + " exists");
        else {
            printPath(g, s, v.parent);
            System.out.println(v.key);
        }
    }
}
