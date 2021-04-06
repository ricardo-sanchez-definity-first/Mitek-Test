using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mitek_API.Models;

namespace Mitek_API.Db
{
    public class ProductsContext : DbContext, IDbContext
    {
        private DbSet<Product> Products { get; set; }
        private DbSet<User> Users { get; set; }

        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //Entity to table.
            builder.Entity<Product>().ToTable("Products");

            builder.Entity<User>().ToTable("Users");

            //Primary key
            builder.Entity<Product>().HasKey(p => p.Id).HasName("id");

            builder.Entity<User>().HasKey(p => p.Id).HasName("id");

            //Columns Config
            builder.Entity<Product>().Property(p => p.Id).IsRequired().HasColumnType("int");
            builder.Entity<Product>().Property(p => p.Category).IsRequired().HasColumnType("int");
            builder.Entity<Product>().Property(p => p.Description).IsRequired().HasColumnType("varchar(200)");
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasColumnType("varchar(100)");

            builder.Entity<User>().Property(p => p.Id).IsRequired().HasColumnType("int");
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasColumnType("varchar(100)");
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasColumnType("varchar(50)");
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasColumnType("varchar(50)");
        }

        #region Products CRUD
        public async Task<List<Product>> GetProducts()
        {
            try
            {
                return await Products.ToListAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            try
            {
                return await Products.FindAsync(id).AsTask();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<int> AddProduct(Product product)
        {
            try
            {
                Products.Add(product);
                return await SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateProduct(int id, Product product)
        {
            var oldProduct = Products.FirstOrDefault(p => p.Id == id);
            try
            {
                if(oldProduct != null)
                {
                    product.Id = oldProduct.Id;
                    oldProduct = product;
                    SaveChanges();
                    return await Task.Run(() => true);
                }
                else
                {
                    return await Task.Run(() => false);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public Task<int> DeleteProduct(int id)
        {
            try
            {
                var productToRemove = Products.Find(id);
                Products.Remove(productToRemove);
                return SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Users CRUD + log in validation
        public async Task<List<User>> GetUsers()
        {
            try
            {
                return await Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                return await Users.FindAsync(id).AsTask();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> AddUser(User user)
        {
            try
            {
                Users.Add(user);
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateUser(int id, User user)
        {
            var oldUser = Users.FirstOrDefault(p => p.Id == id);
            try
            {
                if (oldUser != null)
                {
                    user.Id = oldUser.Id;
                    oldUser = user;
                    SaveChanges();
                    return await Task.Run(() => true);
                }
                else
                {
                    return await Task.Run(() => false);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<int> DeleteUser(int id)
        {
            try
            {
                var userToRemove = Users.Find(id);
                Users.Remove(userToRemove);
                return SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
