using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmazingRace.DAL.Interface
{
    public interface IRepository<T> where T : class
    {
        
        /// Get All objects
        IEnumerable<T> GetEvents();
       
        /// Get Object by Id
        
        T GetById(int id);

        /// Create the object 
        /// <param name="entity"></param>

        void Create(T entity);

        /// Delete object 
        /// <param name="entity"></param>
        void Delete(T entity);
        
        ///Delete a record
        /// <param name="id"></param>
        void Delete(int id);

        /// Update  the object
        /// <param name="entity"></param>
        void Update(T entity);

        void Save();
    }
    
}