using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;


namespace TeduShop.Data.Repositories
{
    class SupportOnlineRepository : RepositoryBase<SupportOnline>
    {
        public SupportOnlineRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
