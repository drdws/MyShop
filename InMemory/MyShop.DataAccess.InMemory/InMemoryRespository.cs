﻿using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class InMemoryRespository<T> : IRespository<T> where T : baseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRespository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;

            if (items == null)
            {
                items = new List<T>();
            }

        }



        public void Commit()
        {
            cache[className] = items;
        }


        public void Insert(T t)
        {
            items.Add(t);

        }

        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);

            if (tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(className + " not Found");
            }
        }

        public T Find(string ID)
        {
            T t = items.Find(i => i.Id == ID);
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(className + " not Found");
            }

        }


        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }


        public void Delete(string ID)
        {
            T tToDelete = items.Find(i => i.Id == i.Id);

            if (tToDelete != null)
            {
                items.Remove(tToDelete);
            }
            else
            {
                throw new Exception(className + " not Found");
            }


        }
    }
}
