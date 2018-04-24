using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingRace.Interface
{
    interface IRepository<T> where T:class
    {
        /// Get All objects
        IEnumerable<T> GetAll();

        /// Get Object by Id

        T GetById(int id);

        /// Create the object 
        /// <param name="entity"></param>

        void Insert(T entity);

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

