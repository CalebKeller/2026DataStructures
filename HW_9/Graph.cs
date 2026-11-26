
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
        if (!HasEdge(u, v))
        {
            Adjacence[u].Add(v);
            Adjacence[v].Add(u);
        }

    }
    public bool HasEdge(int u, int v)
    {
        if (Adjacence[u].Contains(v) && Adjacence[v].Contains[u])
        {
            return true;
        }
        return false;
    }
    public void RemoveEdge(int u, int v)
    {
        if (Adjacence.ContainsKey(u) && Adjacence.ContainsKey(v) && HasEdge(u, v))
        {
            Adjacence[u].Remove(v);
            Adjacence[v].Remove(u);
        }
    }
    public void RemoveVertex(int v)
    {
        if (Adjacence.ContainsKey(v))
        {
            List<int> neighbors = Adjacence[v];
            foreach (int neighbor in neighbors)
            {
                Adjacence[neighbor].Remove(v);
            }
            Adjacence.Remove(v);
        }
    }
    public void Print()
    {

    }
    public List<int> BFS(int start)
    {
        List<int> order = new List<int>();
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
        visited.Add(start);
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            order.Add(current);
            foreach (int next in Adjacence[current])
            {
                if (!visited.Contains(next))
                {
                    visited.Add(next);
                    queue.Enqueue(next);
                }
            }
        }
        return order;
    }
    public List<int> DFS(int start)
    {
        List<int> order = new List<int>();
        HashSet<int> visited = new HashSet<int>();
        DFSVisit(start, visited, order);
        return order;
        void DFSVisit(int current,
        HashSet<int> visited, List<int> order)
        {
            visited.Add(current);
            order.Add(current);
            foreach (int next in adj[current])
            {
                if (!visited.Contains(next))
                    DFSVisit(next, visited, order);
            }
        }
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

