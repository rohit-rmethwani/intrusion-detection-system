using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Intrusion_detection_system
{
    /// <summary>
    /// Interaction logic for IdsHome.xaml
    /// </summary>
    public partial class IdsHome : Page
    {
        private string filePath = string.Empty;
        public IdsHome()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog openFolderDialog = new System.Windows.Forms.FolderBrowserDialog())
            {

                if (openFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFolderDialog.SelectedPath;
                    PathField.Text = filePath;
                }
            }
        }
        private void Watch_Clicked(object sender, RoutedEventArgs e)
        {
            if(filePath.Length > 0)
            {
                this.NavigationService.Navigate(new IdsReports(this.filePath));
            }
            else
            {
                Console.WriteLine("Please select the folder first");
            }
        }
    }
}
