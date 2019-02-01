using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using WordWar.Global;
using WordWar.Handler;

namespace WordWar.View
{
    public partial class GameView : UserControl
    {
        public static EventHandler Menu;

        Random rnd = new Random();
        List<string> words = new List<string>();
        List<Brush> colors = new List<Brush>() { Brushes.BlueViolet, Brushes.Red, Brushes.LightGoldenrodYellow, Brushes.Yellow, Brushes.Green, Brushes.DarkBlue, Brushes.Cyan, Brushes.LightBlue, Brushes.DarkGreen, Brushes.YellowGreen, Brushes.Purple, Brushes.Pink };
        List<Label> displayedLabels = new List<Label>();

        double time = 5000;
        int wordCounter = 0;
        int life = 3;
        int level = 1;
        int score = 0;
        int levelUpAt = 5;
        int die = 20;
        public GameView()
        {
            InitializeComponent();
        }

        private void Game_Loaded(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            SetScore(score);
            SetLevel(level);
            ReadWords();
            Keyboard.Focus(txtText);

            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(time) };
            timer.Tick += (sender, args) =>
            {
                SetLabel();
                LevelSetter(ref timer);
                HealthSetter();
                IsTheEnd(timer);
            };
            timer.Start();
        }

        private void ReadWords()
        {
            using (StreamReader sr = new StreamReader("words.txt", Encoding.GetEncoding(1250)))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    words.Add(line);
                }
            }
        }

        private void SetLabel()
        {
            Label lb = new Label();
            lb.Content = GetRandomWord();
            lb.Foreground = Brushes.White;
            lb.Background = Brushes.Black;
            lb.FontFamily = new FontFamily("Bebas Neue");
            lb.FontSize = 20;
            lb.BorderThickness = new Thickness(1, 1, 1, 1);
            lb.BorderBrush = GetRandomColor();
            lb.Cursor = Cursors.Arrow;
            displayedLabels.Add(lb);
            int width = rnd.Next(100, 1180);
            int height = rnd.Next(100, 620);
            Canvas.SetTop(lb, height);
            Canvas.SetLeft(lb, width);
            cnv.Children.Add(lb);
        }

        private string GetRandomWord()
        {
            int randomNumber = 0;
            do
            {
                randomNumber = rnd.Next(0, words.Count);
            }
            while (words[randomNumber].Length > 15);
            return words[randomNumber];
        }

        private Brush GetRandomColor()
        {
            int randomNumber = rnd.Next(0, colors.Count);
            return colors[randomNumber];
        }

        private void LevelSetter(ref DispatcherTimer timer)
        {
            if (wordCounter % levelUpAt == 0 & wordCounter >= levelUpAt)
            {
                level = 1 + wordCounter / levelUpAt;
                SetLevel(level);
                time = time * 0.9;
                timer.Interval = TimeSpan.FromMilliseconds(time);
            }
        }

        private void SetLevel(int level)
        {
            lblLevel.Content = string.Format("Level: {0}", level);
        }

        private void HealthSetter()
        {
            if (displayedLabels.Count > die)
            {
                LoseHealth();
                die = die + 20;
            }
        }

        private void LoseHealth()
        {
            life--;
            switch (life)
            {
                case 2: Lifebar.Source = new BitmapImage(new Uri(@"/Pictures/2life.png", UriKind.Relative)); break;
                case 1: Lifebar.Source = new BitmapImage(new Uri(@"/Pictures/1life.png", UriKind.Relative)); break;
                case 0: Lifebar.Source = new BitmapImage(new Uri(@"/Pictures/0life.png", UriKind.Relative)); break;
            }
        }
        private void OneKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtText.Text = "";
            }
        }

        private void txtText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int n = displayedLabels.Count;
            if (n != 0)
            {
                string actualWord = txtText.Text;
                Label label = this.displayedLabels.Find((x) => x.Content.ToString().Equals(actualWord, StringComparison.CurrentCultureIgnoreCase));
                if (label != null)
                {
                    score += level * actualWord.Length + 50;
                    SetScore(score);
                    wordCounter++;
                    txtText.Text = "";
                    displayedLabels.Remove(label);
                    cnv.Children.Remove(label);
                }
            }
        }

        private void SetScore(int score)
        {
            lblScore.Content = string.Format("Score: {0}", score);
        }

        private void IsTheEnd(DispatcherTimer timer)
        {
            if (life == 0)
            {
                timer.Stop();
                MessageBox.Show(string.Format("Your score: {0}", score.ToString()));
                if (score > Globals.localUser.Score)
                {
                    RequestHandler rh = new RequestHandler();
                    Globals.localUser.Score = score;
                    rh.UpdateHighScore();
                }

                Reset();
                Menu?.Invoke(this, EventArgs.Empty);

            }
        }

        private void Reset()
        {
            cnv.Children.Clear();
            txtText.Text = "";
            Lifebar.Source = new BitmapImage(new Uri(@"/Pictures/3life.png", UriKind.Relative));

            rnd = new Random();
            words = new List<string>();
            displayedLabels = new List<Label>();

            time = 5000;
            wordCounter = 0;
            life = 3;
            level = 1;
            score = 0;
            levelUpAt = 5;
            die = 20;
        }
    }
}
