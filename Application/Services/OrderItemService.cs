using Domain.Entities;
using Infrastructure.Repository;

namespace Application.Services
{
    public class OrderItemService
    {
        private readonly OrderItemRepository orderItemRepository;

        public OrderItemService(OrderItemRepository orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
        }

        public async Task<List<OrderItem>> GetOrderItemsForOrder(int id)
        {
            var orderItems = await orderItemRepository.GetOrderItemsForOrder(id);

            return orderItems;
        }

        public async Task<bool> SaveOrderItem(OrderItem orderItem)
        {
            await orderItemRepository.SaveOrderItem(orderItem);

            return true;
        }

        public async Task<bool> DeleteOrderItem(int id)
        {
            await orderItemRepository.DeleteOrderItem(id);

            return true;
        }

        //public async Task<List<OrderItem>> GetAllOrderItems()
        //{
        //    return await OrderItemRepository.GetAllAsync();
        //}

        //public async Task<OrderItem> GetOrderItemById(int id)
        //{
        //    return await OrderItemRepository.GetByIdAsync(id);
        //}

        //public async Task<bool> AddOrderItem(OrderItem OrderItem)
        //{
        //    await OrderItemRepository.AddAsync(OrderItem);

        //    return true;
        //}

        //public async Task<bool> UpdateOrderItem(OrderItem OrderItem)
        //{
        //    await OrderItemRepository.UpdateAsync(OrderItem);

        //    return true;
        //}

        //public async Task<bool> DeleteOrderItem(int id)
        //{
        //    await OrderItemRepository.DeleteAsync(id);

        //    return true;
        //}
    }
}
