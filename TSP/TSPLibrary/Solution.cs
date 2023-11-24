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
            startNode -= MoveToEnd(startNode, nodeNumber);
                
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
            int indexNumber = random.Next(0, Matrix.nodesNumber/2);
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


        public Solution CrossoverRandom(Solution otherSolution)
        {
            int startIndex = random.Next(Matrix.nodesNumber);
            int indexNumber = random.Next(Matrix.nodesNumber/3, Matrix.nodesNumber*2 / 3);
            return Crossover(otherSolution, startIndex, indexNumber);
        }

        public Solution ApproachingPrey(Solution alpha, Solution beta, Solution delta) 
        {
            int stepSize;
            if (Matrix.nodesNumber < 10)
                stepSize = 1;
            else
                stepSize = Matrix.nodesNumber / 10; //TODO zrobić tak, żeby dł kroku zależała od ilości iteracji i wielkości populacji

            List<int> nodesLeft = Enumerable.Range(0, Matrix.nodesNumber).ToList();
            int removeFrom;
            int alphaNode = nodesLeft[random.Next(Matrix.nodesNumber)];
            if (alphaNode - stepSize < 0)
                removeFrom = 0;
            else
                removeFrom = alphaNode - stepSize;
            nodesLeft.RemoveRange(removeFrom, stepSize);
            int betaNode = nodesLeft[random.Next(Matrix.nodesNumber - stepSize*2)];
            if (betaNode - stepSize < 0)
                removeFrom = 0;
            else
                removeFrom = betaNode - stepSize;
            nodesLeft.RemoveRange(removeFrom, stepSize);
            int deltaNode = nodesLeft[random.Next(Matrix.nodesNumber - stepSize * 4)];
            //nodesLeft.RemoveRange(deltaNode, stepSize);

            Solution HelperCrossover(int nodeIndex, Solution firstSolution, Solution secSolution)
            {
                int excess = MoveToEnd(nodeIndex, stepSize);
                alphaNode -= excess;
                betaNode -= excess;
                deltaNode -= excess;
                return firstSolution.Crossover(secSolution, nodeIndex, stepSize);
            }
            
            Solution newSolution = HelperCrossover(deltaNode, delta, this);
            newSolution = HelperCrossover(betaNode, beta, newSolution);
            newSolution = HelperCrossover(alphaNode, alpha, newSolution);

            return newSolution;
        }
        /// <summary>
        /// Crossover two solutions starting from a random node. Crossed nodes can count from 33% up to 66% of all nodes.
        /// </summary>
        /// <param name="otherSolution"> Solution to crossover with </param>
        /// <param name="startIndex"> Index from which a solution's part is taken </param>
        /// <param name="indexNumber"> Number of nodes to be taken </param>
        /// <returns> New solution based on two parent solutions </returns>
        private Solution Crossover(Solution otherSolution, int startIndex, int indexNumber)
        {
            startIndex -= MoveToEnd(startIndex, indexNumber);
            List<int> toCutOut = path.GetRange(startIndex, indexNumber);
            List<int> cuttedOtherPath = otherSolution.path.Except(toCutOut).ToList();
            List<int> newPath = cuttedOtherPath.Take(startIndex)
                                                .Concat(toCutOut)
                                                .Concat(cuttedOtherPath.Skip(startIndex))
                                                .ToList();
            return new Solution(newPath, Matrix);
        }

        private List<int> MoveNodes(List<int> nodes, int toMove)
        {
            return nodes.Skip(toMove).Concat(nodes.Take(toMove)).ToList();
        }

        private int MoveToEnd(int startIndex, int indexNumber)
        {
            if (indexNumber > Matrix.nodesNumber - startIndex)
            {
                int excess = startIndex + indexNumber - Matrix.nodesNumber;
                path = MoveNodes(path, startIndex + indexNumber - Matrix.nodesNumber); // any node can be starting node
                return excess;
            }
            else
                return 0;
        }

    }
}
