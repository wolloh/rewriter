using rewriter.OrderService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rewriter.OrderService
{
    public class OrderService : IOrderService
    {
        public async Task<OrderModel> AddOrder(AddOrderModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderModel>> GetOrders()
        {
            return new List<OrderModel>()
           {
               new OrderModel(){Id=1,Title="Title1",Description="Descr" },
               new OrderModel(){Id=2,Title="Title2",Description="Descr2"}
           };
        }

        public async Task UpdateOrder(int id, UpdateOrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
