using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPLibrary
{
    public class BeeColony : IAlgorithm
    {
        public Population Population { get; private set; }
        private List<double> LowestCostsList = new List<double>();
        private int[] trialCounter;
        private int onlookerBees;
        public BeeColony(Population population) 
        {
            Population = population;
            onlookerBees = population.SolutionsPopulation.Count;
            trialCounter = new int[population.SolutionsPopulation.Count];
        }

        public Solution Solve(int iterations)
        {
            Solution bestSolution = Population.SolutionsPopulation[0];
            for (int i = 0; i < iterations; i++)
            {
                EmployedPhase();
                OnlookerPhase();
                ScoutPhase(iterations);
                Solution currentIterBest = Population.BestSolution();
                LowestCostsList.Add(currentIterBest.cost);
                if (currentIterBest.cost <= LowestCostsList.Min())
                    bestSolution = currentIterBest;
            }
            return bestSolution;
        }

        private void EmployedPhase()
        {
            List<int> populationIdices = Enumerable.Range(0, Population.SolutionsPopulation.Count).ToList();
            NeighbourhoodExploration(populationIdices);
        }
        private void OnlookerPhase()
        {
            List<int> toVisit = Population.ProbabilitySelect(onlookerBees);
            NeighbourhoodExploration(toVisit);
        }

        private void ScoutPhase(int iterations)
        {
            for (int i = 0; i < Population.SolutionsPopulation.Count; i++)
            {
                if (trialCounter[i] > iterations*10) //TODO możliwe że to lepiej sparametryzować
                {
                    trialCounter[i] = 0;
                    Population.SolutionsPopulation[i] = new Solution(Population.SolutionsPopulation[i].Matrix);
                }
            }
        }

        private void NeighbourhoodExploration(List<int> solutionsNumber)
        {
            foreach(int i in solutionsNumber)
            {
                Solution currSolution = Population.SolutionsPopulation[i];
                Solution neighbour = new Solution(currSolution.MutateRandom(), currSolution.Matrix);
                if (neighbour.cost < currSolution.cost)
                    Population.SolutionsPopulation[i] = neighbour;
                else
                {
                    trialCounter[i]++;
                }
            }
        }
    }
}
