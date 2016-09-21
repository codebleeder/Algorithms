package algo.graphs;

/**
 * Created by sharads on 8/25/2016.
 */
public class Graph {

    public Node[] nodes;

    public Graph(){}

    public Graph(int[][] map){
        this.nodes = new Node[map.length];
        for (int i = 0; i < map.length; i++){
            this.nodes[i] = new Node(i);
            this.nodes[i].adjacent = map[i];
        }
    }

}
