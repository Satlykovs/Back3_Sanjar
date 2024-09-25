namespace MySolve;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Linq;


public class CsvCRUD
{
    private CsvWorker _csvWorker;
    public CsvCRUD(CsvWorker csvWorker) //Создать пустой конструктор, если не поступает ничего
    {
        _csvWorker = csvWorker;
    }

    public CsvCRUD()
    {
        
    }

    public List<Data> GetAll()
    {
        return _csvWorker.Read();
    }
    // public void Add(string product, string region, int quantity, decimal price)
    // {
    //     Data newData = new Data(DateTime.UtcNow, product, region, quantity, price);

    //     List<Data> allData = GetAll();
    //     allData.Add(newData);

    //     _csvWorker.Write(allData);
    // }

    public void Delete(Data dataToDelete)
    {
        List<Data> allData = GetAll();

        allData.RemoveAll(x => x.Product == dataToDelete.Product && x.Region == dataToDelete.Region && x.Quantity == dataToDelete.Quantity && x.Price == dataToDelete.Price);
        _csvWorker.Write(allData);
    }

    public void Update(Data dataToUpdate)
    {
        List<Data> allData = GetAll();
        Data? record = allData.FirstOrDefault(x => x.Date == dataToUpdate.Date && x.Product == dataToUpdate.Product && x.Region == dataToUpdate.Region);

        if  (record != null)
        {
            record.Quantity = dataToUpdate.Quantity;
            record.Price = dataToUpdate.Price;
            _csvWorker.Write(allData);
        }
    }


    public List<Data> FilterByDate(DateTime date)
    {
        return GetAll().Where(data => data.Date.Date == date.Date).ToList();
    }

    public List<Data> FilterByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return GetAll().Where(data => data.Price >= minPrice && data.Price <= maxPrice).ToList();
    }

    
    public decimal GetTotalSales()
    {
        return GetAll().Sum(data => data.Price * data.Quantity);
    }

    public double GetAverageQuantitySold()
    {
        var allData = GetAll();
        return allData.Count > 0 ? allData.Average(data => data.Quantity) : 0;
    }

    public decimal GetSalesSumByProduct(string product)
    {
        return GetAll()
            .Where(data => data.Product == product)
            .Sum(data => data.Price * data.Quantity);
    }

    public decimal GetSalesSumForPeriod(DateTime startDate, DateTime endDate)
    {
        return GetAll()
            .Where(data => data.Date.Date >= startDate.Date && data.Date.Date <= endDate.Date)
            .Sum(data => data.Price * data.Quantity);
    }
}
