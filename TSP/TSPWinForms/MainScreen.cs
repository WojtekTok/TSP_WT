using ScottPlot;
using System.Diagnostics;
using System.Windows.Forms;
using TSPLibrary;
using OfficeOpenXml;

namespace TSPWinForms
{
    public partial class MainScreen : Form
    {
        private CostMatrix Matrix;
        private string? selectedDirectory;
        private double bestCost;
        public MainScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillUI();
        }

        private void FillUI()
        {
            Stopwatch stopwatch = new();
            if (selectedDirectory == null)
            {
                MessageBox.Show("No file chosen.");
                return;
            }
            Population population = new(Matrix, (int)numericUpDown2.Value);
            Evolutionary EA = new(population);
            BeeColony ABC = new(population.DeepClone());
            GreyWolf GWO = new(population.DeepClone());
            bool crossoverDet = false;
            bool mutationDet = false;
            if (radioButton1.Checked)
                crossoverDet = false;
            else if (radioButton2.Checked)
                crossoverDet = true;
            if (radioButton3.Checked)
                mutationDet = false;
            else if (radioButton4.Checked)
                mutationDet = true;

            stopwatch.Start();
            Solution EABest = EA.Solve((int)numericUpDown1.Value, mutationDet, crossoverDet);
            stopwatch.Stop();
            label8.Text = EABest.cost.ToString();
            long EATime = stopwatch.ElapsedMilliseconds;
            label6.Text = EATime.ToString();

            stopwatch.Start();
            Solution ABCBest = ABC.Solve((int)numericUpDown1.Value, mutationDet, crossoverDet);
            stopwatch.Stop();
            label13.Text = ABCBest.cost.ToString();
            long ABCTime = stopwatch.ElapsedMilliseconds - EATime;
            label11.Text = ABCTime.ToString();

            stopwatch.Start();
            Solution GWOBest = GWO.Solve((int)numericUpDown1.Value, mutationDet, crossoverDet);
            stopwatch.Stop();
            label17.Text = GWOBest.cost.ToString();
            long GWOTime = stopwatch.ElapsedMilliseconds - ABCTime;
            label15.Text = GWOTime.ToString();

            double[] EAArr = EA.LowestCostsList.ToArray();
            label7.Text = Array.IndexOf(EAArr, EABest.cost).ToString();
            double[] ABCArr = ABC.LowestCostsList.ToArray();
            label12.Text = Array.IndexOf(ABCArr, ABCBest.cost).ToString();
            double[] GWOArr = GWO.LowestCostsList.ToArray();
            label16.Text = Array.IndexOf(GWOArr, GWOBest.cost).ToString();
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.AddScatter(Enumerable
                .Range(0, EAArr.Count())
                .Select(x => (double)x)
                .ToArray(), EAArr, label: "EA");
            formsPlot1.Plot.AddScatter(Enumerable
                .Range(0, ABCArr.Count())
                .Select(x => (double)x)
                .ToArray(), ABCArr, label: "ABC");
            formsPlot1.Plot.AddScatter(Enumerable
                .Range(0, GWOArr.Count())
                .Select(x => (double)x)
                .ToArray(), GWOArr, label: "GWO");
            formsPlot1.Plot.PlotHLine(y: bestCost, color: Color.Red, label: "best cost");
            formsPlot1.Plot.Legend(location: Alignment.LowerLeft);
            formsPlot1.Refresh();
            var eacmean = EA.MeanCrossover();
            var eammean = EA.MeanMutation();
            var abccmean = ABC.MeanCrossover();
            var abcmmean = ABC.MeanMutation();
            var gwocmean = GWO.MeanCrossover();
            var gwommean = GWO.MeanMutation();
            label26.Text = EA.crossoverCounter.ToString();
            label25.Text = ABC.crossoverCounter.ToString();
            label24.Text = GWO.crossoverCounter.ToString();
            label34.Text = eacmean.ToString("0.000000");
            label33.Text = abccmean.ToString("0.000000");
            label32.Text = gwocmean.ToString("0.000000");
            label30.Text = EA.mutationCounter.ToString();
            label29.Text = ABC.mutationCounter.ToString();
            label28.Text = GWO.mutationCounter.ToString();
            label38.Text = eammean.ToString("0.000000");
            label37.Text = abcmmean.ToString("0.000000");
            label36.Text = gwommean.ToString("0.000000");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "All Files (*.*)|*.*";
                string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string defaultDirectory = Path.Combine(executableDirectory, "..\\..\\..\\..\\TSPLIB95");
                openFileDialog.InitialDirectory = Path.GetFullPath(defaultDirectory);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    selectedDirectory = Path.GetDirectoryName(selectedFilePath);
                    selectedDirectory = Path.Combine(selectedDirectory, Path.GetFileName(selectedFilePath));
                }
                try
                {
                    Matrix = new(selectedDirectory);
                    label22.Text = Path.GetFileName(selectedDirectory);
                    label19.Text = Matrix.nodesNumber.ToString();

                    string directory = Path.GetDirectoryName(selectedDirectory);
                    string fileName = Path.GetFileNameWithoutExtension(selectedDirectory);
                    bestCost = BestSolutionFound(directory, fileName);
                    label21.Text = bestCost.ToString();
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Choose different file that contains Edge Weights");
                }
                catch (NotSupportedException)
                {
                    MessageBox.Show("Choose .tsp or .atsp files only.");
                }
            }
        }

        private double BestSolutionFound(string directory, string fileName)
        {
            string[] lines = File.ReadAllLines(Path.Combine(directory, "bestSolutions.txt"));
            string targetLine = lines.FirstOrDefault(line => line.StartsWith(fileName));
            string[] parts = targetLine.Split(':');
            double.TryParse(parts[1], out double value);
            return value;
        }

        private void GenerateData()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string filePath = Path.Combine("..\\..\\..\\..\\..\\..\\TSP", "TestData.xlsx");
            filePath = Path.GetFullPath(filePath);

            // Create a new Excel package
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Get the worksheet
                var worksheet = package.Workbook.Worksheets["Sheet1"];

                // Find the next available row
                int startRow = worksheet.Dimension?.Rows ?? 1;
                startRow++;

                // Name of file, best cost, population size, iterations, mutation, crossover
                worksheet.Cells["A" + startRow].Value = label22.Text;
                worksheet.Cells["B" + startRow].Value = label21.Text;
                worksheet.Cells["C" + startRow].Value = numericUpDown2.Value;
                worksheet.Cells["D" + startRow].Value = numericUpDown1.Value;
                worksheet.Cells["E" + startRow].Value = radioButton2.Checked;
                worksheet.Cells["F" + startRow].Value = radioButton4.Checked;
                // Write data to rows in a loop
                for (int i = 0; i < 10; i++)
                {
                    FillUI();
                    int rowNumber = startRow + 1 + i;//8 7 6 26
                    worksheet.Cells["A" + rowNumber].Value = label8.Text;
                    worksheet.Cells["B" + rowNumber].Value = label7.Text;
                    worksheet.Cells["C" + rowNumber].Value = label6.Text;
                    worksheet.Cells["D" + rowNumber].Value = label26.Text;
                    worksheet.Cells["E" + rowNumber].Value = label34.Text;
                    worksheet.Cells["F" + rowNumber].Value = label30.Text;
                    worksheet.Cells["G" + rowNumber].Value = label38.Text;
                    worksheet.Cells["H" + rowNumber].Value = label13.Text;
                    worksheet.Cells["I" + rowNumber].Value = label12.Text;
                    worksheet.Cells["J" + rowNumber].Value = label12.Text;
                    worksheet.Cells["K" + rowNumber].Value = label25.Text;
                    worksheet.Cells["L" + rowNumber].Value = label33.Text;
                    worksheet.Cells["M" + rowNumber].Value = label29.Text;
                    worksheet.Cells["N" + rowNumber].Value = label37.Text;
                    worksheet.Cells["O" + rowNumber].Value = label17.Text;
                    worksheet.Cells["P" + rowNumber].Value = label16.Text;
                    worksheet.Cells["Q" + rowNumber].Value = label15.Text;
                    worksheet.Cells["R" + rowNumber].Value = label24.Text;
                    worksheet.Cells["S" + rowNumber].Value = label32.Text;
                    worksheet.Cells["T" + rowNumber].Value = label28.Text;
                    worksheet.Cells["U" + rowNumber].Value = label36.Text;
                }

                // Save the package to the specified file path
                package.Save();            
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenerateData();
        }
    }
}