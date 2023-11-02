using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPLibrary
{
    public class Evolutionary : IAlgorithm
    {
        /// <summary>
        /// Population of solutions that is optimized
        /// </summary>
        public Population Population { get; private set; }
        /// <summary>
        /// List that contains lowest cost among all solutions in each iteration
        /// </summary>
        private List<double> LowestCostsList = new List<double>();
        /// <summary>
        /// Probability of mutation for every solution in each iteration (default 0.1)
        /// </summary>
        double mutationProbability { get; set; }
        private Random random = new Random();

        public Evolutionary(Population population) { Population = population; mutationProbability = 0.1; }
        /// <summary>
        /// Main function of Evolutionary algorithm that searches optimal solution.
        /// Each iteration parents are chosen deterministically, then the child may or may not be mutated.
        /// </summary>
        /// <param name="iterations">Number of iterations algorithm executes</param>
        /// <returns>Best solution found through all iterations</returns>
        public Solution Solve(int iterations)
        {
            Solution bestSolution = Population.SolutionsPopulation[0];
            for (int i = 0; i < iterations; i++) 
            {
                List<Solution> newPopulation = new List<Solution>();
                List<int> parents = SelectParents();
                for(int j = 0; j < Population.SolutionsPopulation.Count; j++)
                {
                    int parentOneIndex = parents[random.Next(parents.Count)];
                    parents.Remove(parentOneIndex);
                    int parentTwoIndex = parents[random.Next(parents.Count)];
                    parents.Remove(parentTwoIndex);
                    Solution parentOne = Population.SolutionsPopulation[parentOneIndex];
                    Solution parentTwo = Population.SolutionsPopulation[parentTwoIndex];
                    Solution child = parentOne.Crossover(parentTwo);
                    if (random.NextDouble() < mutationProbability)
                    {
                        child.MutateRandom();
                    }
                    newPopulation.Add(child);
                }
                Population.SolutionsPopulation = newPopulation;
                Solution currentIterBest = Population.BestSolution();
                LowestCostsList.Add(currentIterBest.cost);
                if (currentIterBest.cost <= LowestCostsList.Min())
                    bestSolution = currentIterBest;
            }
            return bestSolution;
        }
        /// <summary>
        /// Calculates total fitness of whole population
        /// </summary>
        /// <returns>Total fitness of all solutions</returns>
        private double TotalFitness()
        {
            double totalFit = 0.0;
            foreach (var solution in Population.SolutionsPopulation)
            {
                totalFit += 1/solution.cost;
            }
            return totalFit;
        }
        /// <summary>
        /// Selects parents for crossover operation based on their fitness
        /// </summary>
        /// <returns>List of parents that is twice as large as base population</returns>
        private List<int> SelectParents()
        {
            double totalFit = TotalFitness();
            List<int> parents = new List<int>();
            for (int i = 0;i < Population.SolutionsPopulation.Count*2; i++)
            {
                double randomValue = random.NextDouble() * totalFit;
                double sum = 0;
                List<int> indicesLeft = Enumerable.Range(0, Population.SolutionsPopulation.Count).ToList();
                for (int j = 0; j < Population.SolutionsPopulation.Count; j++)
                {
                    int randomInt = random.Next(Population.SolutionsPopulation.Count-j);
                    sum += 1 / Population.SolutionsPopulation[indicesLeft[randomInt]].cost;
                    indicesLeft.RemoveAt(randomInt);
                    if (sum >= randomValue)
                    {
                        parents.Add(randomInt);
                        break;
                    }
                }
            }
            return parents;
        }
    }
}
