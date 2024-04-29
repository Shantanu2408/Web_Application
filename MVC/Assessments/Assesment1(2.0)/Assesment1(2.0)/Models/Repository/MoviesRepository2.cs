using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assesment1_2.Models;
using System.Data.Entity;
using Assesment1_2.Models.Repository;
using static Assesment1_2.Models.Repository.IMoviesRespository;

namespace MVC_CodeFirst.Repository
{
    public class ProductRepository<T> : IMoviesRepository<T> where T : class
    {
        MoviesContextData db;
        DbSet<T> dbset;

        public ProductRepository()
        {
            db = new MoviesContextData();
            dbset = db.Set<T>();
        }
        public void Delete(Object Id)
        {
            T getmodel = dbset.Find(Id);
            dbset.Remove(getmodel);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetById(object Id)
        {
            return dbset.Find(Id);
        }

        public void Insert(T obj)
        {
            dbset.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}