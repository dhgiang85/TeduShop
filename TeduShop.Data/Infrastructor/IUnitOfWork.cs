using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.Infrastructor
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
