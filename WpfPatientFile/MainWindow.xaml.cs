using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text;
namespace WpfPatientFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string DIR_PATH = @"C:\Users\vonst\Desktop\test\";
        public const string FILE_EXT = ".txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string content = textBoxContent.Text;
            string filename = texBoxFilename.Text;

            using (FileStream fs = File.Create(DIR_PATH + filename + FILE_EXT))
            {
                byte[] contentConvertedToBytes = Encoding.ASCII.GetBytes(content);
                fs.Write(contentConvertedToBytes, 0, contentConvertedToBytes.Length);
            }

            MessageBox.Show("File created.");
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            string filename = texBoxFilename.Text;

            using (FileStream fs = File.OpenRead(DIR_PATH + filename + FILE_EXT))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    textBoxContent.Text = content; 
                }

            }

        }
    }
}