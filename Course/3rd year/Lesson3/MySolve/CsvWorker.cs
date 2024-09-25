using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
namespace MySolve;



    public class CsvWorker
    {
        private readonly string _filePath;
        public CsvWorker(string filePath)
        {
            _filePath = filePath;
        }
        public List<Data> Read()
        {
            using (var reader = new CsvReader(new StreamReader(_filePath), new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                return reader.GetRecords<Data>().ToList();
            }
        }
        
        public void Write(List<Data> data)
        {
            using (var writer = new CsvWriter(new StreamWriter(_filePath), new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                writer.WriteRecords(data);
            }
        }
    }

