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
        private List<double> LowestCostsList = new List<double>();
        public Solution Alpha;
        public Solution Beta;
        public Solution Delta;

        public GreyWolf(Population population) { Population = population; }
        public Solution Solve(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                UpdateBest();
                UpdatePositions();
                DeltaExploration();
                LowestCostsList.Add(Alpha.cost);
            }
            UpdateBest();
            return Alpha;
        }

        private void UpdatePositions()
        {
            for(int i = 0; i < Population.SolutionsPopulation.Count; i++)
            {
                if (Population.SolutionsPopulation[i] != Alpha 
                    && Population.SolutionsPopulation[i] != Beta 
                    && Population.SolutionsPopulation[i] != Delta)
                {
                    Population.SolutionsPopulation[i].Crossover(Delta);
                    Population.SolutionsPopulation[i].Crossover(Beta);
                    Population.SolutionsPopulation[i].Crossover(Alpha);
                }
            }
        }
        private void DeltaExploration()
        {
            Delta = new Solution(Delta.Matrix);
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
