using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using api.Models;

namespace api.Data
{
    public class AppDbContextWithDapper 
    {
        private readonly IDbConnection _dBconnection;

        public AppDbContextWithDapper(IDbConnection dBconnection)
        {
            _dBconnection = dBconnection;
            InitializeDatabase();
        }

        private void InitializeDatabase(){
            _dBconnection.Execute(@"
                CREATE TABLE IF NOT EXISTS Products (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Description TEXT NOT NULL,
                    Price DECIMAL NOT NULL,
                    Category TEXT NOT NULL)");
            
            if(_dBconnection.QueryFirstOrDefault<int>("SELECT COUNT(*) FROM Products") == 0)
            {
                _dBconnection.Execute("INSERT INTO Products (Id, Name, Description, Price, Category) VALUES (@Id, @Name, @Description, @Price, @Category)",
                new[] {
                    new Product {Id = 1, Name = "Product 1", Description = "Product 1 description", Price = 10.99M, Category = "Category 1"},
                    new Product {Id = 2, Name = "Product 2", Description = "Product 2 description", Price = 20.99M, Category = "Category 2"}
                });
            }
        }

        public IEnumerable<Product> GetAllProducts(){
            return _dBconnection.Query<Product>("SELECT * FROM Products");
        }

    }
}