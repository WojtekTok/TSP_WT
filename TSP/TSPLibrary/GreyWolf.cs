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

        public GreyWolf(Population population) { Population = population; }
        public Solution Solve(int iterations, bool deterministicMutation, bool deterministicCrossover)
        {
            LowestCostsList.Add(Population.BestSolution().cost);
            for (int i = 0; i < iterations; i++)
            {
                UpdateBest();
                UpdatePositions(iterations, deterministicCrossover);
                LowestCostsList.Add(Alpha.cost);
                if (i>0 && LowestCostsList[i-1] < LowestCostsList[i])
                {
                    Console.WriteLine("zle");
                }
            }
            UpdateBest();
            return Alpha;
        }

        private void UpdatePositions(int iterations, bool deterministicCrossover)
        {
            for(int i = 0; i < Population.SolutionsPopulation.Count; i++)
            {
                if (Population.SolutionsPopulation[i] != Alpha 
                    && Population.SolutionsPopulation[i] != Beta 
                    && Population.SolutionsPopulation[i] != Delta)
                {
                    if (random.Next(10) == 1) // Exploration
                    {
                        if (deterministicCrossover)
                            Population.SolutionsPopulation[i].path = Population.SolutionsPopulation[i].MutateDeterministic();
                        else
                            Population.SolutionsPopulation[i].path = Population.SolutionsPopulation[i].MutateRandom();
                    }
                    else
                    {
                        Population.SolutionsPopulation[i] = Population.SolutionsPopulation[i].ApproachingPrey(Alpha, Beta, Delta, iterations, deterministicCrossover);
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
    }
}
