using System.ComponentModel.Design.Serialization;

namespace MySolve;

public class Program
{
    public static void Main(string[] args)
    {
        CsvCRUD csvCRUD = new CsvCRUD(new CsvWorker("sales.csv"));
        var data = csvCRUD.GetAll();

        foreach (var dataItem in data)
        {
            Console.WriteLine($"{dataItem.Date} : {dataItem.Product} - {dataItem.Region}; Quantity: {dataItem.Quantity} Price: {dataItem.Price}");
        }
    }
}

