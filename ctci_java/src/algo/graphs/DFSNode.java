package algo.graphs;

public class DFSNode {
    public Color color;
    public int discovered;
    public int finished;
    public int[] adjacent;
    public DFSNode parent;

    public DFSNode(){ }

    public DFSNode(int key, Color color){
        this.color = color;
    }

    public boolean equals(DFSNode v){
        return (this.color == v.color &&
        this.discovered == v.discovered &&
        this.finished == v.finished);
    }
}
