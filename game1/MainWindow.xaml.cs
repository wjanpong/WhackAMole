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
using System.Timers;
using System.Windows.Threading;//For timing
using System.Media;

namespace game1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int current_score;
        DispatcherTimer Timer = new DispatcherTimer();
        Random row_col = new Random();
        

        bool showImg = false;
        public MainWindow()
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(timer_tick);
           
       
        }

        int time = 60;
        private void timer_tick(object sender, EventArgs e)
        {
            if (time >= 0)
            {
                time--;
                Count.Content = time.ToString();
                showImg = true;
                if (showImg)
                {
                    int numb = row_col.Next(1, 4);
                    int row1, col1, row2, col2, row3, col3;
                    switch(numb)
                    {
                        case 1: row1 = row_col.Next(0, 4);
                                col1 = row_col.Next(0, 4);
                                Grid.SetRow(Mole, row1);
                                Grid.SetColumn(Mole, col1);
                                Mole.Visibility = Visibility.Visible;
                                Mole1.Visibility = Visibility.Hidden;
                                Mole2.Visibility = Visibility.Hidden;
                                break;
                        case 2: 
                                row1 = row_col.Next(0, 4);
                                col1 = row_col.Next(0, 4);
                                row2 = row_col.Next(0, 4);
                                col2 = row_col.Next(0, 4);
                                Grid.SetRow(Mole, row1);
                                Grid.SetColumn(Mole, col1);
                                Grid.SetRow(Mole1, row2);
                                Grid.SetColumn(Mole1, col2);
                                Mole.Visibility = Visibility.Visible;
                                Mole1.Visibility = Visibility.Visible;
                                Mole2.Visibility = Visibility.Hidden;
                                break;
                        case 3:
                                row1 = row_col.Next(0, 4);
                                col1 = row_col.Next(0, 4);
                                row2 = row_col.Next(0, 4);
                                col2 = row_col.Next(0, 4);
                                row3 = row_col.Next(0, 4);
                                col3 = row_col.Next(0, 4);
                                Grid.SetRow(Mole, row1);
                                Grid.SetColumn(Mole, col1);
                                Grid.SetRow(Mole1, row2);
                                Grid.SetColumn(Mole1, col2);
                                Grid.SetRow(Mole2, row3);
                                Grid.SetColumn(Mole2, col3);
                                Mole.Visibility = Visibility.Visible;
                                Mole1.Visibility = Visibility.Visible;
                                Mole2.Visibility = Visibility.Visible;
                                break;
                        default:
                                break;
                    }
 
                }
                if (time == 0)
                {
                    showImg = false;
                    Timer.Stop();
                    MessageBox.Show("Time over" + "\n" + "Score: " + show_score.Text);

                    
                }
            }
        }
        public void Start_Click(object sender, RoutedEventArgs e)
        {
            if (easy.IsChecked == true)
                Timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            else if (medium.IsChecked == true)
                Timer.Interval = new TimeSpan(0, 0, 0, 0, 750);
            else if (hard.IsChecked == true)
                Timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            SystemSounds.Asterisk.Play();
            current_score = 0;
            show_score.Text = current_score.ToString();
            time = 60;
            Timer.Start();
           
        }

        public void Reset_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Exclamation.Play();
            current_score = 0;
            show_score.Text = current_score.ToString();
            Timer.Stop();
            showImg = false;
            time= 60;
            Count.Content = time.ToString();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            Timer.Stop();
            showImg = false;
        }

        private void click_click(object sender, MouseButtonEventArgs e)
        {
            current_score++;
            show_score.Text = current_score.ToString(); 
            if (e.OriginalSource == Mole)
            {
                Mole.Visibility = Visibility.Hidden;
            }
            if (e.OriginalSource == Mole1)
            {
                Mole1.Visibility = Visibility.Hidden;
            }
            if (e.OriginalSource == Mole2)
            {
                Mole2.Visibility = Visibility.Hidden;
            }
        }

 
    }
}
