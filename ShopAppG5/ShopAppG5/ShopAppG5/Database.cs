using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ShopAppG5
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(path, "ShoppingCart.db3");
            _database = new SQLiteAsyncConnection(path);
            _database.CreateTableAsync<SearchProduct>().Wait();
            _database.CreateTableAsync<Price>().Wait();
        }

        public Task<List<SearchProduct>> GetProductAsync()
        {
            return _database.Table<SearchProduct>().ToListAsync();
        }

        public Task<int> SaveProductAsync(SearchProduct product)
        {
            return _database.InsertAsync(product);
        }

        public Task<List<Price>> GetPriceAsync()
        {
            return _database.Table<Price>().ToListAsync();
        }

        public Task<int> SavePriceAsync(Price price)
        {
            return _database.InsertAsync(price);
        }

        public Task<int> DeleteProductAsync(SearchProduct toDelete)
        {
            return _database.DeleteAsync(toDelete);
        }
    }
}
