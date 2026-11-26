
public class Graph
{
    public Dictionary<int, List<int>> Adjacence { get; private set; }

    public Graph()
    {

    }

    public void AddVertex(int v)
    {
        if (!Adjacence.ContainsKey(v))
        {
            Adjacence[v] = new List<int>();
        }
    }
    public void AddEdge(int u, int v)
    {
        if (!Adjacence.ContainsKey(u))
        {
            AddVertex(u);
        }
        if (!Adjacence.ContainsKey(v))
        {
            AddVertex(v);
        }
        if(!HasEdge(u, v))
        {
            Adjacence[u].Add(v);
            Adjacence[v].Add(u);
        }

    }
    public bool HasEdge(int u, int v)
    {
        if(Adjacence[u].Contains(v) && Adjacence[v].Contains[u])
        {
            return true;
        }
        return false;
    }
    public void RemoveEdge(int u, int v)
    {
        if(Adjacence.ContainsKey(u) && Adjacence.ContainsKey(v) && HasEdge(u, v))
        {
            Adjacence[u].Remove(v);
            Adjacence[v].Remove(u);
        }
    }
    public void RemoveVertex(int v)
    {

    }
    public void Print()
    {
        
    }
    public List<int> BFS(int start)
    {
        return [];
    }
    public List<int> DFS(int start)
    {
        return [];
    }
    public List<int> ShortestPath(int from, int to)
    {
        return [];
    }
    public int CountPieces()
    {
        return 0;
    }
    public bool HasCycle()
    {
        return false;
    }

}

