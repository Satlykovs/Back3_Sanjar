using System.ComponentModel.Design.Serialization;

namespace MySolve;

public class Program
{
    
    private static readonly IEnumerable<Data> data = CsvWorker.Read("sales.csv");
    public static void Main(string[] args)
    {

        
        foreach(var d in data)
        {
            Console.WriteLine($"{d.Date} : {d.Product} - {d.Region} - {d.Quantity} - {d.Price}");
        }

        
    }
}