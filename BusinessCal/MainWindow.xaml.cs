using System.Windows.Controls;
using System.Windows;
using System;
using System.Threading.Tasks;

namespace BusinessCal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public DateTime selDay = new DateTime();
        public MainWindow()
        {
            InitializeComponent();
            selDay = DateTime.Today;
            datePicker.Text = selDay.ToString();
            itemsFrame.Content = new itemsPage(selDay.Month, this);
            
        }
        
       
        private void prevBtn_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = selDay.AddDays(-1);
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = selDay.AddDays(1);
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            selDay = (DateTime)datePicker.SelectedDate;
            itemsFrame.Content = new itemsPage(selDay.Month,this);

            
        }
    }
}