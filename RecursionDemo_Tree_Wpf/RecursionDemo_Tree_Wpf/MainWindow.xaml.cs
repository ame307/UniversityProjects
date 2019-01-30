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

namespace RecursionDemo_Tree_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double x;
        double y;
        double angle;
        double length;
        double shortening;
        double rotation;
        public MainWindow()
        {
            InitializeComponent();
            x = cvCanvas.Width / 2;
            y = cvCanvas.Height - 20;
            angle = 90;
            length = 100;
            shortening = 0.73;
            rotation = 30;


            DrawBranch(x, y, angle, length, shortening, rotation, 1);
        }

        private void DrawBranch(double x, double y, double angle, double length, double shortening, double rotatatiton, int level)
        {
            double x1 = x + length * Math.Cos(angle * Math.PI / 180);
            double y1 = y - length * Math.Sin(angle * Math.PI / 180);

            if (level == 1)
            {
                cvCanvas.Children.Add(new Line() { X1 = x, Y1 = y, X2 = x1, Y2 = y1, Stroke = Brushes.Black, StrokeThickness = 2 });
            }
            else
            {
                DrawBranch(x1, y1, angle + rotation, length * shortening, shortening, rotation, level - 1);
                DrawBranch(x1, y1, angle - rotation, length * shortening, shortening, rotation, level - 1);
                DrawBranch(x1, y1, angle, length * shortening, shortening, rotation, level - 1);
            }

        }

        private void sbLevel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lb1Level != null)
            {
                lb1Level.Content = "Level: " + sbLevel.Value.ToString();
                DrawBranch(x, y, angle, length, shortening, rotation, (int)sbLevel.Value);
            }
        }
    }
}
