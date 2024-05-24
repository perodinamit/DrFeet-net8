using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class OrderItemRepository 
    {
        private readonly ApplicationDbContext context;

        public OrderItemRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<OrderItem>> GetOrderItemsForOrder(int orderId)
        {
            var orderItems = await context.OrderItems
                .Include(x => x.Order)
                .Include(x => x.Calculation)
                .Where(x => x.OrderId == orderId)
                .ToListAsync();

            return orderItems;
        }

        public async Task<bool> SaveOrderItem(OrderItem orderItem)
        {
            await context.Set<OrderItem>().AddAsync(orderItem);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteOrderItem(int orderItemId)
        {
            var orderItem = await context.Set<OrderItem>().FindAsync(orderItemId);
            context.Set<OrderItem>().Remove(orderItem);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
