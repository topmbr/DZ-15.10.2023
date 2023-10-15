using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using NCalc;

namespace WindowsFormsApp29
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Инициализация элемента управления ZedGraphControl
            InitializeGraph();

        }
        private void InitializeGraph()
        {
            GraphPane graphPane = zedGraphControl1.GraphPane;
            graphPane.CurveList.Clear();

            // Настройки для осей и подписей
            graphPane.XAxis.Title.Text = "X";
            graphPane.YAxis.Title.Text = "Y";

            // Обновление отображения графика
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void PlotGraph(string function)
        {
            GraphPane graphPane = zedGraphControl1.GraphPane;
            graphPane.CurveList.Clear();

            // Создание списка точек для графика
            PointPairList points = new PointPairList();
            Expression expression = new Expression(function);
            for (float x = -10; x <= 10; x += 0.1f)
            {
                expression.Parameters["x"] = x;
                float y = (float)expression.Evaluate(); // Используем float для хранения значений
                points.Add(x, y);
            }

            // Создание кривой для графика
            LineItem curve = graphPane.AddCurve("График функции", points, Color.Blue, SymbolType.None);

            // Обновление отображения графика
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void buttonPlot_Click_1(object sender, EventArgs e)
        {
            string function = textBoxFunction.Text;
            PlotGraph(function);
        }
    }

}
