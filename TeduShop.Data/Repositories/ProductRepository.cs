using System.Collections.Generic;
using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;
using System.Linq;

namespace TeduShop.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetByAlias(string alias);
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetByAlias(string alias)
        {
            return this.DbContext.Products.Where(x => x.Alias == alias).ToList();
        }
    }
}