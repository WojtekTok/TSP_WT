using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPLibrary
{
    public class Population
    {
        public List<Solution> SolutionsPopulation { get; private set; }
        private CostMatrix Matrix { get; set; }
        public Population(CostMatrix matrix)
        {
            Matrix = matrix;
            //TODO tworzenie w pętli losowych rozwiązań
        }

        public List<Solution> GenerateRandomPopulation()
        {
            
        }
    }
}
