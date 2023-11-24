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

        public CostMatrix Matrix { get; set; }
        private Random random = new();
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
        /// <summary>
        /// Finds best solution
        /// </summary>
        /// <returns>Best solution among population</returns>
        public Solution BestSolution()
        {
            double bestCost = Constants.inf;
            Solution BestSolution = SolutionsPopulation[0];
            foreach(Solution solution in SolutionsPopulation)
            {
                if (solution.cost < bestCost)
                {
                    bestCost = solution.cost;
                    BestSolution = solution;
                }
                    
            }
            return BestSolution;
        }

        public List<Solution> ThreeBest()
        {
            List<Solution> bestSolutions = SolutionsPopulation.Take(3).ToList();
            foreach (Solution solution in SolutionsPopulation)
            {
                if (solution.cost < bestSolutions[2].cost)
                {
                    if (solution.cost < bestSolutions[1].cost)
                    {
                        if (solution.cost < bestSolutions[0].cost)
                        {
                            bestSolutions[2] = bestSolutions[1];
                            bestSolutions[1] = bestSolutions[0];
                            bestSolutions[0] = solution;
                        }
                        else
                        {
                            bestSolutions[2] = bestSolutions[1];
                            bestSolutions[1] = solution;
                        }
                    }
                    else
                    {
                        bestSolutions[2] = solution;
                    }
                }
            }
            return bestSolutions;
        } 

        /// <summary>
        /// Calculates total fitness of whole population
        /// </summary>
        /// <returns>Total fitness of all solutions</returns>
        private double TotalFitness()
        {
            double totalFit = 0.0;
            foreach (var solution in SolutionsPopulation)
            {
                totalFit += 1 / solution.cost;
            }
            return totalFit;
        }

        internal List<int> ProbabilitySelect(int solutionNumber)
        {
            List<int> chosenSolutions = new List<int>();
            while (chosenSolutions.Count < solutionNumber)
            {
                List<Solution> participants = new();
                List<int> indicesLeft = Enumerable.Range(0, SolutionsPopulation.Count).ToList();
                while (indicesLeft.Count > 0)
                {
                    int randomValue = random.Next(indicesLeft.Count);
                    participants.Add(SolutionsPopulation[indicesLeft[randomValue]]);
                    indicesLeft.Remove(indicesLeft[randomValue]);
                    if(participants.Count == SolutionsPopulation.Count/10) 
                    {
                        chosenSolutions.Add(participants.FindIndex(sol => sol.cost == participants.Min(s => s.cost)));
                        participants.Clear();
                    }
                }
                if(participants.Count > 0)
                {
                    chosenSolutions.Add(participants.FindIndex(sol => sol.cost == participants.Min(s => s.cost)));
                }
            }
            return chosenSolutions;
        }

        internal List<int> ProbabilitySelect1(int solutionNumber) //roulette
        {
            double totalFit = TotalFitness();
            List<int> chosenSolutions = new List<int>();

            for(int i = 0; i < solutionNumber; i++)
            {
                double randomValue = random.NextDouble() * totalFit;
                double sum = 0;
                for(int j = 0; j < SolutionsPopulation.Count; j++)
                {
                    sum += 1 / SolutionsPopulation[j].cost;
                    if (randomValue <= sum)
                    {
                        chosenSolutions.Add(j);
                        break;
                    }
                }
            }
            return chosenSolutions;
        }

        //internal List<int> ProbabilitySelect1(int solutionNumber)
        //{
        //    double totalFit = TotalFitness();
        //    List<int> chosenSolutions = new List<int>();
        //    Random random = new();

        //    for (int i = 0; i < solutionNumber; i++)
        //    {
        //        double randomValue = random.NextDouble() * totalFit;
        //        double sum = 0;
        //        List<int> indicesLeft = Enumerable.Range(0, SolutionsPopulation.Count).ToList();
        //        for (int j = 0; j < SolutionsPopulation.Count; j++)
        //        {
        //            int randomInt = random.Next(SolutionsPopulation.Count - j);
        //            sum += 1 / SolutionsPopulation[indicesLeft[randomInt]].cost;
        //            indicesLeft.RemoveAt(randomInt);
        //            if (sum >= randomValue)
        //            {
        //                chosenSolutions.Add(randomInt);
        //                break;
        //            }
        //        }
        //    }
        //    return chosenSolutions;
        //}

    }
}
