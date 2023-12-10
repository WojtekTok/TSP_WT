using ScottPlot;
using System.Diagnostics;
using TSPLibrary;

namespace TSPWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CostMatrix macierz = new("..\\..\\..\\..\\TSPLIB95\\atsp\\br17.atsp");
            Stopwatch stopwatch = new();
            Population population = new(macierz, (int)numericUpDown2.Value);
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
            label6.Text = stopwatch.ElapsedMilliseconds.ToString();

            stopwatch.Start();
            Solution ABCBest = ABC.Solve((int)numericUpDown1.Value, mutationDet, crossoverDet);
            stopwatch.Stop();
            label13.Text = ABCBest.cost.ToString();
            label11.Text = stopwatch.ElapsedMilliseconds.ToString();

            stopwatch.Start();
            Solution GWOBest = GWO.Solve((int)numericUpDown1.Value, mutationDet, crossoverDet);
            stopwatch.Stop();
            label17.Text = GWOBest.cost.ToString();
            label15.Text = stopwatch.ElapsedMilliseconds.ToString();

            double[] EAArr = EA.LowestCostsList.ToArray();
            double[] ABCArr = ABC.LowestCostsList.ToArray();
            double[] GWOArr = GWO.LowestCostsList.ToArray();
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
            formsPlot1.Plot.Legend(location: Alignment.LowerLeft);
            formsPlot1.Refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}