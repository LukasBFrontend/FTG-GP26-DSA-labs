using System;
using System.Collections.Generic;

namespace DSA.Lab06
{
    public sealed class DijkstraRouteFinder
    {
        public RouteResult FindRoute(WeightedGraph graph, string start, string goal)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            if (!graph.ContainsNode(start) || !graph.ContainsNode(goal))
            {
                return RouteResult.NotFound(0);
            }

            if (start == goal)
            {
                return RouteResult.Success(new[] { start }, 0, 0);
            }

            var bestCost = new Dictionary<string, int>();
            var cameFrom = new Dictionary<string, string>();
            var frontier = new MinFrontier<string>();

            bestCost[start] = 0;
            frontier.Enqueue(start, 0);

            int expandedNodes = 0;

            // TODO Lab 6A:
            // 1. Repeatedly remove the smallest-priority frontier candidate.
            // 2. Ignore stale entries when a cheaper cost is already known.
            // 3. Finalize/expand the current node.
            // 4. If it is the goal, reconstruct the route using cameFrom.
            // 5. Relax each outgoing edge:
            //      candidate = bestCost[current] + edge.Cost
            //    If candidate improves the known cost, update both bestCost and cameFrom,
            //    then enqueue the neighbor with the improved total cost.
            //
            // Implement one small piece at a time and run the relevant tests.

            while(expandedNodes < graph.NodeCount)
            {
                // 1. Repeatedly remove the smallest-priority frontier candidate.
                var currentEntry = frontier.Dequeue();

                // 2. Ignore stale entries when a cheaper cost is already known.
                if (bestCost.TryGetValue(currentEntry.Value, out var currentBest))
                {
                    if (currentBest < currentEntry.Priority)
                    {
                        continue;
                    }
                }

                // 3. Finalize/expand the current node.
                foreach(WeightedEdge edge in graph.GetOutgoing(currentEntry.Value))
                {
                    string neighbor = edge.To;
                    if (neighbor == cameFrom[currentEntry.Value]) // Only explore forwards
                    {
                        continue;
                    }

                    int candidate = bestCost[currentEntry.Value] + edge.Cost;

                    if (candidate < bestCost[neighbor])
                    {
                        bestCost[neighbor] = candidate;
                        cameFrom[neighbor] =
                    }


                    frontier.Enqueue(edge.To, candidate); // edge cost or total cost?
                }
            }


            return RouteResult.NotFound(expandedNodes);
        }
    }
}
