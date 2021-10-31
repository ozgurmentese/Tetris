using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataAccess.Abstract;
using WebApi.Entities.Concrete;

namespace WebApi.DataAccess.Concrete
{
    public class ProductDal : IProductDal
    {
        private List<Product> _products;
        public ProductDal()
        {
            _products = new List<Product>()
            {
                new Product
                {
                    ProductName="Ürün 1",
                    CategoryId=1,
                    ProductId=1,
                    UnitPrice=5,
                    UnitsInStock=15
                },
                new Product
                {
                    ProductName="Ürün 2",
                    CategoryId=1,
                    ProductId=2,
                    UnitPrice=4,
                    UnitsInStock=13
                },
                new Product
                {
                    ProductName="Ürün 3",
                    CategoryId=2,
                    ProductId=3,
                    UnitPrice=6,
                    UnitsInStock=18
                }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            var result = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(result);
        }

        public Product Get(int id)
        {
            return _products.FirstOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            var result = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            result.ProductName = product.ProductName;
            result.CategoryId = product.CategoryId;
            result.UnitPrice = product.UnitPrice;
            result.UnitsInStock = product.UnitsInStock;
        }

    }
}
