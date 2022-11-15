using System.Collections.Generic;
using System.Linq;
using TOMICZ.Debugger;

namespace TOMICZ.DSARunner
{
    public class Graph
    {
        private int _numberOfVertices = 0;
        private LinkedList<int>[] _adjecencyList;

        public Graph(int numberOfVerticies)
        {
            _numberOfVertices = numberOfVerticies;

            _adjecencyList = new LinkedList<int>[numberOfVerticies];

            for (int i = 0; i < numberOfVerticies; i++)
            {
                _adjecencyList[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int v, int e)
        {
            _adjecencyList[v].AddLast(e);
        }

        public void PrintGraph()
        {
            for (int i = 0; i < _adjecencyList.Length; i++)
            {
                RuntimeConsole.Log("\n Adjacency list of vertex " + i);

                foreach (var vertex in _adjecencyList[i])
                {
                    RuntimeConsole.Log($" -> {vertex}");
                }
            }
        }

        public void Traverse(int initialVertext)
        {
            // Create array of visted vertices
            bool[] visitedVerticies = new bool[_numberOfVertices];

            // Set all vertices not visited
            for (int i = 0; i < _numberOfVertices; i++)
            {
                visitedVerticies[i] = false;
            }

            // Create a queue of vertices
            LinkedList<int> queue = new LinkedList<int>();

            // Set initial vertext as visited on start
            // Queue initial vertext to the list
            visitedVerticies[initialVertext] = true;
            queue.AddLast(initialVertext);

            while (queue.Any())
            {
                initialVertext = queue.First();
                RuntimeConsole.Log($"Vertext {initialVertext}");
                queue.RemoveFirst();

                LinkedList<int> list = _adjecencyList[initialVertext];

                foreach (var val in list)
                {
                    if (!visitedVerticies[val])
                    {
                        visitedVerticies[val] = true;
                        queue.AddLast(val);
                    }
                }
            }
        }
    }
}