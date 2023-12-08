using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPLibrary
{
    interface IAlgorithm
    {
        public Solution Solve(int iterations, bool deterministicMutation, bool deterministicCrossover);
    }
}
