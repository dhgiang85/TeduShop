using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;
namespace TeduShop.Data.Repositories
{
    class OrderDetailRepository : RepositoryBase<OrderDetail>
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
