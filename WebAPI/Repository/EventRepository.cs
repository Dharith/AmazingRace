using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AmazingRace.Context;
using AmazingRace.Interface;

namespace AmazingRace.Repository
{
    public class EventRepository<T> : IRepository<T> where T:class
    {
        private EventContext context;
        private DbSet<T> db;
        public void EventRespository()
        {
            context = new EventContext();
            db = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return db.ToList();
        }

        public T GetById(int Id)
        {
            return db.Find(Id);
        }

        public void Insert(T obj)
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
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
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