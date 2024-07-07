using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace igraXO
{
    /// <summary>
    /// Interaction logic for windowIgrica.xaml
    /// </summary>
    public partial class windowIgrica : Window,INotifyPropertyChanged
    {
        Button[,] dugmad;
        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        private string igrac;

        public string Igrac
        {
            get { return igrac; }
            set { igrac = value; }
        }
        private string racunar;

        public string Racunar
        {
            get { return racunar; }
            set { racunar = value; }
        }
        private int scoreIgrac;

        public int ScoreIgrac
        {
            get { return scoreIgrac; }
            set 
            { 
                scoreIgrac = value;
                OnPropertyChanged();
            }
        }
        private int scoreRac;

        
        public int ScoreRac
        {
            get { return scoreRac; }
            set 
            { 
                scoreRac = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            napraviTablu();
            prviPotez();
        }

        public windowIgrica(string igrac, string ime)
        {
            InitializeComponent();
            this.Ime = ime;
            this.Igrac = igrac;
            this.Racunar = (Igrac == "X") ? "O" : "X";
            ScoreIgrac = 0; ScoreRac = 0;
            napraviTablu();
        }

        public void napraviTablu()
        {
            dugmad = new Button[3, 3];
            podloga.Children.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dugmad[i, j] = new Button();
                    dugmad[i, j].Width = podloga.ActualWidth / 3;
                    dugmad[i, j].Height = podloga.ActualHeight / 3;
                    dugmad[i, j].Visibility = Visibility.Visible;
                    dugmad[i, j].Click += WindowIgrica_Click;
                    dugmad[i, j].Tag = "0";
                    Canvas.SetTop(dugmad[i, j], dugmad[i, j].Height * i);
                    Canvas.SetLeft(dugmad[i, j], dugmad[i, j].Width * j);
                    podloga.Children.Add(dugmad[i, j]);
                }
            }
        }

        private void prviPotez()
        {
            if (Racunar == "X")
            {
                igraRacunar();
            }
        }

        private void WindowIgrica_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null && btn.Tag.ToString() == "0")
            {
                btn.Content = $"{Igrac}";
                btn.Tag = "1";
                if (!jeLiKraj())
                {
                    igraRacunar();
                }
                else
                {
                    napraviTablu();
                }
            }
        }

        private void igraRacunar()
        {
            foreach (var v in dugmad)
            {
                if (v.Tag.ToString() == "0")
                {
                    v.Content = $"{Racunar}";
                    v.Tag = "1";
                    break;
                }
            }
            if(jeLiKraj() )
            {
                napraviTablu();
            }
        }

        private bool jeLiKraj()
        {
            for (int i = 0; i < 3; i++)
            {
                if (dugmad[i, 0].Content != null &&
                    dugmad[i, 1].Content != null &&
                    dugmad[i, 2].Content != null &&
                    dugmad[i, 0].Content.ToString() == dugmad[i, 1].Content.ToString() &&
                    dugmad[i, 1].Content.ToString() == dugmad[i, 2].Content.ToString() &&
                    dugmad[i, 0].Tag.ToString() == "1")
                {
                    MessageBox.Show($"{dugmad[i, 0].Content} wins!");
                    if(Igrac == dugmad[0, i].Content.ToString())
                    {
                        ScoreIgrac++;
                    }
                    else
                    {
                        ScoreRac++;
                    }
                }
                if (dugmad[0, i].Content != null &&
                    dugmad[1, i].Content != null &&
                    dugmad[2, i].Content != null &&
                    dugmad[0, i].Content.ToString() == dugmad[1, i].Content.ToString() &&
                    dugmad[1, i].Content.ToString() == dugmad[2, i].Content.ToString() &&
                    dugmad[0, i].Tag.ToString() == "1")
                {
                    MessageBox.Show($"{dugmad[0, i].Content} wins!");
                    if (Igrac == dugmad[0,i].Content.ToString())
                    {
                        ScoreIgrac++;
                    }
                    else
                    {
                        ScoreRac++;
                    }
                    return true;
                }
            }
            if (dugmad[0, 0].Content != null &&
                dugmad[1, 1].Content != null &&
                dugmad[2, 2].Content != null &&
                dugmad[0, 0].Content.ToString() == dugmad[1, 1].Content.ToString() &&
                dugmad[1, 1].Content.ToString() == dugmad[2, 2].Content.ToString() &&
                dugmad[0, 0].Tag.ToString() == "1")
            {
                MessageBox.Show($"{dugmad[0, 0].Content} wins!");
                if (Igrac == dugmad[0, 0].Content.ToString())
                {
                    ScoreIgrac++;
                }
                else
                {
                    ScoreRac++;
                }
            }
            if (dugmad[0, 2].Content != null &&
                dugmad[1, 1].Content != null &&
                dugmad[2, 0].Content != null &&
                dugmad[0, 2].Content.ToString() == dugmad[1, 1].Content.ToString() &&
                dugmad[1, 1].Content.ToString() == dugmad[2, 0].Content.ToString() &&
                dugmad[0, 2].Tag.ToString() == "1")
            {
                MessageBox.Show($"{dugmad[0, 2].Content} wins!");
                if (Igrac == dugmad[0, 2].Content.ToString())
                {
                    ScoreIgrac++;
                }
                else
                {
                    ScoreRac++;
                }
                return true;
            }
            bool tie = true;
            foreach (var v in dugmad)
            {
                if (v.Tag.ToString() == "0")
                {
                    tie = false;
                    break;
                }
            }
            if (tie)
            {
                MessageBox.Show("It's a tie!");
                return true;
            }

            return false;
        }
    }
}
