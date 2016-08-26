package algo.graphs;

import java.util.Arrays;

/**
 * Created by sharads on 8/26/2016.
 */
public class Util {
    public static void printGraph(Graph G){
        for(int i=0; i<G.nodes.length; i++){
            String sAdjacent = Arrays.toString(G.nodes[i].adjacent);
            System.out.println(i + ": " + sAdjacent);

        }
    }
}
