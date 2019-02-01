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
using WordWar.View;

namespace WordWar
{
    public partial class MainWindow : Window
    {
        public MenuView mv = new MenuView();
        public GameView gv = new GameView();
        public MainWindow()
        {
            InitializeComponent();
            mainGrid.Children.Add(mv);

            MenuView.Start += new EventHandler(StartGame);
            GameView.Menu += new EventHandler(OpenMenu);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        void StartGame(object sender, EventArgs e)
        {
            mainGrid.Children.Clear();
            mainGrid.Children.Add(gv);
        }

        void OpenMenu(object sender, EventArgs e)
        {
            mainGrid.Children.Clear();
            mainGrid.Children.Add(mv);
        }
    }
}
