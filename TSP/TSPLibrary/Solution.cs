using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TspLibNet;

namespace TSPLibrary
{
    public class Solution
    {
        /// <summary>
        /// A path, where ints are nodes numbers' and their positions in list represent their sequence
        /// </summary>
        public List<int> path = new List<int>();

        /// <summary>
        /// Cost to travel the current path
        /// </summary>
        public double cost { get; private set; }

        /// <summary>
        /// Cost matrix for current solution
        /// </summary>
        public CostMatrix Matrix { get; private set; }

        private Random random = new Random();

        public Solution(CostMatrix matrix) 
        {
            Matrix = matrix;
            this.path = CreateRandomPath();
            if (!IsPathCorrect())
                new Exception("Incorrect Route!!");
            CalculateCost();
        }

        public Solution(List<int> route, CostMatrix matrix)
        {
            Matrix = matrix;
            this.path = route;
            if (!IsPathCorrect())
                new Exception("Incorrect Route!!");
            CalculateCost();
        }

        /// <summary>
        /// Method to calculate cost of current path
        /// </summary>
        private void CalculateCost() 
        {
            double temp_cost = 0;
            for (int i=0; i<this.path.Count-1; i++)
                temp_cost += Matrix.Matrix[path[i],path[i + 1]];
            temp_cost += Matrix.Matrix[path[this.path.Count-1], path[0]];
            this.cost = temp_cost;
                
        }

        /// <summary>
        /// Check if the path contains all elements once
        /// </summary>
        /// <returns></returns>
        private bool IsPathCorrect()
        {
            for(int i=0; i< this.path.Count-1; i++)
            {
                var elemCount = path.Count(n => n == i);
                if (elemCount != 1)
                    return false;

                if (Matrix.Matrix[path[i], path[i + 1]] == Constants.inf)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Mutate current path by swapping places of part of the path randomly
        /// </summary>
        /// <param name="startNode"> Starting node of the part to be swapped internally </param>
        /// <param name="nodeNumber"> Number of nodes to be swapped </param>
        /// <returns> New, mutated path </returns>
        private List<int> Mutate(int startNode, int nodeNumber)
        {
            if (startNode+nodeNumber > this.path.Count - 1)
                new Exception("nodeCount out of bounds");

            List<int> nodesLeft = path.GetRange(startNode, nodeNumber);
            List<int> newRoute = new List<int>();
            newRoute.AddRange(path.Take(startNode));
            for (int i = nodeNumber; i > 0; i--)
            {
                int node = random.Next(i);
                newRoute.Add(nodesLeft[node]);
                nodesLeft.Remove(nodesLeft[node]);
            }
            newRoute.AddRange(path.Skip(startNode+nodeNumber));
            return newRoute;
        }

        public List<int> MutateRandom()
        {
            List<int> newRoute = new();
            int startIndex = random.Next(0, Matrix.nodesNumber);
            int indexNumber = random.Next(Matrix.nodesNumber - startIndex);
            newRoute = Mutate(startIndex, indexNumber);
            return newRoute;
        }

        /// <summary>
        /// Creates full new random path
        /// </summary>
        /// <returns> New random path </returns>
        private List<int> CreateRandomPath()
        {
            path = Enumerable.Range(0, Matrix.nodesNumber).ToList();
            return Mutate(0, Matrix.nodesNumber);
        }

        /// <summary>
        /// Crossover two solutions
        /// </summary>
        /// <param name="otherSolution"> Solution to crossover with </param>
        /// <param name="startIndex"> Index from which a solution's part is taken </param>
        /// <param name="indexCount"> Number of nodes to be taken </param>
        /// <returns> New solution based on two parent solutions </returns>
        public Solution Crossover(Solution otherSolution)
        {
            int startIndex = random.Next(0, Matrix.nodesNumber);
            int indexNumber = random.Next(Matrix.nodesNumber - startIndex);
            if(indexNumber > Matrix.nodesNumber - startIndex)
                indexNumber = Matrix.nodesNumber - startIndex;
            List<int> toCutOut = path.GetRange(startIndex, indexNumber);
            List<int> cuttedOtherPath = otherSolution.path.Except(toCutOut).ToList();
            List<int> newPath = cuttedOtherPath.Take(startIndex)
                                                .Concat(toCutOut)
                                                .Concat(cuttedOtherPath.Skip(startIndex))
                                                .ToList();
            return new Solution(newPath, Matrix);
        }

    }
}
