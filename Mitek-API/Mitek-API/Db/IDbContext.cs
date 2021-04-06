using Mitek_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mitek_API.Db
{
    public interface IDbContext
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<int> AddProduct(Product product);
        Task<int> UpdateProduct(int id, Product product);
        Task<int> DeleteProduct(int id);
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<int> AddUser(User product);
        Task<bool> UpdateUser(int id, User user);
        Task<int> DeleteUser(int id);
    }
}
