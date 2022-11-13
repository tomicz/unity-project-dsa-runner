using System.Collections.Generic;
using TOMICZ.Debugger;

namespace TOMICZ.DSARunner
{
    public class Graph
    {
        public void AddEdge(LinkedList<int>[] adjacencyList, int u, int v)
        {
            adjacencyList[u].AddLast(v);
            adjacencyList[v].AddLast(u);

            //RuntimeConsole.Log($"Added vertex: {u} with edge to {v}");
            //RuntimeConsole.Log($"Added vertex: {v} with edge to {u}");
        }

        public void PrintGraph(LinkedList<int>[] adjacencyList)
        {
            for (int i = 0; i < adjacencyList.Length; i++)
            {
                RuntimeConsole.Log("\n Adjacency list of vertex " + i);
                RuntimeConsole.Header("Head");

                foreach (var vertex in adjacencyList[i])
                {
                    RuntimeConsole.Log($" -> {vertex}");
                }
            }
        }
    }
}