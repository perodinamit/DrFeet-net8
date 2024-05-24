using Domain.Entities;

namespace Domain.Repository
{
    public interface IShoeRepository
    {
        Task<List<Shoe>> GetAllShoes();
        Task<bool> Delete(int id);
        Task<Shoe?> FindShoe(int id);
        Task<bool> AddShoe(Shoe newShoe);
        Task<bool> ModifyShoe(Shoe modifiedShoe);
    }
}
