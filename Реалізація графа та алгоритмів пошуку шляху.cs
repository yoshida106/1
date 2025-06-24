using System;
using System.Collections.Generic;

public class Graph
{
    private Dictionary<int, List<int>> adjacencyList;
    private Dictionary<int, List<(int node, int weight)>> weightedAdjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<int, List<int>>();
        weightedAdjacencyList = new Dictionary<int, List<(int, int)>>();
    }

    public void AddVertex(int vertex)
    {
        if (!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList[vertex] = new List<int>();
            weightedAdjacencyList[vertex] = new List<(int, int)>();
        }
    }

    public void AddEdge(int source, int destination)
    {
        if (!adjacencyList.ContainsKey(source))
            AddVertex(source);
        if (!adjacencyList.ContainsKey(destination))
            AddVertex(destination);

        adjacencyList[source].Add(destination);
        adjacencyList[destination].Add(source); 
    }

    public void AddWeightedEdge(int source, int destination, int weight)
    {
        if (!weightedAdjacencyList.ContainsKey(source))
            AddVertex(source);
        if (!weightedAdjacencyList.ContainsKey(destination))
            AddVertex(destination);

        weightedAdjacencyList[source].Add((destination, weight));
        weightedAdjacencyList[destination].Add((source, weight)); 

    public List<int> BFS(int start, int end)
    {
        var visited = new Dictionary<int, bool>();
        var previous = new Dictionary<int, int>();
        var queue = new Queue<int>();
        var path = new List<int>();

        foreach (var vertex in adjacencyList.Keys)
        {
            visited[vertex] = false;
            previous[vertex] = -1;
        }

        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current == end)
            {
                int at = end;
                while (at != -1)
                {
                    path.Add(at);
                    at = previous[at];
                }
                path.Reverse();
                return path;
            }

            foreach (var neighbor in adjacencyList[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    previous[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return path;
    }

    public List<int> Dijkstra(int start, int end)
    {
        var distances = new Dictionary<int, int>();
        var previous = new Dictionary<int, int>();
        var priorityQueue = new SortedSet<(int distance, int node)>();
        var path = new List<int>();

        foreach (var vertex in weightedAdjacencyList.Keys)
        {
            if (vertex == start)
                distances[vertex] = 0;
            else
                distances[vertex] = int.MaxValue;

            previous[vertex] = -1;
            priorityQueue.Add((distances[vertex], vertex));
        }

        while (priorityQueue.Count > 0)
        {
            var (currentDistance, current) = priorityQueue.Min;
            priorityQueue.Remove((currentDistance, current));

            if (current == end)
            {
                int at = end;
                while (at != -1)
                {
                    path.Add(at);
                    at = previous[at];
                }
                path.Reverse();
                return path;
            }

            foreach (var (neighbor, weight) in weightedAdjacencyList[current])
            {
                int newDistance = currentDistance + weight;
                if (newDistance < distances[neighbor])
                {
                    priorityQueue.Remove((distances[neighbor], neighbor));
                    distances[neighbor] = newDistance;
                    previous[neighbor] = current;
                    priorityQueue.Add((distances[neighbor], neighbor));
                }
            }
        }

        return path; 
    }
}