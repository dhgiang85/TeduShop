using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    class VisitorStatisticRepository : RepositoryBase<VisitorStatistic>
    {
        public VisitorStatisticRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
