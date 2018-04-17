using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AmazingRace.DAL.Interface;
using AmazingRace.Models;
using AmazingRace.Models.Models;

namespace AmazingRace.DAL
{
    public class EventsRespository <T> : IRepository<T> where T:class
    {
        private EventsContext context;
        private DbSet<T> db;
        public EventsRespository()
        {
            context = new EventsContext();
            db = context.Set<T>();
        }
        public IEnumerable<T> GetEvents()
        {
            return db.ToList();
        }

        public T GetById(int Id)
        {
            return db.Find(Id);
        }

        public void Create(T obj)
        {
            db.Add(obj);
        }
        public void Update(T obj)
        {
            db.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int Id)
        {
            T getObjById = db.Find(Id);
            db.Remove(getObjById);
        }

        public void Delete(T entityToDelete)
        {  
        if (context.Entry(entityToDelete).State == EntityState.Detached) {  
            db.Attach(entityToDelete);  
        }
       db.Remove(entityToDelete);  
       }

        public void Save()
        {
            context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }


    }
}