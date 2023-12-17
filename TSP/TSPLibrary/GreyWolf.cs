using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPLibrary
{
    public class GreyWolf : IAlgorithm
    {
        //10.5539/mas.v12n8p142

        public Population Population { get; set; }
        public List<double> LowestCostsList = new List<double>();
        public Solution Alpha;
        public Solution Beta;
        public Solution Delta;
        private Random random = new Random();
        public int crossoverCounter { get; private set; }
        public int mutationCounter { get; private set; }
        public double crossoverChange { get; private set; }
        public double mutationChange { get; private set; }

        public GreyWolf(Population population) { Population = population; }
        public Solution Solve(int iterations, bool deterministicMutation, bool deterministicCrossover)
        {
            LowestCostsList.Add(Population.BestSolution().cost);
            for (int i = 0; i < iterations; i++)
            {
                UpdateBest();
                UpdatePositions(iterations, deterministicCrossover, deterministicMutation);
                LowestCostsList.Add(Alpha.cost);
            }
            UpdateBest();
            return Alpha;
        }

        private void UpdatePositions(int iterations, bool deterministicCrossover, bool deterministicMutation)
        {
            for(int i = 0; i < Population.SolutionsPopulation.Count; i++)
            {
                if (Population.SolutionsPopulation[i] != Alpha 
                    && Population.SolutionsPopulation[i] != Beta 
                    && Population.SolutionsPopulation[i] != Delta)
                {
                    if (random.Next(10) == 1) // Exploration
                    {
                        mutationCounter++;
                        if (deterministicMutation)
                        {
                            var neighbour = new Solution(Population.SolutionsPopulation[i].MutateDeterministic(), Population.SolutionsPopulation[i].Matrix);
                            mutationChange += (Population.SolutionsPopulation[i].cost - neighbour.cost)/ Population.SolutionsPopulation[i].cost;
                            Population.SolutionsPopulation[i] = neighbour;
                        }                       
                        else
                        {
                            var neighbour = new Solution(Population.SolutionsPopulation[i].MutateRandom(), Population.SolutionsPopulation[i].Matrix);
                            mutationChange += (Population.SolutionsPopulation[i].cost - neighbour.cost) / Population.SolutionsPopulation[i].cost;
                            Population.SolutionsPopulation[i] = neighbour;
                        }
                    }
                    else
                    {
                        crossoverCounter++;
                        var newSolution = Population.SolutionsPopulation[i].ApproachingPrey(Alpha, Beta, Delta, iterations, deterministicCrossover);
                        crossoverChange += (Population.SolutionsPopulation[i].cost - newSolution.cost) / Population.SolutionsPopulation[i].cost;
                        Population.SolutionsPopulation[i] = newSolution;
                    }
                }
            }
        }
        private void UpdateBest()
        {
            List<Solution> best = Population.ThreeBest();
            Alpha = best[0];
            Beta = best[1];
            Delta = best[2];
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
