using System.Windows;
using System.Windows.Controls;

namespace BusinessCal
{
    /// <summary>
    /// Логика взаимодействия для itemsPage.xaml
    /// </summary>
    public partial class itemsPage : Page
    {
        public MainWindow mainWindow;
        public itemsPage()
        {
            InitializeComponent();
        }
        public itemsPage(int selMonth, MainWindow mainWindow):this()
        {
            this.mainWindow= mainWindow;    
            int[] monthDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            for (int i = 0; i < monthDays[selMonth - 1]; i++)
            {
                dayBtn dayButton = new dayBtn();
                wrapPanel.Children.Add(dayButton);
                dayButton.Day.Content = (i + 1).ToString();
                dayButton.Name = "Button" + i;
                dayButton.btn.Click += Btn_Click;
            }
        }

        private void Btn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mainWindow.itemsFrame.Content = new selectSmth(mainWindow);
        }
    }
}
