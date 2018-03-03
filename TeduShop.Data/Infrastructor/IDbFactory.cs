using System;

namespace TeduShop.Data.Infrastructor
{
    public  interface IDbFactory : IDisposable
    {
        TeduShopDbContext Init();
    }
}