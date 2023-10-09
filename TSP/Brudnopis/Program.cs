// See https://aka.ms/new-console-template for more information
using TSPLibrary;

int[,] mac = { { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 } };
CostMatrix macierzkoszt = new CostMatrix(mac);
Solution sol = new Solution(new List<int> { 1, 2, 0, 3, 4, 5 }, macierzkoszt);
Solution sol2 = new Solution(new List<int> { 4, 5, 2, 0, 3, 1 }, macierzkoszt);
Solution sol3 = sol.Crossover(sol2, 2, 5);
//List<int> listazmutacji = sol.Mutate(2, 4);
Console.WriteLine("{0}", sol.Cost);
//int[,] mac2 = (int[,])mac.Clone();
//mac2[0, 0] = 100;
//mac2[1, 0] = 100;
//CostMatrix macierzkoszt = new CostMatrix(mac);
//Solution sol = new Solution();
//sol.route = new List<int> { 1, 2, 0 };
//sol.CalculateCost(macierzkoszt);
//Console.WriteLine("{0}", sol.Cost);
