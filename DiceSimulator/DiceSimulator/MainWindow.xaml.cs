//Author: Pengshuo Liu, Zalak Patel, Jyoti Mittal
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DiceSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int NUM_RANDOM_VALUES = 2;
        const int LOWER_BOUND = 1;
        const int UPPER_BOUND = 7;
        const string FILENAME = "output.txt";

        readonly StringBuilder output = new StringBuilder();
        readonly string fullName;
        readonly Random r = new Random();

        int saveCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            //Background color
            TheGrid.Background = new LinearGradientBrush(Colors.AliceBlue, Colors.Azure, 45);
            List.Background = new LinearGradientBrush(Colors.AliceBlue, Colors.Azure, 45);
            DoIt.Background = new SolidColorBrush(Colors.AliceBlue);
            Save.Background = new SolidColorBrush(Colors.AliceBlue);

            //Create file path
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Dice Simulator");

            //Create directory
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            //Create full file path name
            fullName = Path.Combine(filePath, FILENAME);

            //Record program running time at the beginning
            File.AppendAllText(fullName, $"New run starting at " +
                $"{DateTime.Now:MMMM dd, yyyy HH:mm:ss}{Environment.NewLine}");
        }

        private void DoIt_Click(object sender, RoutedEventArgs e)
        {
            //Create path for images
            Uri Uri1 = new Uri("Images/Die1.bmp", UriKind.Relative);
            Uri Uri2 = new Uri("Images/Die2.bmp", UriKind.Relative);
            Uri Uri3 = new Uri("Images/Die3.bmp", UriKind.Relative);
            Uri Uri4 = new Uri("Images/Die4.bmp", UriKind.Relative);
            Uri Uri5 = new Uri("Images/Die5.bmp", UriKind.Relative);
            Uri Uri6 = new Uri("Images/Die6.bmp", UriKind.Relative);

            //Generate 2 dices numbers
            for (int x = 0; x < NUM_RANDOM_VALUES; x++)
            {
                int dieValue = r.Next(LOWER_BOUND, UPPER_BOUND); //Generate a 1-6 random number
                switch (dieValue)//Select images according to numbers, and put image in the right location
                {
                    case 1:
                        if (x == 0) //Whether this image goes to first location or second location.
                            DiceImage1.Source = new BitmapImage(Uri1);
                        else
                            DiceImage2.Source = new BitmapImage(Uri1);
                        break;
                    case 2:
                        if (x == 0)
                            DiceImage1.Source = new BitmapImage(Uri2);
                        else
                            DiceImage2.Source = new BitmapImage(Uri2);
                        break;
                    case 3:
                        if (x == 0)
                            DiceImage1.Source = new BitmapImage(Uri3);
                        else
                            DiceImage2.Source = new BitmapImage(Uri3);
                        break;
                    case 4:
                        if (x == 0)
                            DiceImage1.Source = new BitmapImage(Uri4);
                        else
                            DiceImage2.Source = new BitmapImage(Uri4);
                        break;
                    case 5:
                        if (x == 0)
                            DiceImage1.Source = new BitmapImage(Uri5);
                        else
                            DiceImage2.Source = new BitmapImage(Uri5);
                        break;
                    case 6:
                        if (x == 0)
                            DiceImage1.Source = new BitmapImage(Uri6);
                        else
                            DiceImage2.Source = new BitmapImage(Uri6);
                        break;
                    default:
                        break;
                }
           
                List.Items.Add(dieValue); // Add number to list
                output.Append($"{dieValue}{(x < NUM_RANDOM_VALUES - 1 ? "," : "")} "); //Add number to output text
            }
            List.Items.Add("^=^"); //Add a dotted line to list
            output.AppendLine(); // Start a new line in output text
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            output.Insert(0, $"Saved {++saveCount} times.{Environment.NewLine}"); //Record save times in output text
            File.AppendAllText(fullName, output.ToString()); //Write all generated numbers into file
            output.Clear();
            List.Items.Clear();
        }
    }
}

        /*ImageList imageList = new ImageList();
            string[] imgs = { "Images/Die1.bmp", "Images/Die2.bmp", "Images/Die3.bmp", "Images/Die4.bmp", 
                "Images/Die5.bmp", "Images/Die6.bmp" };
            foreach (var img in imgs)
            {
                imageList.Images.Add(Image.FromFile(img));
            }*/

        // List.Items.Add(Path.GetFullPath("Images/Die1.bmp"));
        //Image img = new Image();
        //img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Logo.png"));
        //Bitmap image1 = (Bitmap)Image.FromFile(FILENAME);

