using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TspLibNet.Graph.Nodes;

namespace TSPLibrary
{
    public class Population
    {
        /// <summary>
        /// Population of solutions
        /// </summary>
        public List<Solution> SolutionsPopulation { get; set; }

        private CostMatrix Matrix { get; set; }
        public Population(CostMatrix matrix)
        {
            Matrix = matrix;
        }

        /// <summary>
        /// Constructor initialized with a random population
        /// </summary>
        /// <param name="matrix"> Cost matrix </param>
        /// <param name="size"> Number of solutions to be generated in this population </param>
        public Population(CostMatrix matrix, int size) 
        {
            Matrix = matrix;
            SolutionsPopulation = GenerateRandomPopulation(size);
        }

        /// <summary>
        /// Generates random population that contains chosen number of solutions
        /// </summary>
        /// <param name="size"> Number of solutions to be generated in this population </param>
        /// <returns> Random population of a chosen size </returns>
        public List<Solution> GenerateRandomPopulation(int size)
        {
            List<Solution> population = new List<Solution>();
            for(int i=0; i<size; i++)
            {
                population.Add(new Solution(Matrix));
            }
            return population;
        }

        /// <summary>
        /// Method to clone current population
        /// </summary>
        /// <returns> Deep cloned population </returns>
        public Population DeepClone()
        {
            Population NewPopulation = new(Matrix);
            List <Solution> solutions = new();
            foreach (Solution solution in SolutionsPopulation)
            {
                List<int> newRoute = new List<int>();
                foreach(int node in solution.path)
                {
                    newRoute.Add(node);
                }
                solutions.Add(new Solution(newRoute, Matrix));
            }
            NewPopulation.SolutionsPopulation = solutions;
            return NewPopulation;
        }   

        public Solution BestSolution()
        {
            double bestCost = Constants.inf;
            Solution BestSolution = SolutionsPopulation[0];
            foreach(Solution solution in SolutionsPopulation)
            {
                if (solution.cost < bestCost)
                    bestCost = solution.cost;
                    BestSolution = solution;
            }
            return BestSolution;
        }
        
    }
}
