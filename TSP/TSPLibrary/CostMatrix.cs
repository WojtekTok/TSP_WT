using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime;
using System.Xml.Linq;

namespace TSPLibrary
{
    public class CostMatrix
        //TODO dodać że muszą być wszystkie węzły jakoś połączone
    {
        public required int[,] Matrix {  get; set; }
        public int nodesCount { get; set; }

        [SetsRequiredMembers]
        public CostMatrix(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new Exception("matrixes must have the same dimensions");
            }

            Matrix = matrix;
            nodesCount = Matrix.GetLength(0);
        }
    }
}