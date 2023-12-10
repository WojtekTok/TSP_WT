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
        public List<double> LowestCostsList = new List<double>();
        private int[] trialCounter;
        private int onlookerBees;
        private Random random = new();
        public BeeColony(Population population) 
        {
            Population = population;
            onlookerBees = population.SolutionsPopulation.Count/2;
            trialCounter = new int[population.SolutionsPopulation.Count];
        }

        public Solution Solve(int iterations, bool deterministicMutation, bool deterministicCrossover)
        {
            Solution bestSolution = Population.BestSolution();
            LowestCostsList.Add(bestSolution.cost);
            for (int i = 0; i < iterations; i++)
            {
                EmployedPhase(deterministicMutation);
                OnlookerPhase(deterministicMutation);
                ScoutPhase(iterations, deterministicMutation);
                Solution currentIterBest = Population.BestSolution();
                LowestCostsList.Add(currentIterBest.cost);
                if (currentIterBest.cost <= LowestCostsList.Min())
                    bestSolution = currentIterBest;
            }
            return bestSolution;
        }

        private void EmployedPhase(bool deterministicMutation)
        {
            List<int> populationIdices = Enumerable.Range(0, Population.SolutionsPopulation.Count).ToList();
            NeighbourhoodExploration(populationIdices, deterministicMutation);
        }
        private void OnlookerPhase(bool deterministicMutation)
        {
            List<int> toVisit = Population.TournamentSelect(onlookerBees);
            NeighbourhoodExploration(toVisit, deterministicMutation);
        }

        private void ScoutPhase(int iterations, bool deterministicCrossover)
        {
            for (int i = 0; i < Population.SolutionsPopulation.Count; i++)
            {
                if (trialCounter[i] > iterations*10) 
                {
                    trialCounter[i] = 0;
                    var newSol = new Solution(Population.SolutionsPopulation[i].Matrix);
                    if (deterministicCrossover)
                        Population.SolutionsPopulation[i] = Population.SolutionsPopulation[i]
                            .CrossoverDeterministic(newSol, 
                            random.Next(Population.SolutionsPopulation[0].path.Count));
                    else
                        Population.SolutionsPopulation[i] = Population.SolutionsPopulation[i]
                            .CrossoverRandom(newSol);
                }
            }
        }

        private void NeighbourhoodExploration(List<int> solutionsNumber, bool determinsticMutation)
        {
            foreach(int i in solutionsNumber)
            {
                Solution currSolution = Population.SolutionsPopulation[i];
                Solution neighbour;
                if (determinsticMutation)
                    neighbour = new Solution(currSolution.MutateDeterministic(), currSolution.Matrix);
                else
                    neighbour = new Solution(currSolution.MutateRandom(), currSolution.Matrix);
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
