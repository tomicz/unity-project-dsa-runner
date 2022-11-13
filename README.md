# About

Learn DSA visually inside Unity. 

# Graphs

A **Graph** is a non-linear data structure consisting of vertices and edges. The vertices are sometimes also referred to as nodes and the edges are lines or arcs that connect any two nodes in the graph. More formally a Graph is composed of set of vertices (V) and set of edges (E). The graph is denoted by G(E,V).

### Types of graph

- **Null graph:** A graph is known as a null graph if there are no edges in the graph

- **Trivial graph:** Graph having only a single vertex, it is also the smallest graph possible

- **Undirected graph:** A graph in which edges do not have any direction. That is the nodes are unordered pairs in the definition of every edge

- **Directed graph:** A graph in which edge has direction. That is the nodes are ordered pairs in the definition of every edge.

- **Connected graph:** The graph in which from one node we can visit any other node in the graph is known as a connected graph.

- **Disconnected graph:** The graph in which at least one node is not reachable from a node is known as a disconnected graph.

- **Regular graph:** The graph in which the degree of every vertex is equal to the other vertices of the graph. Let the degree of each vertex be K then the graph.

- **Complete graph:** The graph in which from node there is an edge to each other node.

- **Cycle graph:** The graph in which the graph is a cycle in itself, the degree of each vertex is 2

- **Cyclic graph:** A graph containing at least one cycle is known as a Cyclic graph.

- **Directed Acyclic Graph:** A directed graph that does not contain any cycle.

- **Bipartite graph:** A graph in which vertex can be divided into two sets such that vertex in each set does not contain any edge between them.

- **Weighted graph:**
	- A graph in which the edges are already specified with suitable weight is known as a weighted graph
	- Weighted graphs can be further classified as directed weighted graphs and undirected weighted graphs.

### Representations of graphs

- Adjacency Matrix 
- Adjacency List 

**Adjacency Matrix** is a 2D array of size V x V where V is the number of vertices in a graph. Let the 2D array be adj[][], a slot adj[i][j] = 1 indicates that there is an edge from vertex i to vertex j. Adjacency matrix for undirected graph is always symmetric. Adjacency Matrix is also used to represent weighted graphs. If adj[i][j] = w, then there is an edge from vertex i to vertex j with weight w.

**Adjacency List:** An array of lists is used. The size of the array is equal to the number of vertices. Let the array be an array[]. An entry array[i] represents the list of vertices adjacent to the ith vertex. This representation can also be used to represent a weighted graph. The weights of edges can be represented as lists of pairs. Following is the adjacency list representation of the above graph.  