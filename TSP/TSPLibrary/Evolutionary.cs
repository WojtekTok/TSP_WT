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
        public List<double> LowestCostsList = new List<double>();
        /// <summary>
        /// Probability of mutation for every solution in each iteration (default 0.1)
        /// </summary>
        double mutationProbability { get; set; }
        private Random random = new Random();
        public int crossoverCounter { get; private set; }
        public int mutationCounter { get; private set; }
        public double crossoverChange { get; private set; }
        public double mutationChange { get; private set; }

        public Evolutionary(Population population) { Population = population; mutationProbability = 0.1; }
        /// <summary>
        /// Main function of Evolutionary algorithm that searches optimal solution.
        /// Each iteration parents are chosen deterministically, then the child may or may not be mutated.
        /// </summary>
        /// <param name="iterations">Number of iterations algorithm executes</param>
        /// <returns>Best solution found through all iterations</returns>
        public Solution Solve(int iterations, bool deterministicMutation, bool deterministicCrossover)
        {
            Solution bestSolution = Population.BestSolution();
            LowestCostsList.Add(bestSolution.cost);
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
                    Solution child;
                    if (deterministicCrossover)
                        child = parentOne.CrossoverDeterministic(parentTwo, 
                            random.Next(parentTwo.path.Count/2));
                    else
                        child = parentOne.CrossoverRandom(parentTwo);
                    crossoverCounter++;
                    double meanParents = (parentOne.cost + parentTwo.cost) / 2;
                    crossoverChange += (meanParents-child.cost)/meanParents;

                    if (random.NextDouble() < mutationProbability)
                    {
                        mutationCounter++;
                        if (deterministicMutation)
                        {
                            var mutatedChild = new Solution(child.MutateDeterministic(), child.Matrix);
                            mutationChange += (child.cost - mutatedChild.cost) / child.cost;
                            child = mutatedChild;
                        }

                        else
                        {
                            var mutatedChild = new Solution(child.MutateRandom(), child.Matrix);
                            mutationChange += (child.cost - mutatedChild.cost) / child.cost;
                            child = mutatedChild;
                        }
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
        /// Selects parents for crossover operation based on their fitness
        /// </summary>
        /// <returns>List of parents that is twice as large as base population</returns>
        private List<int> SelectParents()
        {
            List<int> parents = Population.TournamentSelect(Population.SolutionsPopulation.Count * 2);
            return parents;
        }

        public double MeanMutation() 
        {
            return mutationChange / (double)mutationCounter;
        }

        public double MeanCrossover()
        {
            return crossoverChange / (double)crossoverCounter;
        }
    }
}
