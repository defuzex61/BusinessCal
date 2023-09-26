using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

namespace BusinessCal
{
    /// <summary>
    /// Логика взаимодействия для selectSmth.xaml
    /// </summary>
    public partial class selectSmth : Page
    {
        private item selItem = new item();
        private MainWindow _main =new MainWindow();
        private int _num;
        item selItem0 = new item();
        item selItem1 = new item();
        item selItem2 = new item();

        public selectSmth()
        {
            InitializeComponent();

            fillLb(selItem0, "/pc.png", "Кампутить в аблетон или фл",1);
            fillLb(selItem1, "/mic.png", "Микрофонить",2);
            fillLb(selItem2, "/sampler.png", "Сифонить",3);
            ItemModel model = new ItemModel();
            model.date = Convert.ToDateTime(_main.datePicker.Text);
            int itemIndex = ItemModel.FindNote(model.date);
            if (itemIndex != -1)
            {
                ItemModel modelList = ItemModel.itemList[itemIndex];
                selItem0.isSelected.IsChecked = model.frstItem;
                selItem1.isSelected.IsChecked = model.scndItem;
                selItem2.isSelected.IsChecked = model.thrdItem;
            }
        }
        public selectSmth(MainWindow mainWindow): this() 
        {
            this._main = mainWindow;
        }
            
        private  void fillLb(item selItem,string uri, string mes, int num)
        {
            selItem.cardTb.Text = mes;
            selItem.itemImg.Source = new BitmapImage(new Uri((uri), UriKind.Relative));
            itemsLb.Items.Add(selItem);
            
           
        }
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            ItemModel model = new ItemModel();
            model.date = Convert.ToDateTime(_main.datePicker.Text);
            int itemIndex = ItemModel.FindNote(model.date);
            if (itemIndex != -1)
            {
                ItemModel modelList = ItemModel.itemList[itemIndex];
                        modelList.frstItem = (bool)selItem0.isSelected.IsChecked;

                        modelList.scndItem = (bool)selItem1.isSelected.IsChecked;

                        modelList.thrdItem = (bool)selItem2.isSelected.IsChecked;


                

            }
            else
            {
                ItemModel modelList = new ItemModel();

                        modelList.frstItem = (bool)selItem0.isSelected.IsChecked;

                        modelList.scndItem = (bool)selItem1.isSelected.IsChecked;

                        modelList.thrdItem = (bool)selItem2.isSelected.IsChecked;

                ItemModel.itemList.Add(modelList);
            }
            Serialization.Serialize<List<ItemModel>>(ItemModel.itemList);
        }
        
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            _main.itemsFrame.Content = new itemsPage(_main.selDay.Month ,_main);
        }
    }
}
