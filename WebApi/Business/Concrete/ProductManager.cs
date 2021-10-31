using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Business.Abstract;
using WebApi.Core.Utilities.Results;
using WebApi.DataAccess.Abstract;
using WebApi.Entities.Concrete;

namespace WebApi.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult();
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult("Silindi");
        }

        public IDataResult<Product> Get(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(id),"Listelendi");
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), "Listelendi");
        }

        public IResult Update(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult("Güncellendi");
        }
    }
}
