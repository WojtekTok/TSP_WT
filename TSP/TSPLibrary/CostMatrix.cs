using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime;
using System.Xml.Linq;
using TspLibNet.TSP;

namespace TSPLibrary
{
    public class CostMatrix
    {
        /// <summary>
        /// Cost matrix that contains weights
        /// </summary>
        public required double[,] Matrix {  get; set; }

        /// <summary>
        /// Number of nodes in a graph
        /// </summary>
        public int nodesNumber { get; set; }

        /// <summary>
        /// Constructor with custom matrix passed as argument
        /// </summary>
        /// <param name="matrix">Square cost matrix</param>
        [SetsRequiredMembers]
        public CostMatrix(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new Exception("matrixes must have the same dimensions");
            }

            Matrix = matrix;
            nodesNumber = Matrix.GetLength(0);
        }

        /// <summary>
        /// Constructor with directory to TSP file from TSPLib 95
        /// </summary>
        /// <param name="dir"> directory to TSP file </param>
        [SetsRequiredMembers]
        public CostMatrix(string dir)
        {
            Matrix = LoadMatrixFromTSPLIB(dir);
            nodesNumber = Matrix.GetLength(0);
        }

        /// <summary>
        /// Loads matrix from TSPLib 95 .TSP files. File must contain a matrix with edge weights
        /// </summary>
        /// <param name="dir"> directory to a .TSP file </param>
        /// <returns></returns>
        private double[,] LoadMatrixFromTSPLIB(string dir)
        {
            TspFileLoader fileLoader= new();
            StreamReader reader = new(dir); //"D:\\TSP\\TSP\\TSPLIB95\\tsp\\swiss42.tsp"
            TspFile tspFile = fileLoader.Load(reader);
            List<double> edgesList = tspFile.EdgeWeights;
            int nodesCount = Convert.ToInt32(Math.Sqrt(edgesList.Count));
            double[,] tempMatrix = new double[nodesCount, nodesCount];
            int index = 0;
            for(int row=0; row<nodesCount; row++)
            {
                for(int col=0; col<nodesCount; col++)
                {
                    tempMatrix[row, col] = edgesList[index];
                    index++;
                }
            }
            return tempMatrix;

        }
    }
}