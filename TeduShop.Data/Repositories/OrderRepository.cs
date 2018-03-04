using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;
namespace TeduShop.Data.Repositories
{
    public class OrderRepository : RepositoryBase<Order>
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
