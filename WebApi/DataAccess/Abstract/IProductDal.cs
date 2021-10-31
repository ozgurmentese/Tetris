using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities.Concrete;

namespace WebApi.DataAccess.Abstract
{
    public interface IProductDal
    {
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        List<Product> GetAll();
        Product Get(int id);
    }
}
