using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int previousRow = -1, previousCol = -1, row, col;
        Image previousImg, img;
        Button previousBtn, clickedBtn;
   
        int[,] myboard = new int[4, 4]
        {
            {1, 5, 3, 7},
            {8, 2, 4, 6},
            {4, 3, 1, 7},
            {8, 2, 5, 6}
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clickedBtn = (Button)sender;

           // String buttonName = b.Name; // B00, B01, B10, B11

            // Find out what row and column the user clicked on
            row = Convert.ToInt32(clickedBtn.Name.Substring(1, 1));
            col = Convert.ToInt32(clickedBtn.Name.Substring(2, 1));

            String imageFile = myboard[row, col] + ".jpg";

            //MessageBox.Show("/" + imageFile + "\"");
           
            img = (Image)clickedBtn.Content;
            img.Source = new BitmapImage(new Uri("/" + imageFile, UriKind.Relative)); ;

            
            if(previousRow == -1 && previousCol == -1) {
                previousRow = row;
                previousCol = col;
                previousImg = img;
                previousBtn = clickedBtn;
            }
            else {
                Decision();
            }
            
        }

        private void Decision()
        {
            if (myboard[row, col] == myboard[previousRow, previousCol])
            {
                //Thread.Sleep(3000);
                /*img.Source = new BitmapImage(new Uri("/" + "black.jpg", UriKind.Relative));
                cImg.Source = new BitmapImage(new Uri("/" + "black.jpg", UriKind.Relative));*/
                previousBtn.IsEnabled = false;
                clickedBtn.IsEnabled = false;
                previousCol = -1;
                previousRow = -1;
            }
            else
            {
                //Thread.Sleep(3000);
                //img.Source = new BitmapImage(new Uri("/" + "placeHolder.jpg", UriKind.Relative));
                previousImg.Source = new BitmapImage(new Uri("/" + "placeHolder.jpg", UriKind.Relative));
                previousCol = col;
                previousRow = row;
                previousBtn = clickedBtn;
                previousImg = img;
            }
        }
    }
}
