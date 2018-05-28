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

namespace U5TowerHanoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 0;
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            for (int i = 1; i < 4; i++) {
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = Brushes.Black;
                rectangle.Height = 125;
                rectangle.Width = 6;
                Canvas.SetLeft(rectangle, i * 150 -25);
                Canvas.SetTop(rectangle, 200);
                canvas.Children.Add(rectangle);
                    }
            Rectangle rect = new Rectangle();
            rect.Fill = Brushes.Black;
            rect.Height = 6;
            rect.Width = 400;
            Canvas.SetLeft(rect, 75);
            Canvas.SetTop(rect, 321);
            canvas.Children.Add(rect);
        }

        public void gameTimer_Tick(object sender, EventArgs e)
        {
           counter++;
        }

        public virtual void RemoveRange(int index, int count)
        {
        }
        
        public void btnRun_Click(object sender, RoutedEventArgs e)
        {
            int cG = Convert.ToInt32(txtInput.Text);
            canvas.Children.RemoveRange(8, 7);
            gameTimer.Start();
            counter = 0;
            if (cG > 7)
            {
                MessageBox.Show("Number must be under 8");
            }
            else
            {
                Rectangle[] rectangle = new Rectangle[cG];

                    for (int i = 0; i < cG; i++)
                    {
                        rectangle[i] = new Rectangle();
                        rectangle[i].Fill = Brushes.Red;
                        rectangle[i].Stroke = Brushes.Black;
                        rectangle[i].StrokeThickness = 1;
                        rectangle[i].Height = 10;
                        rectangle[i].Width = 70 - i * 10;
                        Canvas.SetLeft(rectangle[i], 93 + i * 5);
                        Canvas.SetTop(rectangle[i], 312 - i * 10);
                        canvas.Children.Add(rectangle[i]);
                    }
                int x = 0;
                        while (312 - x * 10 > 210 && x < cG)
                        {                            Canvas.SetTop(rectangle[x], 312 - x * 10 - counter);
                        x++;
                        }
                }
            }
        }
    }
