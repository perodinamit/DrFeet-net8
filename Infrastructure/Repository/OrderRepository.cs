using Domain.Entities;
using Domain.Repository;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
