using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Infrastructure.Files
{
    public class CsvFileHelper
    {
        public static List<T> ReadCsvFile<T>(string filePath)
        {
            List<T> records = new List<T>();
            try
            {
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                records = csv.GetRecords<T>().ToList();
            }
            catch(Exception ex)
            {

            }
        
            return records;
        }
    }
}

