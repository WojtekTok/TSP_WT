using ScottPlot;
using System.Diagnostics;
using System.Windows.Forms;
using TSPLibrary;

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
            var abcmmmean = ABC.MeanMutation();
            var gwocmean = GWO.MeanCrossover();
            var gwommean = GWO.MeanMutation();
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
    }
}