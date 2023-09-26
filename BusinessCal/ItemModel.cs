using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCal
{
    internal class ItemModel
    {
        public DateTime date { get; set; }
        public bool frstItem { get; set; }
        public bool scndItem { get; set; }
        public bool thrdItem { get; set; }

        public static List<ItemModel> itemList = new List<ItemModel>();

        public static int FindNote(DateTime date)
        {
            foreach (var item in itemList)
            {
                if (item.date == date)
                {
                    return itemList.IndexOf(item);
                }
            }
            return -1;
        }

        public static void ReadNotes()
        {
            itemList = Serialization.Deserialize<List<ItemModel>>();
        }

    }
}
