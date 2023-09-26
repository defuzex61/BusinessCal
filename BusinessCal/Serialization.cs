using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCal
{
    public static class Serialization
    {
        public static void Serialize<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText("calRecords.json", json);
        }

        public static T Deserialize<T>()
        {
            string deserialiseObj = File.ReadAllText("calRecords.json");   
            return JsonConvert.DeserializeObject<T>(deserialiseObj); 
        }
    }

}
