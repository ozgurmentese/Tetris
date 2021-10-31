using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.Utilities.Results;
using WebApi.Entities.Concrete;

namespace WebApi.Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> Get(int id);
    }
}
