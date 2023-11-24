// See https://aka.ms/new-console-template for more information
using TspLibNet.TSP;
using TSPLibrary;

double[,] mac = { { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 } };
CostMatrix macierzkoszt = new (mac);
//Solution sol = new Solution(new List<int> { 1, 2, 0, 3, 4, 5 }, macierzkoszt);
//Solution sol2 = new Solution(new List<int> { 4, 5, 2, 0, 3, 1 }, macierzkoszt);
//Solution sol3 = sol.Crossover(sol2, 2, 5);
//List<int> listazmutacji = sol.Mutate(2, 4);
Population populacja = new (macierzkoszt);
populacja.SolutionsPopulation = populacja.GenerateRandomPopulation(3);
Population populacjaskopiowana = populacja.DeepClone();
List<int> rozwdozmian = new List<int>(){ 0, 1, 2, 3, 4, 5 };
populacjaskopiowana.SolutionsPopulation[0] = new Solution(rozwdozmian, macierzkoszt);
CostMatrix macierzkoszt2 = new("D:\\TSP\\TSP\\TSPLIB95\\tsp\\swiss42.tsp");
Population populacja2 = new(macierzkoszt2, 100);
Evolutionary evolucyjny = new(populacja2);
BeeColony beeCol = new(populacja2.DeepClone());
GreyWolf gwo = new(populacja2.DeepClone());
Solution najlepsze = evolucyjny.Solve(1000);
Solution najlepszePszczoł = beeCol.Solve(1000);
Solution najgwo = gwo.Solve(1000);



//TspLibNet.Tours.Tour turtur = TspLibNet.Tours.Tour.FromFile("D:\\TSP\\TSP\\TSPLIB95\\tsp\\swiss42.opt.tour"); // tu coś podziałać i zrobić fajny interfejsik między formatem z lib95 a moim
Console.WriteLine("{0}", 2);

//int[,] mac2 = (int[,])mac.Clone();
//mac2[0, 0] = 100;
//mac2[1, 0] = 100;
//CostMatrix macierzkoszt = new CostMatrix(mac);
//Solution sol = new Solution();
//sol.route = new List<int> { 1, 2, 0 };
//sol.CalculateCost(macierzkoszt);
//Console.WriteLine("{0}", sol.Cost);
//[panrekinek("{0}"=mac2