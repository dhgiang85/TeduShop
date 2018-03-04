﻿using System.Collections.Generic;
using TeduShop.Data.Infrastructor;
using TeduShop.Model.Models;
using System.Linq;

namespace TeduShop.Data.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetByAlias(string alias);
    }
    public class ProductReposity : RepositoryBase<Product>, IProductRepository
    {
        public ProductReposity(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetByAlias(string alias)
        {
            return this.DbContext.Products.Where(x => x.Alias == alias).ToList();
        }
    }
}