namespace np.Application
{
    public static class NavigationService
    {
        public static IEnumerable<string> GetShortestPath(Dictionary<string, Dictionary<string, int>> graph, string startNode, string endNode)
        {
            if(graph.Count == 0)
                return Enumerable.Empty<string>();

            // Initialize distance dictionary (shortest known distances from startNode)
            var distances = new Dictionary<string, int>();
            // Previous nodes in the shortest path, for reconstruction of the path
            var previousNodes = new Dictionary<string, string>();
            // Priority queue to efficiently fetch the next node with the shortest distance
            var priorityQueue = new SortedSet<(int Distance, string Node)>();
            // Set to track visited nodes
            var visited = new HashSet<string>();

            // Initialize all distances to infinity and set previous nodes to null
            foreach (var node in graph.Keys)
            {
                distances[node] = int.MaxValue; // Represent "infinity"
                previousNodes[node] = null;
            }
            // Distance to the startNode is 0
            distances[startNode] = 0;
            // Add the startNode to the priority queue
            priorityQueue.Add((0, startNode));

            while (priorityQueue.Count > 0)
            {
                // Extract node with the smallest distance
                var (currentDistance, currentNode) = priorityQueue.Min;
                priorityQueue.Remove(priorityQueue.Min);

                // Skip if we've already visited this node
                if (visited.Contains(currentNode))
                    continue;

                visited.Add(currentNode);

                // Early exit: If we've reached the endNode, we can stop
                if (currentNode == endNode)
                    break;

                // Examine neighbors of the current node
                var firstNeighbor = graph[currentNode].FirstOrDefault(); // Always choose the first listed neighbor
                if (!string.IsNullOrEmpty(firstNeighbor.Key))
                {
                    var neighbor = firstNeighbor.Key;
                    var weight = firstNeighbor.Value;

                    // Calculate tentative distance to the neighbor
                    var tentativeDistance = currentDistance + weight;

                    // If the calculated distance is shorter, update distance and previous node tracking
                    if (tentativeDistance < distances[neighbor])
                    {
                        // Remove the neighbor from the priority queue before updating its value
                        priorityQueue.Remove((distances[neighbor], neighbor));

                        distances[neighbor] = tentativeDistance;
                        previousNodes[neighbor] = currentNode;

                        // Add the neighbor back with updated priority
                        priorityQueue.Add((tentativeDistance, neighbor));
                    }
                }
            }

            // Reconstruct the shortest path from endNode to startNode
            var path = new List<string>();
            var current = endNode;
            while (current != null)
            {
                path.Add(current);
                current = previousNodes[current];
            }

            path.Reverse(); // Reverse the path to start from startNode

            // If the endNode is unreachable, return an empty path
            if (distances[endNode] == int.MaxValue)
            {
                return new List<string>();
            }

            return path;
        }

    }
}