using System.Collections.Generic;

namespace TOMICZ.DSARunner
{
    public class Graph
    {
        public static void AddEddge(LinkedList<int>[] adjacencyList, int u, int v)
        {
            adjacencyList[u].AddLast(v);
            adjacencyList[v].AddLast(u);
        }
    }
}