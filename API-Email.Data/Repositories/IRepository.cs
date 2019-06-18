using System;
using System.Collections.Generic;
using System.Text;

namespace API_Email.Data.Repositories
{
    using Models;

    public interface IRepository<T> where T: EntityBase
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
