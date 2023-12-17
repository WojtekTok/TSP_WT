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
        public int crossoverCounter {  get; private set; }
        public int mutationCounter { get; private set; }
        public double crossoverChange { get; private set; }
        public double mutationChange { get; private set; }

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
            NeighbourhoodExploration(populationIdices, deterministicMutation, true);
        }
        private void OnlookerPhase(bool deterministicMutation)
        {
            List<int> toVisit = Population.TournamentSelect(onlookerBees);
            NeighbourhoodExploration(toVisit, deterministicMutation, false);
        }

        private void ScoutPhase(int iterations, bool deterministicCrossover)
        {
            for (int i = 0; i < Population.SolutionsPopulation.Count; i++)
            {
                if (trialCounter[i] > iterations/2) 
                {
                    trialCounter[i] = 0;
                    crossoverCounter++;
                    var bestSolutions = Population.ThreeBest();
                    var previousCost = Population.SolutionsPopulation[i].cost;
                    if (deterministicCrossover)
                        Population.SolutionsPopulation[i] = Population.SolutionsPopulation[i]
                            .CrossoverDeterministic(bestSolutions[random.Next(2)], 
                            random.Next(Population.SolutionsPopulation[0].path.Count));
                    else
                        Population.SolutionsPopulation[i] = Population.SolutionsPopulation[i]
                            .CrossoverRandom(bestSolutions[random.Next(2)]);
                    crossoverChange += (previousCost - Population.SolutionsPopulation[i].cost) / previousCost;
                }
            }
        }

        private void NeighbourhoodExploration(List<int> solutionsNumber, bool determinsticMutation, bool changeToWorse)
        {
            foreach(int i in solutionsNumber)
            {
                Solution currSolution = Population.SolutionsPopulation[i];
                Solution neighbour;
                if (determinsticMutation)
                    neighbour = new Solution(currSolution.MutateDeterministic(), currSolution.Matrix);
                else
                    neighbour = new Solution(currSolution.MutateRandom(), currSolution.Matrix);
                mutationCounter++;
                mutationChange += (currSolution.cost-neighbour.cost)/ currSolution.cost;
                if (neighbour.cost >= currSolution.cost)
                {
                    trialCounter[i]++;
                    if(changeToWorse)
                        Population.SolutionsPopulation[i] = neighbour;
                }
                else
                    Population.SolutionsPopulation[i] = neighbour;
            }
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
