using System.Collections.Generic;
using DutchTree.Data.Entities;

namespace DutchTree.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        bool SaveAll();
        void AddEntity(object model);
    }
}