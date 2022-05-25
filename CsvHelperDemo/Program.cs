using System;

namespace CsvHelperDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading The Data From The File");
            CsvHandler.ImplementationCsv();
            CsvHandler.ImplementationJson();
        }
    }
}