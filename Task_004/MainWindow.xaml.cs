using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
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

namespace Task_004
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _path = @"C:\Games\Isolated.txt";        

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForAssembly();
            
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(_path, FileMode.OpenOrCreate, iso))
            {                
                byte[] buffer = Encoding.Default.GetBytes(MyTextBox.Text);
                await stream.WriteAsync(buffer, 0, buffer.Length);
            }

            MyTextBox.Clear();

            Console.WriteLine(MessageBox.Show("The file has been saved!"));
        }
    }
}
