package algo.graphs;

/**
 * Created by sharads on 8/26/2016.
 */
public class Test {
    public static void testGraphPrint(){
        int[][] map = {{1},
                {2},
                {0, 3},
                {2}};

        Graph g = new Graph(map);
        Util.printGraph(g);
    }

    public static void testBFS(){
        int[][] map = {
                {1, 4},
                {0, 5},
                {5, 6, 3},
                {2, 6, 7},
                {0},
                {1, 2, 6},
                {5, 2, 3, 7},
                {3, 6}
        };

        Graph g = new Graph(map);
        BreadFirstSearch.bfs(g, g.nodes[1]);
        Util.printPath(g, g.nodes[1], g.nodes[7]);
        System.out.println("graph: ");
        Util.printGraph(g);
    }

    public static boolean testDFS(){
        int[][] map = {
                {1, 3},
                {4},
                {4, 5},
                {1},
                {3},
                {5}
        };
        DFSGraph G = new DFSGraph(map);
        DepthFirstSearch Dfs = new DepthFirstSearch();
        Dfs.dfs(G);

        int[] discoveredExp = {1, 2, 9, 4, 3, 10};
        int[] finishedExp = {8, 7, 12, 5, 6, 11};
        Color[] colorExp = new Color[6];
        for (int i=0; i<6; i++){
            colorExp[i] = Color.Black;
        }
        DFSGraph GExp = new DFSGraph(map, discoveredExp, finishedExp, colorExp);
        boolean flag = true;

        for (int i=0; i<G.nodes.length; i++){
            DFSNode u = G.nodes[i];
            DFSNode v = GExp.nodes[i];
            if (u.equals(v) == false) return false;
        }
        return true;
    }

    public static void graphTests(String testCase){
        switch (testCase){
            case "testGraphPrint":
                    testGraphPrint();
                    break;
            case "testBFS":
                    testBFS();
                    break;
            case "testDFS":
                if (testDFS() == true) System.out.println("DFS test clear!");
                else System.out.println("DFS test fail!");
                break;
        }
    }
}
