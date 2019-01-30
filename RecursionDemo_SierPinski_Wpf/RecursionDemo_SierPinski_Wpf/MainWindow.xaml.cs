using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecursionDemo_SierPinski_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point P0, P1, P2;
        public MainWindow()
        {
            InitializeComponent();
            P0 = new Point(Cnv.Width / 2, 30);
            P1 = new Point(30, Cnv.Height - 30);
            P2 = new Point(Cnv.Width - 30, Cnv.Height - 30);

            DrawSierPinski(P0, P1, P2, 1);
        }

        public void DrawSierPinski(Point P0, Point P1, Point P2, int Level)
        {
            if (Level == 1)
            {
                Line l1 = new Line();
                l1.Stroke = Brushes.Red;
                l1.StrokeThickness = 1;
                l1.X1 = P0.X; l1.Y1 = P0.Y;
                l1.X2 = P1.X; l1.Y2 = P1.Y;
                Cnv.Children.Add(l1);

                Line l2 = new Line();
                l2.Stroke = Brushes.Red;
                l2.StrokeThickness = 1;
                l2.X1 = P1.X; l2.Y1 = P1.Y;
                l2.X2 = P2.X; l2.Y2 = P2.Y;
                Cnv.Children.Add(l2);

                Line l3 = new Line();
                l3.Stroke = Brushes.Red;
                l3.StrokeThickness = 1;
                l3.X1 = P2.X; l3.Y1 = P2.Y;
                l3.X2 = P0.X; l3.Y2 = P0.Y;
                Cnv.Children.Add(l3);
            }
            else
            {
                Point PF0 = new Point((P0.X + P1.X) / 2, (P0.Y + P1.Y) / 2);
                Point PF1 = new Point((P1.X + P2.X) / 2, (P1.Y + P2.Y) / 2);
                Point PF2 = new Point((P2.X + P0.X) / 2, (P2.Y + P0.Y) / 2);

                DrawSierPinski(P0, PF0, PF2, Level - 1);
                DrawSierPinski(PF0, P1, PF1, Level - 1);
                DrawSierPinski(PF2, PF1, P2, Level - 1);
            }
        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lb1_level != null)
            {
                lb1_level.Content = "Level: " + sb_level.Value.ToString();
                DrawSierPinski(P0, P1, P2, (int)sb_level.Value);
            }
        }
    }
}
