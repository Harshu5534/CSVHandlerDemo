using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CsvHelperDemo
{
    public class CsvHandler
    {
        const string IMPORT_FILEPATH = @"E:\VisualPractise\CsvHelperDemo\Address.csv";
        const string EXPORT_FILEPATH = @"E:\VisualPractise\CsvHelperDemo\Export.csv";
        const string EXPORT_JSON_FILEPATH = @"E:\VisualPractise\CsvHelperDemo\AddressDetails.json";
        public static void ImplementationCsv()
        {
            using (var reader=new StreamReader(IMPORT_FILEPATH))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<AddressData>().ToList();
                    Console.WriteLine("After Reading SCV File");
                    foreach (var record in records)
                    {
                        Console.WriteLine(record.FirstName+" "+record.LastName+" "+record.Address+" "+record.City+" "+record.State+" "+record.PINCode);
                    }
                    using(var writter=new StreamWriter(EXPORT_FILEPATH))
                    {
                        using(var csvExport=new CsvWriter(writter,CultureInfo.InvariantCulture))
                        {
                            csvExport.WriteRecords(records);
                        }
                    }
                }
            }
        }
        public static void ImplementationJson()
        {
            using (var reader = new StreamReader(IMPORT_FILEPATH))
            {
                using (var Csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = Csv.GetRecords<AddressData>().ToList();
                    foreach (var record in records)
                    {
                        Console.WriteLine(record.FirstName + " " + record.LastName + " " + record.Address + " " + record.City + " " + record.State + " " + record.PINCode);
                    }
                    JsonSerializer serializer = new JsonSerializer();
                    using (var writer = new StreamWriter(EXPORT_JSON_FILEPATH))
                    {
                        using (var jsonWriter = new JsonTextWriter(writer))
                        {
                            serializer.Serialize(writer, records);

                        }
                    }
                }
            }
        }
    }
}
