using System.ComponentModel.Design.Serialization;

namespace MySolve;

public class Program
{
    CsvCRUD csvCRUD= new CsvCRUD(new CsvWorker("sales.csv"));
    public static void Main(string[] args)
    {

        
    }
}