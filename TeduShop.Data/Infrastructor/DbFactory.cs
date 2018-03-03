namespace TeduShop.Data.Infrastructor
{
    public class DbFactory : Disposable, IDbFactory
    {
        TeduShopDbContext dbContext;

        public TeduShopDbContext Init()
        {
            return dbContext ?? (dbContext =new TeduShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}