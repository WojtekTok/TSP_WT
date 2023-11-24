﻿using System;
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
        private Random random = new Random();

        public GreyWolf(Population population) { Population = population; }
        public Solution Solve(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                UpdateBest();
                UpdatePositions();
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
                    if (random.Next(10) == 1) // Exploration
                    {
                        Population.SolutionsPopulation[i].path = Population.SolutionsPopulation[i].MutateRandom();
                    }
                    else
                    {
                        Population.SolutionsPopulation[i] = Population.SolutionsPopulation[i].ApproachingPrey(Alpha, Beta, Delta);
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
