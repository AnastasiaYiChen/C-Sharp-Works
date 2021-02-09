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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int i = 1;
        private int counter = 0;
        private static System.Windows.Threading.DispatcherTimer aTimer;
        private int t = 42000;
        

        public MainWindow()
        {
            InitializeComponent();
        }

        /*Next page*/
        private void nt_btn_Click(object sender, RoutedEventArgs e)
        {
            i++;
            
            if (i > 12)
            {
                i = 1; 
            }

            imageHolder.Source = new BitmapImage(new Uri("/golf" + i + ".JPG", UriKind.Relative));
        }

        /*Back page*/
        private void pf_btn_Click(object sender, RoutedEventArgs e)
        {
            i--;

            if (i < 1)
            {
                i = 12;
            }

            imageHolder.Source = new BitmapImage(new Uri("/golf" + i + ".JPG", UriKind.Relative));
            
        }

        /*interval slider change the animation interval*/
        private void interval_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            interval_count.Content = (int)interval_slider.Value;

        }

        /*Ratation Slider*/
        private void rotation_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            counter ++;
            if (counter > 12)
            {
                counter = 1;
            }

            counter --;
            if (counter < 1)
            {
                counter = 12;
            }


            imageHolder.Source = new BitmapImage(new Uri("/golf" + counter + ".JPG", UriKind.Relative));
            imageHolder.RenderTransform = new RotateTransform((int)rotation_slider.Value );
            angle.Content = (int)rotation_slider.Value;

        }

        private void start_btn_Click(object sender, RoutedEventArgs e)
        {          
            aTimer = new System.Windows.Threading.DispatcherTimer();
            aTimer.Tick += new System.EventHandler(OnTimeEvent);
            aTimer.Interval = new TimeSpan(0, 0, 0, 0, (int)interval_slider.Value);
            aTimer.Start();
        }

       /* picture move frame to frame by use counter */
        private void OnTimeEvent(object source, System.EventArgs e)
        {
            counter += 1;
            i += 5;
            imageHolder.Source = new BitmapImage(new Uri("/golf" + counter + ".JPG", UriKind.Relative));

            if (counter > 12)
            {
                counter = 1;                         
            }

            imageHolder.Source = new BitmapImage(new Uri("/golf" + counter + ".JPG", UriKind.Relative));
            imageHolder.RenderTransform = new RotateTransform(i);

        }

       

        private void Forward_btn_Click(object sender, RoutedEventArgs e)
        {
            aTimer = new System.Windows.Threading.DispatcherTimer();
            aTimer.Tick += new System.EventHandler(ForwordTimeEvent);
            aTimer.Interval = new TimeSpan(0, 0, 0, 0, (int)interval_slider.Value);
            aTimer.Start();
        }

        /*picture move frame to frame by use counter*/
        private void ForwordTimeEvent(object source, System.EventArgs e)
        {
            counter += 1;

            if (counter > 12)
            {
                counter = 1;
            }

            imageHolder.Source = new BitmapImage(new Uri("/golf" + counter + ".JPG", UriKind.Relative));

        }

        private void backward_Click(object sender, RoutedEventArgs e)
        {
            aTimer = new System.Windows.Threading.DispatcherTimer();
            aTimer.Tick += new System.EventHandler(BackwordTimeEvent);
            aTimer.Interval = new TimeSpan(0, 0, 0, 0, (int)interval_slider.Value);
            aTimer.Start();
        }

        private void BackwordTimeEvent(object source, System.EventArgs e)
        {
           
            counter--;


            if (counter < 1)
            {
                counter = 12;
            }

            imageHolder.Source = new BitmapImage(new Uri("/golf" + counter + ".JPG", UriKind.Relative));
        }

      

        /*Stop buttom, when click stop current page */
        private void stop_btn_Click(object sender, RoutedEventArgs e)
        {
            aTimer.Stop();
        }

        /*reset the frames to inital ang 0 and page 1*/
        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            imageHolder.Source = new BitmapImage(new Uri("/golf1.JPG", UriKind.Relative));
            imageHolder.RenderTransform = new RotateTransform(0);
        }

       
    }
}
