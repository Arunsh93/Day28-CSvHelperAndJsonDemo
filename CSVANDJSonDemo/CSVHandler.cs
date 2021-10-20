using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVANDJSonDemo
{
    class CSVHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string filePath = @"E:\ASP.NET\CSVANDJSonDemo\Address.csv";
            //string exportFilePath = @"E:\ASP.NET\CSVANDJSonDemo\Export.csv";
            string exportJsonFilePath = @"E:\ASP.NET\CSVANDJSonDemo\export.json";
            using (var reader = new StreamReader(filePath))
            
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data Successfully from CSV File!");

                foreach(AddressData addressData in records)
                {
                    Console.WriteLine(addressData.firstName);
                    Console.WriteLine(addressData.lastName);
                    Console.WriteLine(addressData.address);
                    Console.WriteLine(addressData.city);
                    Console.WriteLine(addressData.state);
                    Console.WriteLine(addressData.code);             
                }
                
                Console.WriteLine("**********Now Reading the CSV File and Write into JSON File***********");
/*
                //Writing into CSV File
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }*/
                //Write into Json File
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportJsonFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(sw, records);
                }

                Console.WriteLine("Successfully Exported!");
            }
        }
    }
}
