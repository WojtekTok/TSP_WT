using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TSPLibrary
{
    public class Solution
    {
        public List<int> route = new List<int>();
        public int Cost { get; private set; }
        public CostMatrix Matrix { get; private set; }
        private Random rnd = new Random();
        public Solution(CostMatrix matrix) 
        {
            Matrix = matrix;
            this.route = CreateRandomRoute();
            if (!IsRouteCorrect())
                new Exception("Incorrect Route!!");
            CalculateCost();
        }
        public Solution(List<int> route, CostMatrix matrix)
        {
            Matrix = matrix;
            this.route = route;
            if (!IsRouteCorrect())
                new Exception("Incorrect Route!!");
            CalculateCost();
        }


        private void CalculateCost() 
        {
            int temp_cost = 0;
            for (int i=0; i<this.route.Count-1; i++)
                temp_cost += Matrix.Matrix[route[i],route[i + 1]];
            temp_cost += Matrix.Matrix[route[this.route.Count-1], route[0]];
            this.Cost = temp_cost;
                
        }
        private bool IsRouteCorrect()
        {
            for(int i=0; i< this.route.Count-1; i++)
            {
                var elemCount = route.Count(n => n == i);
                if (elemCount != 1)
                    return false;

                if (Matrix.Matrix[route[i], route[i + 1]] == Constants.inf)
                    return false;
            }
            return true;
        }
        private List<int> Mutate(int startNode, int nodeCount)
        {
            if (startNode+nodeCount > this.route.Count)
                new Exception("nodeCount out of bounds");

            List<int> nodesLeft = route.GetRange(startNode, nodeCount);
            List<int> newRoute = new List<int>();
            newRoute.AddRange(route.Take(startNode));
            for (int i = nodeCount; i > 0; i--)
            {
                int node = rnd.Next(i);
                newRoute.Add(nodesLeft[node]);
                nodesLeft.Remove(nodesLeft[node]);
            }
            newRoute.AddRange(route.Skip(startNode+nodeCount));
            return newRoute;
        }

        private List<int> CreateRandomRoute()
        {
            return Mutate(0, Matrix.nodesCount);
        }

        public Solution Crossover(Solution otherSolution, int startIndex, int indexCount)
        {
            //int startIndex = rnd.Next(0, Matrix.nodesCount);
            //int endIndex = rnd.Next(startIndex, Matrix.nodesCount);
            if(indexCount > Matrix.nodesCount - startIndex)
                indexCount = Matrix.nodesCount - startIndex;
            List<int> toCutOut = route.GetRange(startIndex, indexCount);
            List<int> cuttedOtherRoute = otherSolution.route.Except(toCutOut).ToList();
            List<int> newRoute = cuttedOtherRoute.Take(startIndex)
                                                .Concat(toCutOut)
                                                .Concat(cuttedOtherRoute.Skip(startIndex))
                                                .ToList();
            return new Solution(newRoute, Matrix);
        }

    }
}
