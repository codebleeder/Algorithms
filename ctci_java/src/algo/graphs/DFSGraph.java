package algo.graphs;

/**
 * Created by Sharad on 9/21/2016.
 */
public class DFSGraph {
    public DFSNode[] nodes;

    public DFSGraph(){}

    public DFSGraph(int[][] map){
        this.nodes = new DFSNode[map.length];
        for (int i = 0; i < map.length; i++){
            this.nodes[i] = new DFSNode(i, Color.White);
            this.nodes[i].adjacent = map[i];
        }
    }

    public DFSGraph(int[][] map, int[] discovered, int[] finished, Color[] color){
        this.nodes = new DFSNode[map.length];
        for (int i = 0; i < map.length; i++){
            this.nodes[i] = new DFSNode(i, color[i]);
            this.nodes[i].adjacent = map[i];
            this.nodes[i].discovered = discovered[i];
            this.nodes[i].finished = finished[i];
        }
    }
}
