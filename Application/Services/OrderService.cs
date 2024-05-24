using Domain.Entities;
using Domain.Repository;

namespace Application.Services
{
    public class OrderService(IOrderRepository orderRepository)
    {
        public async Task<List<Order>> GetAllOrders()
        {
            return await orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await orderRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddOrder(Order order)
        {
            await orderRepository.AddAsync(order);

            return true;
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            await orderRepository.UpdateAsync(order);

            return true;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            await orderRepository.DeleteAsync(id);

            return true;
        }
    }
}
