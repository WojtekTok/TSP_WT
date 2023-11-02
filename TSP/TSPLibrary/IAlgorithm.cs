using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPLibrary
{
    interface IAlgorithm
    {
        Solution Solve(int iterations);
    }
}
