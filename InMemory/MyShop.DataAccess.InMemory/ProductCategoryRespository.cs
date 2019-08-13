using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRespository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRespository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }

        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }


        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory pc)
        {
            ProductCategory pcToUpdate = productCategories.Find(p => p.Id == pc.Id);

            if (pcToUpdate != null)
            {
                pcToUpdate = pc;
            }
            else
            {
                throw new Exception("Product Cat not found");
            }

        }

        public ProductCategory Find(string Id)
        {
            ProductCategory pc = productCategories.Find(p => p.Id == Id);

            if (pc != null)
            {
                return pc;
            }
            else
            {
                throw new Exception("Product Cat not found");
            }

        }


        public void Delete(ProductCategory pc)
        {
            ProductCategory pcToDelete = productCategories.Find(p => p.Id == pc.Id);

            if (pcToDelete != null)
            {
                productCategories.Remove(pcToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }

        }


        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }
    }
}
