using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;
namespace TeduShop.Data.Repositories
{
    class OrderRepository : RepositoryBase<Order>
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
