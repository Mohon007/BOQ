using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Infrastructure.Files
{
    public class CsvFileHelperForOrder
    {
        public static List<T> ReadCsvFile<T>(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
             var records= csv.GetRecords<T>().ToList();
            return records;
        }
    }
}

